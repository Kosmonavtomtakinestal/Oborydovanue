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
using Oborydovanie_Client.DataBase;

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

        }

        private void PointBTN_Click(object sender, RoutedEventArgs e)
        {

        }

        private void ToRentBTN_Click(object sender, RoutedEventArgs e)
        {
            SaveSomeData.ProdToRent = (sender as Button).DataContext as Product;
            SaveSomeData.main.MainFrame.Navigate(new RentPage());
        }
    }
}
