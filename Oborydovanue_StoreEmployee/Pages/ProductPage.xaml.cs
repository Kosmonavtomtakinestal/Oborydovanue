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
using Oborydovanue_StoreEmployee.Pages.PageItems;

namespace Oborydovanue_StoreEmployee.Pages
{
    /// <summary>
    /// Логика взаимодействия для ProductPage.xaml
    /// </summary>
    public partial class ProductPage : Page
    {
        public ProductPage()
        {
            InitializeComponent();
            SaveSomeData.productPage = this;
            SmallFrame.Navigate(new ProductListPage());
            List<string> sortList = new List<string>() { "по умолчанию", "Цена ↑", "Цена ↓" };
            SortCB.ItemsSource = sortList;
        }
        private void Refresh()
        {
            IEnumerable<Stock> filter = Connection.db.Stock.Where(x => x.IdPoinOfIssue == SaveSomeData.storeEmployee.IdpoinOfIssue);

            if (SortCB.SelectedIndex > 0)
            {
                if (SortCB.SelectedIndex == 1)
                    filter = filter.OrderBy(x => x.Product.Price);
                else if (SortCB.SelectedIndex == 2)
                    filter = filter.OrderByDescending(x => x.Product.Price);
            }

            if (SearchTB.Text.Length > 0)
            {
                filter = filter.Where(x => x.Product.Name.ToLower().Contains(SearchTB.Text.ToLower()) || x.Product.Discription.ToLower().Contains(SearchTB.Text.ToLower()));
            }

            SaveSomeData.productListPage.ProductList.ItemsSource = filter.ToList();
        }

        private void SearchTB_TextChanged(object sender, TextChangedEventArgs e)
        {
            Refresh();
        }

        private void SortCB_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            Refresh();
        }

        private void ProdToDel_Click(object sender, RoutedEventArgs e)
        {
            SaveSomeData.productPage.SmallFrame.Navigate(new BookOrderPage());
        }

        private void MyRentsBTN_Click(object sender, RoutedEventArgs e)
        {
            SaveSomeData.productPage.SmallFrame.Navigate(new ProductListPage());
        }

        private void CliOrders_Click(object sender, RoutedEventArgs e)
        {
            SaveSomeData.productPage.SmallFrame.Navigate(new ClientRentsPage());
        }

        private void OurDelBTN_Click(object sender, RoutedEventArgs e)
        {
            SaveSomeData.productPage.SmallFrame.Navigate(new OurDeliveryPage());
        }
    }
}
