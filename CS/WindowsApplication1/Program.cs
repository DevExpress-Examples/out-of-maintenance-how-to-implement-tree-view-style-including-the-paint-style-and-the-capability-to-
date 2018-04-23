using DevExpress.LookAndFeel;
using DevExpress.Skins;
using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace WindowsApplication1 {
    internal static class Program {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        private static void Main() {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            DevExpress.UserSkins.BonusSkins.Register();
            SkinManager.EnableFormSkins();
            Application.Run(new Form1());
        }
    }
}
