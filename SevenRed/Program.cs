using System;
using System.Windows.Forms;

namespace SevenRed
{
    internal static class Program
    {
        /// <summary>
        /// Main entry point for application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new MainForm());
        }
    }
}
