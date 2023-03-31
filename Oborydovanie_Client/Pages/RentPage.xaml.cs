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
                CostTB.Text = $"{int.Parse(CountHour.Text) * int.Parse(SaveSomeData.ProdToRent.Price)}";
                Rent rent = new Rent()
                {
                    
                };
                MessageBox.Show($"Заявка успешно оформлена\nПриходите в точку выдачи по адресу {SaveSomeData.point.Addres}", "Уведомление", MessageBoxButton.OK, MessageBoxImage.Information);
            }
        }

        private void BackBTN_Click(object sender, RoutedEventArgs e)
        {
            SaveSomeData.main.MainFrame.Navigate(new ProductsPage());
        }

        private void ReadyDateBTN_Click(object sender, RoutedEventArgs e)
        {
            SelTime.Visibility = Visibility.Collapsed;
            OneSP.Visibility = Visibility.Visible;
            TwoSP.Visibility = Visibility.Visible;
            ThreeSP.Visibility = Visibility.Visible;
            ToRentBTN.Visibility = Visibility.Visible;
        }

        private void ReadyDateBTN_MouseLeave(object sender, MouseEventArgs e)
        {
            
        }

        private void StartTimeCalendar_MouseLeave(object sender, MouseEventArgs e)
        {
            if (StartTimeCalendar.SelectedDate == null)
            {
                MessageBox.Show("Выберите дату", "Уведомление", MessageBoxButton.OK, MessageBoxImage.Information);
            }
            else if (StartTimeCalendar.SelectedDate <= DateTime.Now)
            {
                StartTimeCalendar.SelectedDate = null;
                MessageBox.Show("Выберите правильную дату", "Уведомление", MessageBoxButton.OK, MessageBoxImage.Information);
            }
            else if (StartTimeCalendar.SelectedDate.Value.DayOfWeek == DayOfWeek.Sunday)
            {
                StartTimeCalendar.SelectedDate = null;
                MessageBox.Show("Воскресение - выходной", "Уведомление", MessageBoxButton.OK, MessageBoxImage.Information);
            }
        }

        private void TimeStart_MouseDown(object sender, MouseButtonEventArgs e)
        {
            
        }

        private void TimeStart_MouseEnter(object sender, MouseEventArgs e)
        {
            SelTime.Visibility = Visibility.Visible;
            OneSP.Visibility = Visibility.Collapsed;
            TwoSP.Visibility = Visibility.Collapsed;
            ThreeSP.Visibility = Visibility.Collapsed;
            ToRentBTN.Visibility = Visibility.Collapsed;
        }
    }
}
