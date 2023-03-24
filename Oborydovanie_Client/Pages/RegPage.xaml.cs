using System;
using System.Collections.Generic;
using System.Data.Common;
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
    /// Логика взаимодействия для RegPage.xaml
    /// </summary>
    public partial class RegPage : Page
    {
        public RegPage()
        {
            InitializeComponent();
        }

        private void BackBTN_Click(object sender, RoutedEventArgs e)
        {
            SaveSomeData.main.MainFrame.Navigate(new AuthPage());
        }

        private void RegBTN_Click(object sender, RoutedEventArgs e)
        {
            if (LoginTb.Text.Trim() == "" || PasswordTb.Text.Trim() == "" ||
                ReturnPasswordTb.Text.Trim() == "" || SurnameTb.Text.Trim() == "" ||
                NameTb.Text.Trim() == "" || PatronymicTb.Text.Trim() == "" ||
                PassportTb.Text.Trim() == "" || PhoneTb.Text.Trim() == "")
            {
                MessageBox.Show("Заполните все поля", "Уведомление", MessageBoxButton.OK, MessageBoxImage.Information);
            }
            else if (PasswordTb.Text.Trim() != ReturnPasswordTb.Text.Trim())
            {
                MessageBox.Show("Пароли не совпадают", "Уведомление", MessageBoxButton.OK, MessageBoxImage.Information);
            }
            else if (Connection.db.Client.ToList().Find(x => x.Login == LoginTb.Text.Trim()) != null)
            {
                MessageBox.Show("Такой логин уже существует", "Уведомление", MessageBoxButton.OK, MessageBoxImage.Information);
            }
            else 
            {
                Client client = new Client()
                {
                    Login = LoginTb.Text,
                    Password = PasswordTb.Text,
                    Surname = SurnameTb.Text,
                    Name = NameTb.Text,
                    Patronymic = PatronymicTb.Text,
                    Phone = PhoneTb.Text,
                    Passport = PassportTb.Text
                };
                Connection.db.Client.Add(client);
                Connection.db.SaveChanges();
                MessageBox.Show("Успешно", "Уведомление", MessageBoxButton.OK, MessageBoxImage.Information);
                SaveSomeData.main.MainFrame.Navigate(new AuthPage());
            }

        }
    }
}
