using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;
using DevExpress.UserSkins;
using DevExpress.Skins;
using DevExpress.LookAndFeel;
using DXApplication2.Properties;

namespace DXApplication2
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

            BonusSkins.Register();
            SkinManager.EnableFormSkins();
            UserLookAndFeel.Default.SetSkinStyle("DevExpress Style");
            // Application.Run(new MainForm());
            //Settings.Default.First = true; //lineas para correr el wizard
            Settings.Default.Save();///
            bool init = Settings.Default.First;
            if (init)
            {
                Application.Run(new WizardForm1());
            }
            else
            {
                Application.Run(new MainForm());
            }
        }
    }
}
