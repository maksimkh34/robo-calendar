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
        public static Dictionary<string, string> AppSettings = new Dictionary<string, string>();
        public void LoadSettings()
        {

        }

        private void Application_Startup(object sender, StartupEventArgs e)
        {
            AppSettings.Add("Theme", "Black");
            LoadSettings();
        }
    }
}
