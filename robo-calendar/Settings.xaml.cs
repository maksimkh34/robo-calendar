using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

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
        }

        private void DefaultSettingsChkbx_Checked(object sender, RoutedEventArgs e)
        {
            UpdateLockedElements(this);
        }

        private void Apply_Click(object sender, RoutedEventArgs e)
        {
            if(ThemeComboBox.Text == "Стандартная")
            {
                App.AppSettings["Theme"] = "default";
            } else
            {
                App.AppSettings["Theme"] = "Black";
            }
            Close();
        }
    }
}
