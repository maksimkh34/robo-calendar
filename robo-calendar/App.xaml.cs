using System.Configuration;
using System.Data;
using System.Windows;
using System.Windows.Media;

namespace robo_calendar
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application
    {
        public static Dictionary<string, string> AppSettings = [];
        public static string PathToSettings = "settings";
        public void LoadSettings()
        {
            AppSettings = DataProvider.LoadDataDict(PathToSettings);
            AppSettings.TryAdd("Theme", "Black");
        }

        private void Application_Startup(object sender, StartupEventArgs e)
        {
            LoadSettings();
        }

        private void Application_Exit(object sender, ExitEventArgs e)
        {
            DataProvider.WriteDataDict(PathToSettings, AppSettings);
        }
    }
}
