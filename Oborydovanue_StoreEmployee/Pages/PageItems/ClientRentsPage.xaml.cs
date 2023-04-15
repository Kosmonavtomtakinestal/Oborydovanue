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
    /// Логика взаимодействия для ClientRentsPage.xaml
    /// </summary>
    public partial class ClientRentsPage : Page
    {
        public ClientRentsPage()
        {
            InitializeComponent();
            RentList.ItemsSource = Connection.db.Rent.Where(x => x.Stock.IdPoinOfIssue == SaveSomeData.storeEmployee.IdpoinOfIssue && x.Returned == false).ToList();
        }

        private void GetToCliBTN_Click(object sender, RoutedEventArgs e)
        {
            var sel = (sender as Button).DataContext as Rent;
            sel.IdStoreEmployee = SaveSomeData.storeEmployee.Id;
            Connection.db.SaveChanges();
            RentList.ItemsSource = Connection.db.Rent.Where(x => x.Stock.IdPoinOfIssue == SaveSomeData.storeEmployee.IdpoinOfIssue && x.Returned == false).ToList();
        }

        private void ReturnProd_Click(object sender, RoutedEventArgs e)
        {
            var sel = (sender as Button).DataContext as Rent;
            sel.Returned = true;
            Connection.db.SaveChanges();
            RentList.ItemsSource = Connection.db.Rent.Where(x => x.Stock.IdPoinOfIssue == SaveSomeData.storeEmployee.IdpoinOfIssue && x.Returned == false).ToList();
        }
    }
}
