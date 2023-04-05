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
            if (TimeStart.Text.Trim() == "" || CountDay.Text.Trim() == "")
            {
                MessageBox.Show("Заполните все поля", "Уыедомление", MessageBoxButton.OK, MessageBoxImage.Information);
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
            else if ((int)(StartTimeCalendar.SelectedDate.Value.DayOfWeek + int.Parse(CountDay.Text)) == 7)
            {
                MessageBox.Show("Дата возврата попадает на воскресение", "Уведомление", MessageBoxButton.OK, MessageBoxImage.Information);
            }
            else
            {
                Rent rent = new Rent()
                {
                    Date = StartTimeCalendar.SelectedDate.Value,
                    RentTime = int.Parse(CountDay.Text.Trim()),
                    IdClient = SaveSomeData.client.Id,
                    IdStock = SaveSomeData.stock.Id

                };
                try
                {
                    Connection.db.Rent.Add(rent);
                    Connection.db.SaveChanges();
                }
                catch (Exception)
                {
                    MessageBox.Show("Неудача", "Уведомление", MessageBoxButton.OK, MessageBoxImage.Error);
                    return;
                    throw;
                }
                MessageBox.Show($"Заявка успешно оформлена\nПриходите в точку выдачи по адресу {SaveSomeData.point.Addres}", "Уведомление", MessageBoxButton.OK, MessageBoxImage.Information);

                SaveSomeData.main.MainFrame.Navigate(new ProductsPage());

            }
        }

        private void BackBTN_Click(object sender, RoutedEventArgs e)
        {
            SaveSomeData.main.MainFrame.Navigate(new ProductsPage());
        }

        private void ReadyDateBTN_MouseLeave(object sender, MouseEventArgs e)
        {
            
        }

        private void TimeStart_MouseDown(object sender, MouseButtonEventArgs e)
        {
            SelTime.Visibility = Visibility.Visible;
            OneSP.Visibility = Visibility.Collapsed;
            TwoSP.Visibility = Visibility.Collapsed;
            ThreeSP.Visibility = Visibility.Collapsed;
            ToRentBTN.Visibility = Visibility.Collapsed;
        }

        private void StartTimeCalendar_SelectedDatesChanged(object sender, SelectionChangedEventArgs e)
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
            else
            {
                SelTime.Visibility = Visibility.Collapsed;
                OneSP.Visibility = Visibility.Visible;
                TwoSP.Visibility = Visibility.Visible;
                ThreeSP.Visibility = Visibility.Visible;
                ToRentBTN.Visibility = Visibility.Visible;
                TimeStart.Text = StartTimeCalendar.SelectedDate.Value.ToShortDateString();
            }
        }

        private void CountDay_TextChanged(object sender, TextChangedEventArgs e)
        {
            if (CountDay.Text.Trim() != "")
            {
                CostTB.Text = (int.Parse(CountDay.Text) * int.Parse(SaveSomeData.stock.Product.Price)).ToString();
            }
        }

        private void CountDay_PreviewTextInput(object sender, TextCompositionEventArgs e)
        {
            if (!(Char.IsDigit(e.Text, 0)))
            {
                e.Handled = true;
            }
        }
    }
}
