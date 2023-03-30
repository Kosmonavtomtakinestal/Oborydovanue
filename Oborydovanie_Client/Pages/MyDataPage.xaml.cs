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
    /// Логика взаимодействия для MyDataPage.xaml
    /// </summary>
    public partial class MyDataPage : Page
    {
        public static Client client;
        public int i;
        public MyDataPage(Client _client, int _i)
        {
            InitializeComponent();
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
            else if (PasswordTb.Text.Trim() != ReturnPasswordTb.Text.Trim())
            {
                MessageBox.Show("Пароли не совпадают", "Уведомление", MessageBoxButton.OK, MessageBoxImage.Information);
            }
            else
            {
                Connection.db.SaveChanges();
                MessageBox.Show("Успешно", "Уведомление", MessageBoxButton.OK, MessageBoxImage.Information);
            }
        }
    }
}
