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
using System.Windows.Navigation;
using System.Windows.Shapes;
using Oborydovanue_StoreEmployee.DataBase;

namespace Oborydovanue_StoreEmployee.Pages.PageItems
{
    /// <summary>
    /// Логика взаимодействия для BookOrderPage.xaml
    /// </summary>
    public partial class BookOrderPage : Page
    {
        public static Stock stock;
        public BookOrderPage()
        {
            InitializeComponent();
            ProductList.ItemsSource = SaveSomeData.stocks;
        }

        private void DelBTN_Click(object sender, RoutedEventArgs e)
        {
            if (MessageBox.Show("Точно удалить?", "Уведомление", MessageBoxButton.YesNo) != MessageBoxResult.Yes)
                return;

            var sel = (sender as Button).DataContext as Stock;
            sel.MinCreateCount = 0;
            SaveSomeData.stocks.Remove(sel);
            SaveSomeData.productPage.SmallFrame.Navigate(new BookOrderPage());
           
            
        }

        private void ToDelBTN_Click(object sender, RoutedEventArgs e)
        {
            if (SaveSomeData.stocks.Count != 0)
            {
                if (MessageBox.Show("Точно офрмить заказ?", "Уведомление", MessageBoxButton.YesNo) == MessageBoxResult.Yes)
                {
                    Delivery delivery = new Delivery()
                    {
                        IdPointOfIssue = SaveSomeData.storeEmployee.IdpoinOfIssue
                    };
                    Connection.db.Delivery.Add(delivery);
                    foreach (var item in SaveSomeData.stocks)
                    {
                        DeliveryProducts deliveryProducts = new DeliveryProducts()
                        {
                            IdDelivery = delivery.Id,
                            IdStock = item.Id,
                            Count = item.MinCreateCount
                        };
                        Connection.db.DeliveryProducts.Add(deliveryProducts);
                        Connection.db.SaveChanges();
                    }
                    foreach (var item in SaveSomeData.stocks)
                    {
                        stock = Connection.db.Stock.ToList().Find(x => x.Id == item.Id);
                        DataContext = stock;
                        stock.MinCreateCount = 0;
                    }
                    Connection.db.SaveChanges();
                    SaveSomeData.stocks = null;
                    SaveSomeData.productPage.SmallFrame.Navigate(new BookOrderPage());
                }
            }
        }
    }
}
