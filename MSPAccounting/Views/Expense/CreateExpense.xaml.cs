using MSPAccounting.Models;
using System;
using System.Linq;
using System.Windows;

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

                    var errors = expense.GetModelErrors();

                    if (errors.Count > 0)
                    {
                        new ErrorDisplay(errors).Show();
                    }
                    else
                    {
                        db.Expense.Add(expense);
                        db.SaveChanges();
                    }
                }
            }

            catch (Exception ex)
            {
               
            }
        }
    }
}
