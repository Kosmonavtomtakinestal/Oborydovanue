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

namespace Oborydovanie_Client.Pages
{
    /// <summary>
    /// Логика взаимодействия для RentPage.xaml
    /// </summary>
    public partial class RentPage : Page
    {
        public RentPage()
        {
            InitializeComponent();
        }

        private void ToRentBTN_Click(object sender, RoutedEventArgs e)
        {
            if (TimeStart.Text.Trim() == "" || CountHour.Text.Trim() == "")
            {
                MessageBox.Show("Заполните все поля", "Уыедомление", MessageBoxButton.OK, MessageBoxImage.Information);
            }
            else
            {
                MessageBox.Show($"Заявка успешно оформлена\nПриходите в точку выдачи по адресу {SaveSomeData.point.Addres}", "Уведомление", MessageBoxButton.OK, MessageBoxImage.Information);
            }
        }

        private void BackBTN_Click(object sender, RoutedEventArgs e)
        {
            SaveSomeData.main.MainFrame.Navigate(new ProductsPage());
        }
    }
}
