using System.Windows;

namespace MSPAccounting.Views
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class HomeScreen : Window
    {
        public HomeScreen()
        {
            InitializeComponent();
        }

        private void btn_AddAppt_Click(object sender, RoutedEventArgs e)
        {
            new CreateAppointment().Show();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            new CreateClient().Show();
        }
    }
}
