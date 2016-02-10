using MSPAccounting.Models;
using System.Linq;
using System.Windows;

namespace MSPAccounting.Views
{
    /// <summary>
    /// Interaction logic for ViewExpenses.xaml
    /// </summary>
    public partial class ViewExpenses : Window
    {
        public ViewExpenses()
        {
            InitializeComponent();

            LoadExpenses();
        }

        private void LoadExpenses()
        {
            using(var db = new MSPAccountingContext())
            {
                var data = db.Expense.ToList();

                _DataGrid.ItemsSource = data;
            }
        }
    }
}
