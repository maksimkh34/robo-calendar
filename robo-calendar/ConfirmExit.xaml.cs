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
    /// Логика взаимодействия для ConfirmExit.xaml
    /// </summary>
    public partial class ConfirmExit : Window
    {
        public ConfirmExit()
        {
            InitializeComponent();
        }

        private void Yes_Click(object sender, RoutedEventArgs e)
        {
            Application.Current.Shutdown();
        }

        private void No_Click(object sender, RoutedEventArgs e)
        {
            Close();
        }

        private void Border_MouseDonw_Trigger(object sender, RoutedEventArgs e) => DragMove();

        private void Minimize_TopBar_Click(object sender, RoutedEventArgs e)
        {
            WindowState = WindowState.Minimized;
        }

        private void Close_TopBar_Click(object sender, RoutedEventArgs e)
        {
            Close();
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            if(App.AppSettings["Theme"] == "default")
            {
                TopBarBorder.Visibility = Visibility.Hidden;
                TopBarBorder.Margin = new Thickness(0, 0, 0, -20);
                WindowStyle = WindowStyle.SingleBorderWindow;
               
                Style = FindResource("EmptyStyle") as Style;
                Yes.Style = FindResource("EmptyStyle") as Style;
                No.Style = FindResource("EmptyStyle") as Style;
                ConfirmExitTextBlock.Style = FindResource("EmptyStyle") as Style;
            }
        }
    }
}
