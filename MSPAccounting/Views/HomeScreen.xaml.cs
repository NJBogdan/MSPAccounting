using MSPAccounting.Models;
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
using System.Windows.Navigation;
using System.Windows.Shapes;
using MSPAccounting.Views;

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

        private void btn_addExpense_Click(object sender, RoutedEventArgs e)
        {
            new CreateExpense().Show();
        }

        private void btn_ViewExpenses_Click(object sender, RoutedEventArgs e)
        {
            new ViewExpenses().Show();
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
