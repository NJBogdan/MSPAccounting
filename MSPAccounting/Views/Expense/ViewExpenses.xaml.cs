using MSPAccounting.Helpers;
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

namespace MSPAccounting.Views
{
    /// <summary>
    /// Interaction logic for ViewExpenses.xaml
    /// </summary>
    public partial class ViewExpenses : UserControl
    {
        public ViewExpenses()
        {
            InitializeComponent();
            Load();
        }

        private void Load()
        {
            var utilities = new Utilities();
            using (var db = new MSPAccounting.Models.MSPAccountingContext())
            {
                var expenses = db.Expense.ToList();

                if (expenses.Count == 0)
                {
                    dataGridExpenses.Visibility = Visibility.Collapsed;
                    txtblkNoExpenses.Visibility = Visibility.Visible;
                }
                else
                {
                    dataGridExpenses.Visibility = Visibility.Visible;
                    txtblkNoExpenses.Visibility = Visibility.Collapsed;

                    dataGridExpenses.ItemsSource = utilities.GetViewModelList<Expense, ExpenseView>(expenses);
                }
            }
        }

        private void btnCreateExpense_Click(object sender, RoutedEventArgs e)
        {
            new CreateExpense().ShowDialog();
            Load();
        }
    }
}
