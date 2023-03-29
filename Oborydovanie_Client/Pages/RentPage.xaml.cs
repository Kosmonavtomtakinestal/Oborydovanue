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

        private void SetTime_Click(object sender, RoutedEventArgs e)
        {
            if (StartCal.SelectedDate == null || EndCal.SelectedDate == null)
            {
                MessageBox.Show("Выберите все даты", "Уведомление", MessageBoxButton.OK, MessageBoxImage.Information);
            }
            else
            {
                TimeStart.Text = StartCal.SelectedDate.ToString();
                TimeEnd.Text = EndCal.SelectedDate.ToString();
                RentMenu.Visibility = Visibility.Visible;
                CalMenu.Visibility = Visibility.Collapsed;
            }
        }

        private void AccountBTN_Click(object sender, RoutedEventArgs e)
        {

        }

        private void PointBTN_Click(object sender, RoutedEventArgs e)
        {

        }

        private void TimeStart_TextChanged(object sender, TextChangedEventArgs e)
        {
            RentMenu.Visibility = Visibility.Collapsed;
            CalMenu.Visibility = Visibility.Visible;
        }
    }
}
