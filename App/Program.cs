using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace App
{
    internal static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);

<<<<<<< HEAD

            Application.Run(new LoginForm());



=======
            Application.Run(new QLKH());
>>>>>>> 714c52903e7353aa6da1ffba2c7a4cd07aacf19a
        }
    }
}
