using System;
using System.Windows.Forms;

namespace MidiDriverOrderForKorg
{
    static class Program
    {
        [STAThread]
        static void Main()
        {
            if (Utils.ElevateProcess())
                return;
            
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new Form1());
        }
    }
}