using MSPAccounting.DataValidation;
using MSPAccounting.Helpers;
using MSPAccounting.Models;
using System;
using System.Linq;
using System.Windows;
using System.Windows.Input;

namespace MSPAccounting.Views
{
    /// <summary>
    /// Interaction logic for CreateClient.xaml
    /// </summary>
    public partial class CreateClient : Window
    {
        private Utilities utilities = new Utilities();

        public CreateClient()
        {
            InitializeComponent();
            LoadStates();
        }

        private void LoadStates()
        {
            using (var db = new MSPAccountingContext())
            {
                var statesList = db.State.ToList();
                cmbbx_State.ItemsSource = statesList;
                var displayName = utilities.GetPropertyName(() => statesList.First().Name);
                cmbbx_State.DisplayMemberPath = displayName;

                cmbbx_State.SelectedIndex = 0;
            }
        }

        private void btn_Create_Click(object sender, RoutedEventArgs e)
        {
            using(var db = new MSPAccountingContext())
            {
                var client = new Client();
                client.Name = txtbx_Name.Text;
                client.ContactInfo = new ContactInfo();
                client.ContactInfo.Phone = txtbx_Phone.Text;
                client.ContactInfo.Email = txtbx_Email.Text;
                client.ContactInfo.AddressLine1 = txtbx_Addr1.Text;
                client.ContactInfo.AddressLine2 = txtbx_Addr2.Text;
                client.ContactInfo.City = txtbx_City.Text;
                client.ContactInfo.State = (State)cmbbx_State.SelectedItem;
                client.ContactInfo.Zip = Int32.Parse(txtbx_Zip.Text);
                //{
                //    Name = txtbx_Name.Text,
                //    ContactInfo = new ContactInfo
                //    {
                //        Phone = txtbx_Phone.Text,
                //        Email = txtbx_Email.Text,
                //        AddressLine1 = txtbx_Addr1.Text,
                //        AddressLine2 = txtbx_Addr2.Text,
                //        City = txtbx_City.Text,
                //        State = (State)cmbbx_State.SelectedItem,
                //        Zip = Int32.Parse(txtbx_City.Text)
                //    }
                //};

                var errors = DataValidator.GetModelErrors(client);
                if(errors.Count > 0)
                {
                    new ErrorDisplay(errors).Show();
                }
                else
                {
                    db.Client.Add(client);
                    db.SaveChanges();
                }
            }
        }

        private void txtbx_Zip_PreviewTextInput(object sender, TextCompositionEventArgs e)
        {
            if (!char.IsDigit(e.Text, e.Text.Length - 1))
                e.Handled = true;
        }
    }
}
