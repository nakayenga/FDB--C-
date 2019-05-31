using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Threading;

namespace BHHC_ACCOUNTING
{
    static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main(string[] args)
        {
           // Application.EnableVisualStyles();
            //Application.SetCompatibleTextRenderingDefault(false);
           // Application.Run(new SplashScreen());

            ShowSplash();   
            Thread.Sleep(2000);
            PreviewExcelFile mainForm = new PreviewExcelFile();
            Application.Run(mainForm);
            
        }

        private static void ShowSplash()
        {
            SplashScreen sp = new SplashScreen();
            sp.Show();
            Application.DoEvents();

            System.Windows.Forms.Timer t = new System.Windows.Forms.Timer();
            t.Interval = 3000;
            t.Tick += new EventHandler((sender, ea) =>
            {
                    sp.BeginInvoke(new Action(() =>
                    {
                        if (sp != null && Application.OpenForms.Count > 1)
                        {
                          sp.Close();
                          sp.Dispose();
                          sp = null;
                          t.Stop();
                          t.Dispose();
                          t = null;
                        }
                   }));
            });
            t.Start();

         
        }
    }
}
