using MSPAccounting.Helpers;
using MSPAccounting.Models;
using System;
using System.Linq;
using System.Windows;

namespace MSPAccounting.Views
{
    /// <summary>
    /// Interaction logic for CreateEarning.xaml
    /// </summary>
    public partial class CreateEarning : Window
    {
        public CreateEarning()
        {
            InitializeComponent();
            LoadDefaults();
            LoadClients();
        }

        private void LoadDefaults()
        {
            dtDate.Value = DateTime.Now;
        }

        private void LoadClients()
        {
            var utilities = new Utilities();
            using (var db = new MSPAccountingContext())
            {
                var clients = db.Client.ToList();
                cmbbxClient.ItemsSource = clients;
                var displayName = utilities.GetPropertyName(() => clients.First().Name);
                cmbbxClient.DisplayMemberPath = displayName;

                cmbbxClient.SelectedIndex = 0;
            }
        }

        private void btnCreate_Click(object sender, RoutedEventArgs e)
        {
            using (var db = new MSPAccountingContext())
            {
                var earning = new Earning()
                {
                    Date = dtDate.Value == null ? DateTime.Now : (DateTime)dtDate.Value,
                    Amount = Decimal.Parse(txtbxAmount.Text),
                    Client = db.Client.Single(x => x.ID == ((Client)cmbbxClient.SelectedItem).ID),
                    Comments = txtbxComments.Text
                };

                var errors = earning.GetModelErrors();

                if(errors.Count > 0)
                {
                    new ErrorDisplay(errors).ShowDialog();
                }
                else
                {
                    db.Earning.Add(earning);
                    db.SaveChanges();

                    MessageBox.Show("Earning Created!");
                    Close();
                }
            }
        }
    }
}
