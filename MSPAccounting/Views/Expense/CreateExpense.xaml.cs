using MSPAccounting.Models;
using System;
using System.Linq;
using System.Text.RegularExpressions;
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

        private void btnCreate_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                using (var db = new MSPAccountingContext())
                {
                    var isClientSelected = cmbbxClient.SelectedItem != null;
                    var expense = new Expense()
                    {
                        Date = datetime_Date.Value == null ? DateTime.Now : (DateTime)datetime_Date.Value,
                        Amount = dcmlAmount.Value == null ? 0 : (decimal)dcmlAmount.Value,
                        Client = isClientSelected ? db.Client.SingleOrDefault(x => x.ID == ((Client)cmbbxClient.SelectedItem).ID) : null,
                        Comments = txtbxComments.Text
                    };

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
