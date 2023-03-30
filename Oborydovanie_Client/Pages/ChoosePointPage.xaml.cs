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
    /// Логика взаимодействия для ChoosePointPage.xaml
    /// </summary>
    public partial class ChoosePointPage : Page
    {
        public ChoosePointPage()
        {
            InitializeComponent();
            PointsCB.ItemsSource = Connection.db.PointOfIssue.ToList();
        }

        private void SelBTN_Click(object sender, RoutedEventArgs e)
        {
            if (PointsCB.SelectedItem == null)
            {
                MessageBox.Show("Выберите пункт выдачи", "Уведомление", MessageBoxButton.OK, MessageBoxImage.Information);
            }
            else
            {
                SaveSomeData.point = PointsCB.SelectedItem as PointOfIssue;
                SaveSomeData.main.MainFrame.Navigate(new ProductsPage());
            }
        }

        private void AccountBTN_Click(object sender, RoutedEventArgs e)
        {
            SaveSomeData.main.MainFrame.Navigate(new MyDataPage(SaveSomeData.client, 1));
        }
    }
}
