using System.Windows;
using System.Windows.Input;

namespace robo_calendar
{
    /// <summary>
    /// Логика взаимодействия для Settings.xaml
    /// </summary>
    public partial class Settings : Window
    {
        public Settings()
        {
            InitializeComponent();
        }

        private void Minimize_TopBar_Click(object sender, RoutedEventArgs e)
        {
            WindowState = WindowState.Minimized;
        }

        private void Close_TopBar_Click(object sender, RoutedEventArgs e)
        {
            Close();
        }

        private void Border_MouseDown(object sender, MouseButtonEventArgs e) => DragMove();

        private void Cancel_Click(object sender, RoutedEventArgs e)
        {
            Close();
        }

        void UpdateLockedElements(Settings window)
        {
            bool isChecked = (bool)window.DefaultSettingsChkbx.IsChecked;
            window.address_textbox.IsEnabled = !isChecked;
            window.passwd_textbox.IsEnabled = !isChecked;
            window.port_textbox.IsEnabled = !isChecked;
            window.username_textbox.IsEnabled = !isChecked;
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            UpdateLockedElements(this);
            if (App.AppSettings["Theme"] == "default")
            {
                BlackThemeComboBoxItem.IsSelected = false;
                DefaultThemeComboBoxItem.IsSelected = true;
            }
            App.SetTheme(this, TopBarBorder);
        }

        private void DefaultSettingsChkbx_Checked(object sender, RoutedEventArgs e)
        {
            UpdateLockedElements(this);
        }

        private void Apply_Click(object sender, RoutedEventArgs e)
        {
            if (ThemeComboBox.Text == "Стандартная" && App.AppSettings["Theme"] != "default")
            {
                App.AppSettings["Theme"] = "default";
                App.RestartApp();
            }
            else if (ThemeComboBox.Text == "Тёмная" && App.AppSettings["Theme"] != "Black")
            {
                App.AppSettings["Theme"] = "Black";
                App.RestartApp();
            }
            Close();
        }
    }
}
