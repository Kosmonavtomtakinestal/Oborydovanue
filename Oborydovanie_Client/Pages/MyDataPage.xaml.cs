using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
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
    /// Логика взаимодействия для MyDataPage.xaml
    /// </summary>
    public partial class MyDataPage : Page
    {
        public static Client client;
        public int i;
        public MyDataPage(Client _client, int _i)
        {
            InitializeComponent();
            if (_i == 3) LoginTb.IsEnabled = true;
            if (_i == 1 || _i == 2) ReturnPasswordTb.Text = PasswordTb.Text;
            client = _client;
            DataContext = client;
            i = _i;
        }

        private void BackBTN_Click(object sender, RoutedEventArgs e)
        {
            if (i == 1)
            {
                SaveSomeData.main.MainFrame.Navigate(new ChoosePointPage());
            }
            else if (i == 2)
            {
                SaveSomeData.main.MainFrame.Navigate(new ProductsPage());
            }
            else if (i == 3)
            {
                SaveSomeData.main.MainFrame.Navigate(new AuthPage());
            }
            else if (i == 4)
            {
                SaveSomeData.main.MainFrame.Navigate(new MyRents());
            }
        }

        private void SaveBTN_Click(object sender, RoutedEventArgs e)
        {
            if (LoginTb.Text.Trim() == "" || PasswordTb.Text.Trim() == "" ||
                ReturnPasswordTb.Text.Trim() == "" || SurnameTb.Text.Trim() == "" ||
                NameTb.Text.Trim() == "" || PatronymicTb.Text.Trim() == "" ||
                PassportTb.Text.Trim() == "" || PhoneTb.Text.Trim() == "")
            {
                MessageBox.Show("Заполните все поля", "Уведомление", MessageBoxButton.OK, MessageBoxImage.Information);
            }
            else if (LoginTb.Text.Trim().Length <= 3)
            {
                MessageBox.Show("Логин слишком короткий", "Уведомление", MessageBoxButton.OK, MessageBoxImage.Information);
            }
            else if (PasswordTb.Text.Trim().Length <= 3)
            {
                MessageBox.Show("Логин слишком короткий", "Уведомление", MessageBoxButton.OK, MessageBoxImage.Information);
            }
            else if (PasswordTb.Text.Trim() != ReturnPasswordTb.Text.Trim())
            {
                MessageBox.Show("Пароли не совпадают", "Уведомление", MessageBoxButton.OK, MessageBoxImage.Information);
            }
            else
            {
                MessageBox.Show("Успешно", "Уведомление", MessageBoxButton.OK, MessageBoxImage.Information);
                if (i == 3)
                {
                    Connection.db.Client.Add(client);
                    Connection.db.SaveChanges();
                    SaveSomeData.main.MainFrame.Navigate(new AuthPage());
                }
            }
        }

        private void RusSumb_KeyDown(object sender, KeyEventArgs e)
        {
            
        }

        private void EngSumb_TextChanged(object sender, TextChangedEventArgs e)
        {
            TextBox textBox = (TextBox)sender;
            string input = textBox.Text;

            // Паттерн для проверки латинских символов
            Regex regex = new Regex("^[a-zA-Z0-9]*$");

            // Если не прошло проверку, то удаляем последний символ из текстбокса
            if (!regex.IsMatch(input))
            {
                int caretPosition = textBox.SelectionStart - 1;
                if (caretPosition >= 0)
                {
                    textBox.Text = textBox.Text.Remove(caretPosition, 1);
                    textBox.SelectionStart = caretPosition;
                    textBox.SelectionLength = 0;
                }
            }
        }

        private void RusSumb_TextChanged(object sender, TextChangedEventArgs e)
        {
            TextBox textBox = (TextBox)sender;
            string input = textBox.Text;

            // Паттерн для проверки латинских символов
            Regex regex = new Regex("^[а-яА-Я]*$");

            // Если не прошло проверку, то удаляем последний символ из текстбокса
            if (!regex.IsMatch(input))
            {
                int caretPosition = textBox.SelectionStart - 1;
                if (caretPosition >= 0)
                {
                    textBox.Text = textBox.Text.Remove(caretPosition, 1);
                    textBox.SelectionStart = caretPosition;
                    textBox.SelectionLength = 0;
                }
            }
        }
    }
}
