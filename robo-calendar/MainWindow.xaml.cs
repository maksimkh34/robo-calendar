using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace robo_calendar
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void AddTour_Click(object sender, RoutedEventArgs e)
        {

        }

        private void EdiTour_Click(object sender, RoutedEventArgs e)
        {

        }

        private void DeleteTour_Click(object sender, RoutedEventArgs e)
        {
           
        }

        private void Exit_Click(object sender, RoutedEventArgs e)
        {
            ConfirmExit confirmExit = new();
            confirmExit.ShowDialog();
        }

        private void CheckScore_Click(object sender, RoutedEventArgs e)
        {

        }

        private void Stats_Click(object sender, RoutedEventArgs e)
        {

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

        private void Settings_Click(object sender, RoutedEventArgs e)
        {
            Settings settings = new();
            settings.ShowDialog();
        }
    }
}