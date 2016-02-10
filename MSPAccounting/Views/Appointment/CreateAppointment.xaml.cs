using MSPAccounting.Models;
using System;
using System.Linq;
using System.Windows;

namespace MSPAccounting.Views
{
    /// <summary>
    /// Interaction logic for CreateAppointment.xaml
    /// </summary>
    public partial class CreateAppointment : Window
    {
        public CreateAppointment()
        {
            InitializeComponent();
        }

        private void btnCreate_Click(object sender, RoutedEventArgs e)
        {
            using (var db = new MSPAccountingContext())
            {
                var appointment = new Appointment();

                appointment.Date = Convert.ToDateTime(dtpDate.Value);
                appointment.Location = txtbxLocation.Text;

                var errors = appointment.GetModelErrors();
                if (errors.Count > 0)
                {
                    new ErrorDisplay(errors).Show();
                }
                else
                {
                    db.Appointment.Add(appointment);
                    db.SaveChanges();

                    MessageBox.Show("Appointment Successfully Created!", "Success", MessageBoxButton.OK);

                    this.Close();
                }
            }
        }
    }
}
