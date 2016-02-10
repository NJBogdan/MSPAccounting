using MSPAccounting.DataValidation;
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
using System.Windows.Shapes;

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

                var errors = DataValidator.GetModelErrors(appointment);
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
