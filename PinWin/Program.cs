using System;
using System.Windows.Forms;
using Bluegrams.Application;
using PinWin.Properties;

namespace PinWin
{
    static class Program
    {
#if PORTABLE
        internal const string UpdateCheckUrl = "https://pinwin.sourcefirge.io/update_portable.xml";
#else
        internal const string UpdateCheckUrl = "https://pinwin.sourceforge.io/update.xml";
#endif

        [STAThread]
        static void Main()
        {
            if (AppInfo.IsPortable.GetValueOrDefault())
                PortableSettingsProvider.ApplyProvider(Settings.Default);
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new MainApplicationContext());
        }
    }
}
