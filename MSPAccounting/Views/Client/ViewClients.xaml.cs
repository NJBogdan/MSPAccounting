﻿using MSPAccounting.Helpers;
using MSPAccounting.Interfaces;
using MSPAccounting.Models;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
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
    /// Interaction logic for ViewClients.xaml
    /// </summary>
    public partial class ViewClients : UserControl
    {
        public ViewClients()
        {
            InitializeComponent();

            Load();
        }

        private void Load()
        {
            var utilities = new Utilities();
            using (var db = new MSPAccounting.Models.MSPAccountingContext())
            {
                var clients = db.Client.ToList();

                if (clients.Count == 0)
                {
                    dataGridClients.Visibility = Visibility.Collapsed;
                    txtblkNoClients.Visibility = Visibility.Visible;
                }
                else
                {
                    dataGridClients.Visibility = Visibility.Visible;
                    txtblkNoClients.Visibility = Visibility.Collapsed;

                    dataGridClients.ItemsSource = utilities.GetViewModelList<Client, ClientView>(clients);
                }
            }
        }

        private void dataGridClients_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        {
            //double click to edit client
            MessageBox.Show("You double clicked on " + ((IViewModel)dataGridClients.SelectedItem).ID);
        }

        private void btnCreateClient_Click(object sender, RoutedEventArgs e)
        {
            new CreateClient().ShowDialog();
        }
    }
}
