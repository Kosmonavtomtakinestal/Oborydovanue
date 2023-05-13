using System;
using System.Collections.Generic;
using System.Data.Entity;
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
using Oborydovanue_StoreEmployee.DataBase;

namespace Oborydovanue_StoreEmployee.Pages.PageItems
{
    /// <summary>
    /// Логика взаимодействия для OurDeliveryPage.xaml
    /// </summary>
    public partial class OurDeliveryPage : Page
    {
        
        public IEnumerable<Delivery> Deliveries => Connection.db.Delivery.Local.Where(x => x.IdPointOfIssue == SaveSomeData.storeEmployee.IdpoinOfIssue);
        public OurDeliveryPage()
        {
            Connection.db.Delivery.Load();
            Connection.db.Delivered.Load();

            InitializeComponent();

            List<int> delivereds = Connection.db.Delivered.Select(s => s.IdDelivery).ToList();
            
            List<Delivery> notIndelivered = Connection.db.Delivery.Where(x => delivereds.Contains(x.Id) == false).ToList();
            
            DelList.ItemsSource = notIndelivered.Where(x => x.IdPointOfIssue == SaveSomeData.storeEmployee.IdpoinOfIssue && x.IdDeliverier != null).ToList();
        }

        private void ReadyDeliveryBTN_Click(object sender, RoutedEventArgs e)
        {
            if (MessageBox.Show("Заказ точно прибыл?", "Уведомление", MessageBoxButton.YesNo) == MessageBoxResult.Yes)
            {
                var sel = (sender as Button).DataContext as Delivery;
                Delivered delivered = new Delivered() 
                {
                    IdDelivery = sel.Id,
                    IdStoreemployee = SaveSomeData.storeEmployee.Id,
                    DateTine = DateTime.Now
                };
                Connection.db.Delivered.Add(delivered);
                List<DeliveryProducts> deliveryProducts = sel.DeliveryProducts.ToList();
                foreach (var item in deliveryProducts)
                {
                    DataContext = item.Stock.Count += (int)item.Count;
                }
                Connection.db.SaveChanges();

                List<int> delivereds = Connection.db.Delivered.Select(s => s.IdDelivery).ToList();

                List<Delivery> notIndelivered = Connection.db.Delivery.Where(x => delivereds.Contains(x.Id) == false).ToList();

                DelList.ItemsSource = notIndelivered.Where(x => x.IdPointOfIssue == SaveSomeData.storeEmployee.IdpoinOfIssue && x.IdDeliverier != null).ToList();
            }
        }
    }
}
