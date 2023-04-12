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
    /// Логика взаимодействия для ProductListPage.xaml
    /// </summary>
    public partial class ProductListPage : Page
    {
        public ProductListPage()
        {
            InitializeComponent();
            SaveSomeData.productListPage = this;
            ProductList.ItemsSource = Connection.db.Stock.Where(x => x.IdPoinOfIssue == SaveSomeData.storeEmployee.IdpoinOfIssue).ToList();
        }

        private void EditBTN_Click(object sender, RoutedEventArgs e)
        {
            var sel = (sender as Button).DataContext as Stock;

        }

        private void ToDeliveryBTN_Click(object sender, RoutedEventArgs e)
        {
            var sel = (sender as Button).DataContext as Stock;
        }

    }
}
