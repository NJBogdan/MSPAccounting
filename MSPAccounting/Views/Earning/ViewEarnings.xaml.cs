using MSPAccounting.Helpers;
using MSPAccounting.Models;
using System.Linq;
using System.Windows;
using System.Windows.Controls;

namespace MSPAccounting.Views
{
    /// <summary>
    /// Interaction logic for ViewEarnings.xaml
    /// </summary>
    public partial class ViewEarnings : UserControl
    {
        public ViewEarnings()
        {
            InitializeComponent();
            Load();
        }

        private void Load()
        {
            var utilities = new Utilities();
            using (var db = new MSPAccounting.Models.MSPAccountingContext())
            {
                var earnings = db.Earning.ToList();

                if (earnings.Count == 0)
                {
                    dataGridEarnings.Visibility = Visibility.Collapsed;
                    txtblkNoEarnings.Visibility = Visibility.Visible;
                }
                else
                {
                    dataGridEarnings.Visibility = Visibility.Visible;
                    txtblkNoEarnings.Visibility = Visibility.Collapsed;

                    dataGridEarnings.ItemsSource = utilities.GetViewModelList<Earning, EarningView>(earnings);
                }
            }
        }

        private void btnCreateEarning_Click(object sender, RoutedEventArgs e)
        {
            new CreateEarning().ShowDialog();
            Load();
        }
    }
}
