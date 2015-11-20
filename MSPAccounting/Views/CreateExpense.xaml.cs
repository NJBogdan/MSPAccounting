using MSPAccounting.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity.Validation;
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

namespace MSPAccounting.Views
{
    /// <summary>
    /// Interaction logic for CreateExpense.xaml
    /// </summary>
    public partial class CreateExpense : Window
    {
        public CreateExpense()
        {
            InitializeComponent();
        }

        private void btn_Create_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                using (var db = new MSPAccountingContext())
                {
                    var expense = new Expense();
                    expense.Date = datetime_Date.Value == null ? DateTime.Now : (DateTime)datetime_Date.Value;
                    expense.Amount = Convert.ToDecimal(txtbx_Amount.Text);
                    //expense.Client = new Client();
                    expense.Comments = txtbx_Comments.Text;

                    db.Expense.Add(expense);
                    db.SaveChanges();
                }
            }

            catch (Exception ex)
            {
               
            }
        }
    }
}
