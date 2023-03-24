using Oborydovanue_Deliverier.DataBase;
using System.Collections.Generic;
using System.Collections.ObjectModel;
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
        public IEnumerable<Delivery> Deliveries => Connection.db.Delivery.Local.Where(x => x.IdDeliverier == SaveSomeData.deliverier.Id);

        public DeliveriesPage()
        {
            Connection.db.Delivery.Load();

            InitializeComponent();

            DelDatesTB.Text = $"{SaveSomeData.deliverier.Surname} {SaveSomeData.deliverier.Name}";
        }

        private void GetDeliverzCB_Checked(object sender, System.Windows.RoutedEventArgs e)
        {
            (sender as CheckBox).IsEnabled = true;
        }

        private void BackBTN_Click(object sender, System.Windows.RoutedEventArgs e)
        {
            SaveSomeData.main.MainFrame.Navigate(new AuthPage());
        }
    }
}
