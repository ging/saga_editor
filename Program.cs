using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using Microsoft.VisualBasic.ApplicationServices;

namespace FFBatch_main
{
    static class Program
    {        
        /// <summary>
        /// Punto de entrada principal para la aplicación.
        /// </summary>
        /// 

        [STAThread]
        
        static void Main()
        {
            using (Mutex mutex = new Mutex(false, "Global\\" + appGuid))
            {
                if (!mutex.WaitOne(0, false))
                {
                    //MessageBox.Show("Only one application instance is allowed.","FFmpeg Batch already running",MessageBoxButtons.OK,MessageBoxIcon.Information);
                }

                Application.EnableVisualStyles();
                Application.SetCompatibleTextRenderingDefault(false);                
                new SingleInstanceApp().Run(Environment.GetCommandLineArgs());
                
                //Application.Run(new Form1());
            }
        }
        private static string appGuid = "01c90e3d-419d-4bf5-9fcc-fcebe6b16840";
    }

    class SingleInstanceApp : WindowsFormsApplicationBase
    {        

        public SingleInstanceApp()
            : base()
        {
            this.IsSingleInstance = true;
        }

        protected override void OnStartupNextInstance(
            StartupNextInstanceEventArgs e)
        {
            base.OnStartupNextInstance(e);
            string[] secondInstanceArgumens = e.CommandLine.Skip(1).ToArray();
            
            String other_file = Path.Combine(Path.GetTempPath(), "FFBatch_test") + "\\" + "Other_instance.fftmp";
            File.WriteAllLines(other_file,secondInstanceArgumens);
            // Handle command line arguments of second instance

            if (e.BringToForeground)
            {
                this.MainForm.BringToFront();
            }
        }       

        protected override void OnCreateMainForm()
        {            
            base.OnCreateMainForm();            
            this.MainForm = new Form1();
        }
    }
}
