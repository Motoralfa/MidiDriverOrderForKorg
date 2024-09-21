using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MidiDriverOrderForKorg
{
    public class USBEntry
    {
        public string Driver { get; set; }
        public string FriendlyName { get; set; }
        public bool IsKorg { get; set; }
    }
}
