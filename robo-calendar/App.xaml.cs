using System.Reflection;
using System.Windows;
using System.Windows.Controls;
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

        public static IEnumerable<T> AllChildren<T>(DependencyObject depObj) where T : DependencyObject
        {
            if (depObj == null) yield return (T)Enumerable.Empty<T>();
            for (int i = 0; i < VisualTreeHelper.GetChildrenCount(depObj); i++)
            {
                DependencyObject ithChild = VisualTreeHelper.GetChild(depObj, i);
                if (ithChild == null) continue;
                if (ithChild is T t) yield return t;
                foreach (T childOfChild in AllChildren<T>(ithChild)) yield return childOfChild;
            }
        }

        public static void SetTheme(Window window, Border TopBarBorder)
        {
            if (AppSettings["Theme"] == "default")
            {
                TopBarBorder.Visibility = Visibility.Hidden;
                TopBarBorder.Margin = new Thickness(0, 0, 0, -20);
                window.WindowStyle = WindowStyle.SingleBorderWindow;
                var AllChildButton = AllChildren<Button>(window);
                foreach (var child in AllChildButton)
                {
                    child.Style = new Style();
                }

                var AllChildTB = AllChildren<TextBlock>(window);
                foreach (var child in AllChildTB)
                {
                    child.Style = new Style();
                }
                window.Style = new Style();

                var AllChildLB = AllChildren<ListBox>(window);
                foreach (var child in AllChildLB)
                {
                    child.Style = new Style();
                }
                window.Style = new Style();

                var AllChildGB = AllChildren<GroupBox>(window);
                foreach (var child in AllChildGB)
                {
                    child.Style = new Style();
                }
                window.Style = new Style();
            }
        }

        public static void RestartApp()
        {
            MessageBox.Show("Перезапустите приложение для применения темы! ", "Предупреждение", MessageBoxButton.OK, MessageBoxImage.Exclamation);
            Current?.Shutdown();
        }
    }
}
