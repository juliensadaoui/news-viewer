using System;
using System.Collections.Generic;
using System.Windows.Forms;
using System.Xml;

namespace Insta.Project.LecteurRSS
{
    static class Program
    {
        /// <summary>
        /// Point d'entrée principal de l'application.
        /// </summary>
        [STAThread]
        public static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new frmManager());
        }
    }
}
