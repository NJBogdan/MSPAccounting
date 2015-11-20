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

namespace MSPAccounting
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

        private void btn_addExpense_Click(object sender, RoutedEventArgs e)
        {
            new CreateExpense().Show();
        }

        private void btn_ViewExpenses_Click(object sender, RoutedEventArgs e)
        {
            new ViewExpenses().Show();
        }
    }
}
