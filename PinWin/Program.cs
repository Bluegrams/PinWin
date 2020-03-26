using System;
using System.Windows.Forms;
using Bluegrams.Application;
using PinWin.Properties;

namespace PinWin
{
    static class Program
    {
        internal const string UPDATE_URL = "https://pinwin.sourceforge.io/update.xml";

#if PORTABLE
        internal const string UPDATE_IDENTIFIER = "portable";
#else
        internal const string UPDATE_IDENTIFIER = "install";
#endif

        [STAThread]
        static void Main()
        {
            AppDomain.CurrentDomain.UnhandledException += CurrentDomain_UnhandledException;
            if (AppInfo.IsPortable.GetValueOrDefault())
                PortableSettingsProvider.ApplyProvider(Settings.Default);
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new MainApplicationContext());
        }

        private static void CurrentDomain_UnhandledException(object sender, UnhandledExceptionEventArgs e)
        {
            Logger.Default.Log("An unhandled exception caused the application to terminate unexpectedly.",
                (Exception)e.ExceptionObject);
        }
    }
}
