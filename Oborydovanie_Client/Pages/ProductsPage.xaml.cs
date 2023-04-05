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
            List<string> sortList = new List<string>() { "по умолчанию" , "Цена ↑" , "Цена ↓" };
            SortCB.ItemsSource = sortList;
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
            SaveSomeData.stock = (sender as Button).DataContext as Stock;
            MessageBox.Show(((sender as Button).DataContext as Stock).Product.Name);
            SaveSomeData.main.MainFrame.Navigate(new RentPage());
        }
        private void Refresh()
        {
            IEnumerable<Stock> filter = Connection.db.Stock.Where(x => x.IdPoinOfIssue == SaveSomeData.point.Id);

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

            ProductList.ItemsSource = filter.ToList();
        }

        private void SearchTB_TextChanged(object sender, TextChangedEventArgs e)
        {
            Refresh();
        }

        private void MyRentsBTN_Click(object sender, RoutedEventArgs e)
        {

        }

        private void SortCB_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            Refresh();
        }
    }
}
