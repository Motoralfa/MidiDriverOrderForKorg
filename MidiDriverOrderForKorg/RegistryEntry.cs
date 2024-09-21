using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MidiDriverOrderForKorg
{
    public class RegistryEntry
    {
        public string FullKey { get; set; }
        public string Alias { get; set; }
        public string DeviceName { get; set; }
        public bool IsKorg { get; set; }
    }

}
