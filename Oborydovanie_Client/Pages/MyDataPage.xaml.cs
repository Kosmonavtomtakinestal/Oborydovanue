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
        public class NewClient
        {
            public int Id { get; set; }
            public string Login { get; set; }
            public string Password { get; set; }
            public string Passport { get; set; }
            public string Phone { get; set; }
            public string Surname { get; set; }
            public string Name { get; set; }
            public string Patronymic { get; set; }
        }
        
        public static Client client;
        public static NewClient client1 = new NewClient();
        public int i;

        public static bool Proverka(Client client, NewClient client1)
        {
            if (client.Id == client1.Id && client.Login == client1.Login && client.Password == client1.Password && client.Passport == client1.Passport
                && client.Phone == client1.Phone && client.Surname == client1.Surname && client.Name == client1.Name && client.Patronymic == client1.Patronymic)
            {
                return false;
            }
            else { return true; }
        }

        public static Client Prirav(Client client, NewClient client1)
        {
            client.Id = client1.Id;
            client.Login = client1.Login;
            client.Password = client1.Password;
            client.Passport = client1.Passport;
            client.Phone = client1.Phone;
            client.Surname = client1.Surname;
            client.Name = client1.Name;
            client.Patronymic = client1.Patronymic;
            return client;
        }

        public MyDataPage(Client _client, int _i)
        {
            InitializeComponent();
            if (_i == 3) LoginTb.IsEnabled = true;
            if (_i == 1 || _i == 2) ReturnPasswordTb.Text = PasswordTb.Text;
            client = _client;
            client1.Id = client.Id; 
            client1.Login = client.Login; 
            client1.Password = client.Password; 
            client1.Passport = client.Passport; 
            client1.Phone = client.Phone; 
            client1.Surname = client.Surname; 
            client1.Name = client.Name; 
            client1.Patronymic = client.Patronymic; 
            DataContext = client;
            i = _i;
        }

        private void BackBTN_Click(object sender, RoutedEventArgs e)
        {
            if (i == 1)
            {
                if (Proverka(client, client1))
                {
                    DataContext = Prirav(client, client1);
                }
                SaveSomeData.main.MainFrame.Navigate(new ChoosePointPage());
            }
            else if (i == 2)
            {
                if (Proverka(client, client1))
                {
                    DataContext = Prirav(client, client1);
                }
                SaveSomeData.main.MainFrame.Navigate(new ProductsPage());
            }
            else if (i == 3)
            {
                if (Proverka(client, client1))
                {
                    DataContext = Prirav(client, client1);
                }
                SaveSomeData.main.MainFrame.Navigate(new AuthPage());
            }
            else if (i == 4)
            {
                if (Proverka(client, client1))
                {
                    DataContext = Prirav(client, client1);
                }
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

        private void ExitBTN_Click(object sender, RoutedEventArgs e)
        {

        }
    }
}
