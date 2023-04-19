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
            ProductTB.Text = SaveSomeData.stock.Product.Name;
            TimeStart.Text = DateTime.Now.ToShortDateString();
        }

        private void ToRentBTN_Click(object sender, RoutedEventArgs e)
        {
            if (TimeStart.Text.Trim() == "" || CountDay.Text.Trim() == "")
            {
                MessageBox.Show("Заполните все поля", "Уыедомление", MessageBoxButton.OK, MessageBoxImage.Information);
            }
            else if (StartTimeCalendar.SelectedDate < DateTime.Now.Date)
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
                    IdStock = SaveSomeData.stock.Id,
                    Returned = false
                };
                try
                {
                    Connection.db.Rent.Add(rent);
                    Connection.db.SaveChanges();
                    MessageBox.Show($"Заявка успешно оформлена\nПриходите в точку выдачи по адресу {SaveSomeData.point.Addres}", "Уведомление", MessageBoxButton.OK, MessageBoxImage.Information);
                }
                catch (Exception)
                {
                    MessageBox.Show("Неудача", "Уведомление", MessageBoxButton.OK, MessageBoxImage.Error);
                    return;
                    throw;
                }

                SaveSomeData.main.MainFrame.Navigate(new ProductsPage());

            }
        }

        private void BackBTN_Click(object sender, RoutedEventArgs e)
        {
            SaveSomeData.main.MainFrame.Navigate(new ProductsPage());
        }

        private void StartTimeCalendar_SelectedDatesChanged(object sender, SelectionChangedEventArgs e)
        {
            if (StartTimeCalendar.SelectedDate == null)
            {
                MessageBox.Show("Выберите дату", "Уведомление", MessageBoxButton.OK, MessageBoxImage.Information);
            }
            else if (StartTimeCalendar.SelectedDate < DateTime.Now.Date)
            { 
                MessageBox.Show("Выберите правильную дату", "Уведомление", MessageBoxButton.OK, MessageBoxImage.Information);
            }
            else if (StartTimeCalendar.SelectedDate.Value.DayOfWeek == DayOfWeek.Sunday)
            {
                MessageBox.Show("Воскресение - выходной", "Уведомление", MessageBoxButton.OK, MessageBoxImage.Information);
            }
            else
            {
                SelTime.Visibility = Visibility.Collapsed;
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
            if (!int.TryParse(e.Text, out int daysCount) || daysCount == 0)
                e.Handled = true;


            /*if (!(Char.IsDigit(e.Text, 0)))
            {
                e.Handled = true;
            }*/
        }

        private void SelDateBTN_Click(object sender, RoutedEventArgs e)
        {
            SelTime.Visibility = Visibility.Visible;
        }
    }
}
