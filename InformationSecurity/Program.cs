using InformationSecurity.FileStorage;
using InformationSecurity.Views;
using System;
using System.Windows.Forms;

namespace InformationSecurity
{
    static class Program
    {
        /// <summary>
        ///  The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            //Application.SetHighDpiMode(HighDpiMode.SystemAware);
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            using (FileDataListSingleton.GetInstance())
            {
                while (true)
                {
                    var form = new AutorizationForm();
                    Application.Run(form);

                    if (form.AutorizationSuccess)
                    {
                        var user = form.GetUser();
                        Application.Run(new MainForm(user));
                    }
                    else
                    {
                        break;
                    }
                }
                
            }   
        }
    }
}
