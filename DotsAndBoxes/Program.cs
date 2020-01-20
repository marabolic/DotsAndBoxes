using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace etf.dotsandboxes.bm170614d
{
    static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        ///
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Form2 form2 = new Form2();
            Application.Run(form2);
        }
    }
}
