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
    /// Логика взаимодействия для MyRents.xaml
    /// </summary>
    public partial class MyRents : Page
    {
        public MyRents()
        {
            InitializeComponent();
            RentList.ItemsSource = Connection.db.Rent.Where(x => x.IdClient == SaveSomeData.client.Id).ToList();
        }

        private void AccountBTN_Click(object sender, RoutedEventArgs e)
        {
            SaveSomeData.main.MainFrame.Navigate(new MyDataPage(SaveSomeData.client, 4));
        }

        private void PointBTN_Click(object sender, RoutedEventArgs e)
        {
            SaveSomeData.main.MainFrame.Navigate(new ChoosePointPage());
        }

        private void ProductBTN_Click(object sender, RoutedEventArgs e)
        {
            SaveSomeData.main.MainFrame.Navigate(new ProductsPage());
        }
    }
}
