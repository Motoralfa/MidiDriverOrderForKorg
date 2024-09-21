# MidiDriverOrderForKorg
Tool to reorder and fix Korg midi driver entries in the Windows registry

![369643934-dfc18bf8-b8c3-4bc1-a7bf-af47e016cbbf](https://github.com/user-attachments/assets/8c9d7069-0ad6-4034-b158-0b92fb3c97ca)


## About this app
Korg midi drivers on Windows can sometimes become invisible in DAWs and other midi applications. The reason for this is that the Korg devices must be listed within the first 10 midi device entries in the Windows registry.
If you have a large synth setup with multiple midi devices from other manufacturers, Korg devices may "drop" from the first 10 registered devices and become invisible to midi applications. 
Over the years a number of workarounds have been published that involve driver removall/reinstallation and registry tinkering. 
This application is designed to simplify this process by allowing reordering of the midi devices using a User Interface.

## Usage 
1) Shutdown any running midi applications (DAWs, MIDI-Ox, etc)
2) Run the application. The application will ask for elevated Windows privilages. This is necessary as the app will manipulate the Windows registry.
3) You should see a list of all installed midi devices in the system. Korg devices have a "Y" in the "Korg" column.
4) Using the buttons/menu reorder the midi entries so the Korg devices are at the top, or within the first 10 entries. Alternatively press the "Move Korg drivers to the top" button.
5) Press the save button/menu. The modification has been applied.
6) Windows restart is highly recommended after you save any changes. 
7) Launch your midi application. The Korg devices must now appear in the midi device list. Additionaly, you can use the official Korg driver uninstaller to review the driver order settings.

**Important! Only focus on the first 10 devices (highlighted).** The application will not save anything greater than the 10th midi device as Windows will not treat it specially. In fact the Korg drivers will auto erase ordering information after the 10th device.



