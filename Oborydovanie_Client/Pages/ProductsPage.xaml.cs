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
using Oborydovanie_Client.DataBase;
using Oborydovanie_Client.Properties;

namespace Oborydovanie_Client.Pages
{
    /// <summary>
    /// Логика взаимодействия для ProductsPage.xaml
    /// </summary>
    public partial class ProductsPage : Page
    {
        public ProductsPage()
        {
            InitializeComponent();
            ProductList.ItemsSource = Connection.db.Stock.ToList().Where(x => x.IdPoinOfIssue == SaveSomeData.point.Id);
        }

        private void AccountBTN_Click(object sender, RoutedEventArgs e)
        {
            SaveSomeData.main.MainFrame.Navigate(new MyDataPage(SaveSomeData.client, 2));
        }

        private void PointBTN_Click(object sender, RoutedEventArgs e)
        {
            SaveSomeData.main.MainFrame.Navigate(new ChoosePointPage());
        }

        private void ToRentBTN_Click(object sender, RoutedEventArgs e)
        {
            SaveSomeData.ProdToRent = (sender as Button).DataContext as Product;
            SaveSomeData.main.MainFrame.Navigate(new RentPage());
        }
        private void Refresh()
        {
            IEnumerable<Stock> filter = Connection.db.Stock.Where(x => x.IdPoinOfIssue == SaveSomeData.point.Id);

            //if (ComboSort.SelectedIndex > 0)
            //{
            //    if (ComboSort.SelectedIndex == 1)
            //        filter = filter.OrderBy(x => x.Name);
            //    else if (ComboSort.SelectedIndex == 2)
            //        filter = filter.OrderByDescending(x => x.Name);

            //}

            if (SearchTB.Text.Length > 0)
            {
                filter = filter.Where(x => x.Product.Name.ToLower().Contains(SearchTB.Text.ToLower()) || x.Product.Discription.ToLower().Contains(SearchTB.Text.ToLower()));
            }

            ProductList.ItemsSource = filter.ToList();
        }

        private void SearchTB_TextChanged(object sender, TextChangedEventArgs e)
        {
            Refresh();
        }
    }
}
