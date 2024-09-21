using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.Security.Principal;
using System.Windows.Forms;

namespace MidiDriverOrderForKorg
{
    public class Utils
    {
        private const string MidiDeviceStr = "{4d36e96c-e325-11ce-bfc1-08002be10318}";
        private const string MainKeyStr = @"SYSTEM\CurrentControlSet\Control\Class\" + MidiDeviceStr;
        private const string USBKeyStr = @"SYSTEM\CurrentControlSet\Enum\USB";
        private const string KorgDriverPrefix = @"vid_0944";
        public const int MidiAliasLowIdx = 0;
        public const int MidiAliasMaxIdx = 9;

        // We'll use RegistryView to control WOW6432Node node
        private const string StaleAliases = @"SOFTWARE\Microsoft\Windows NT\CurrentVersion\Drivers32";
        //private const string StaleAliases32bit = @"SOFTWARE\WOW6432Node\Microsoft\Windows NT\CurrentVersion\Drivers32"; 

        public static ICollection<RegistryEntry> SortEntries(ICollection<RegistryEntry> entries)
        {
            var entriesRemain = new LinkedList<RegistryEntry>();
            var sorted = new SortedDictionary<int, RegistryEntry>();
            foreach (var entry in entries)
            {
                var alias = entry.Alias;
                if (string.IsNullOrEmpty(alias))
                {
                    entriesRemain.AddLast(entry);
                    continue;
                }
                if (!alias.StartsWith("midi"))
                    throw new Exception($"invalid: not starting with midi: {alias}");
                var idxStr = alias.Substring(4);
                if (!int.TryParse(idxStr, out var idx))
                    throw new Exception($"invalid: unparsable idx {idxStr}");
                if (sorted.ContainsKey(idx))
                    throw new Exception($"invalid: dupe alias {alias}");
                sorted.Add(idx, entry);
            }

            var res = new LinkedList<RegistryEntry>();
            var expected = MidiAliasLowIdx;
            foreach (var d in sorted)
            {
                if (d.Key != expected)
                {
                    if (d.Key < expected)
                        throw new Exception($"invalid: idx below bounds {d.Key} - Expected {expected}");
                    var deltaToFill = d.Key - expected;
                    if (entriesRemain.Count < deltaToFill)
                        throw new Exception($"invalid: Not enough unassigned device to fill alias gaps");
                    for (var i = 0; i < deltaToFill; i++)
                    {
                        res.AddLast(entriesRemain.First.Value);
                        entriesRemain.RemoveFirst();
                    }
                }
                res.AddLast(d.Value);
                expected = d.Key + 1;
            }
            foreach (var entry in entriesRemain)
            {
                res.AddLast(entry);
            }
            return res;
        }

        public static void WriteEntry(RegistryEntry entry, int entryNumber)
        {
            var idx = entry.FullKey.IndexOf(@"\", StringComparison.Ordinal);
            if (idx<0)
                throw new Exception($"Failed to open key {entry.FullKey} for writing. Issue reducing reg string");
            var regKey= entry.FullKey.Substring(idx+1);

            using (var mainKey = Registry.LocalMachine.OpenSubKey(regKey, true))
            {
                if (mainKey == null)
                    throw new Exception($"Failed to open key {entry.FullKey} for writing. \n\nDevice:[{entry.DeviceName}]\nKey: {regKey}");
                if (entryNumber <= MidiAliasMaxIdx)
                    mainKey.SetValue("Alias", $"midi{entryNumber}");
                else
                    mainKey.DeleteValue("Alias", false);
            }
        }

        public static void DeleteStaleAliases()
        {
            DeleteStaleAliasesFrom(StaleAliases, RegistryView.Registry64);
            DeleteStaleAliasesFrom(StaleAliases, RegistryView.Registry32);
        }

        private static void DeleteStaleAliasesFrom(string regKey, RegistryView regView)
        {
            using (var localMachine = RegistryKey.OpenBaseKey(RegistryHive.LocalMachine, regView))
            {
                using (var mainKey = localMachine.OpenSubKey(regKey, true))
                {
                    if (mainKey == null)
                        throw new Exception($"Failed to open key[{regKey}], View[{regView}] for writing");
                    for (var i = 0; i <= MidiAliasMaxIdx; i++)
                    {
                        mainKey.DeleteValue($"midi{i}", false);
                    }
                }
            }
        }

        private static IDictionary<string, USBEntry> LookupUSBEntries()
        {
            var dict = new Dictionary<string, USBEntry>();
            using (var mainKey = Registry.LocalMachine.OpenSubKey(USBKeyStr))
            {
                if (mainKey == null)
                    return dict;

                foreach (var usbEntryStr in mainKey.GetSubKeyNames())
                {
                    using (var usbEntryKey = OpenSubKey(mainKey, usbEntryStr, false))
                    {
                        if (usbEntryKey == null)
                            continue;

                        bool isKorg = usbEntryStr.ToLower().StartsWith(KorgDriverPrefix);

                        foreach (var drvEntryName in usbEntryKey.GetSubKeyNames())
                        {
                            using (var drvEntryKey = OpenSubKey(usbEntryKey, drvEntryName, false))
                            {
                                if (drvEntryKey == null)
                                    continue;
                                var classGUID = drvEntryKey.GetValue("ClassGUID")?.ToString();
                                if (classGUID == null)
                                    continue;
                                if (!MidiDeviceStr.Equals(classGUID))
                                    continue;
                                var driver = drvEntryKey.GetValue("Driver")?.ToString();
                                var friendlyName = drvEntryKey.GetValue("FriendlyName")?.ToString();
                                if (driver == null || friendlyName == null)
                                    continue;

                                var entry = new USBEntry
                                {
                                    FriendlyName = friendlyName,
                                    Driver = driver,
                                    IsKorg = isKorg
                                };
                                dict.Add(driver, entry);
                            }

                        }
                    }
                }
            }
            return dict;
        }

        public static ICollection<RegistryEntry> GetRegistryEntries()
        {
            var usbEntries = LookupUSBEntries();
            var dict = new List<RegistryEntry>();
            using (var mainKey = Registry.LocalMachine.OpenSubKey(MainKeyStr))
            {
                if (mainKey == null)
                    return null;

                foreach (var driverEntryStr in mainKey.GetSubKeyNames())
                {
                    using (var driverEntryKey = OpenSubKey(mainKey, driverEntryStr, false))
                    {
                        if (driverEntryKey == null)
                            continue;
                        using (var midiSubKey = OpenSubKey(driverEntryKey, @"Drivers\midi", false))
                        {
                            if (midiSubKey == null)
                                continue;
                            var lookupUsbKey = MidiDeviceStr + "\\" + driverEntryStr;
                            foreach (var midiEntryStr in midiSubKey.GetSubKeyNames())
                            {
                                using (var midiEntrySubKey = OpenSubKey(midiSubKey, midiEntryStr, false))
                                {
                                    if (midiEntrySubKey == null)
                                        continue;

                                    var driverDesc = driverEntryKey.GetValue("DriverDesc")?.ToString();
                                    var alias = midiEntrySubKey.GetValue("Alias")?.ToString();
                                    var matchingDeviceId = driverEntryKey.GetValue("MatchingDeviceId")?.ToString();
                                    var registryEntry = new RegistryEntry()
                                    {
                                        DeviceName = driverDesc,
                                        FullKey = midiEntrySubKey.ToString(),
                                        Alias = alias,
                                        IsKorg = matchingDeviceId != null &&  matchingDeviceId.ToLower().Contains(@"\vid_0944&")
                                    };
                                    if (usbEntries.TryGetValue(lookupUsbKey, out var usbEntry))
                                    {
                                        if (string.IsNullOrEmpty(registryEntry.DeviceName))
                                        {
                                            registryEntry.DeviceName = $"USB Driver [{usbEntry.FriendlyName}]";
                                        }
                                        else
                                        {
                                            registryEntry.DeviceName = $"{registryEntry.DeviceName} [{usbEntry.FriendlyName}]";
                                        }

                                        if (!registryEntry.IsKorg)
                                        {
                                            registryEntry.IsKorg = usbEntry.IsKorg;
                                        }
                                    }
                                    dict.Add(registryEntry);
                                }
                            }
                        }
                    }
                }
            }

            return dict;
        }

        private static RegistryKey OpenSubKey(RegistryKey key, string subKey, bool writeable)
        {
            try
            {
                return key.OpenSubKey(subKey, writeable);
            }
            catch (Exception)
            {
                return null;
            }
        }

        public static bool ElevateProcess()
        {
            var principal = new WindowsPrincipal(WindowsIdentity.GetCurrent());
            var hasAdministrativeRight = principal.IsInRole(WindowsBuiltInRole.Administrator);

            if (!hasAdministrativeRight)
            {
                RunElevated(Application.ExecutablePath);
                Application.Exit();
                return true;
            }
            return false;
        }

        private static bool RunElevated(string fileName)
        {
            var processInfo = new ProcessStartInfo
            {
                Verb = "runas",
                FileName = fileName
            };
            try
            {
                Process.Start(processInfo);
                return true;
            }
            catch (Win32Exception)
            {
                // Do nothing. Probably the user canceled the UAC window
            }
            return false;
        }

    }
}
