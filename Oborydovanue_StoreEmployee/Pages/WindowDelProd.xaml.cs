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
using System.Windows.Shapes;
using Oborydovanue_StoreEmployee.DataBase;

namespace Oborydovanue_StoreEmployee.Pages
{
    /// <summary>
    /// Логика взаимодействия для WindowDelProd.xaml
    /// </summary>
    public partial class WindowDelProd : Window
    {
        public static Stock stock;
        public WindowDelProd(Stock _stock)
        {
            InitializeComponent();
            stock = _stock;
            DataContext = stock;
        }

        private void YesBTN_Click(object sender, RoutedEventArgs e)
        {
            if (CountTB.Text.Trim() == "")
            {
                MessageBox.Show("Заполните поле", "", MessageBoxButton.OK);
            }
            else
            {
                stock.Count -= int.Parse(CountTB.Text);
                Connection.db.SaveChanges();
                SaveSomeData.productListPage.ProductList.ItemsSource = Connection.db.Stock.Where(x => x.IdPoinOfIssue == SaveSomeData.storeEmployee.IdpoinOfIssue).ToList();
                Close();
            }
        }

        private void Count_PreviewTextInput(object sender, TextCompositionEventArgs e)
        {
            if (!(Char.IsDigit(e.Text, 0)))
            {
                e.Handled = true;
            }
        }
    }
}
