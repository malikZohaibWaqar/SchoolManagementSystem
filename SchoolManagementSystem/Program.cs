using System;
using System.Windows.Forms;

namespace SchoolManagementSystem
{
    static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            if (new Account_Management.Signin().ShowDialog() == DialogResult.OK) 
                Application.Run(new Dashboard());
            //if (new Splash().ShowDialog() == DialogResult.OK)
            //    if (new Account_Management.Signin().ShowDialog() == DialogResult.OK)
            //        Application.Run(new Dashboard());
        }
    }
}
