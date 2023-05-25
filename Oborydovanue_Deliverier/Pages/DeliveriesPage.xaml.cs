using Oborydovanue_Deliverier.DataBase;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Data.Common;
using System.Data.Entity;
using System.Linq;
using System.Windows.Controls;

namespace Oborydovanue_Deliverier.Pages
{
    /// <summary>
    /// Логика взаимодействия для DeliveriesPage.xaml
    /// </summary>
    public partial class DeliveriesPage : Page
    {
        public IEnumerable<Delivery> Deliveries => Connection.db.Delivery.Local.Where(x => x.IdDeliverier == SaveSomeData.deliverier.Id && Connection.db.Delivered.Local.FirstOrDefault(c => c.Delivery == x) == null);

        public DeliveriesPage()
        {
            Connection.db.Delivery.Load();
            Connection.db.Delivered.Load();

            InitializeComponent();

            DelDatesTB.Text = $"{SaveSomeData.deliverier.Surname} {SaveSomeData.deliverier.Name}";
        }

        private void BackBTN_Click(object sender, System.Windows.RoutedEventArgs e)
        {
            SaveSomeData.main.MainFrame.Navigate(new AuthPage());
        }

        private void Button_Click(object sender, System.Windows.RoutedEventArgs e)
        {
            if (DeliveriesList.SelectedItem == null)
            {
                return;
            }

            var dbItem = (DeliveriesList.SelectedItem as Delivery);
            dbItem.BeginDateTime = DateTime.Now;
            Connection.db.SaveChanges();
            DeliveriesList.ItemsSource = Connection.db.Delivery.Local.Where(x => x.IdDeliverier == SaveSomeData.deliverier.Id && Connection.db.Delivered.Local.FirstOrDefault(c => c.Delivery == x) == null);
        }

    }
}
