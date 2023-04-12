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
using Oborydovanue_StoreEmployee.DataBase;

namespace Oborydovanue_StoreEmployee.Pages
{
    /// <summary>
    /// Логика взаимодействия для AuthPage.xaml
    /// </summary>
    public partial class AuthPage : Page
    {
        public AuthPage()
        {
            InitializeComponent();
        }

        private void AuthBTN_Click(object sender, RoutedEventArgs e)
        {
            Auth();
        }

        private void Auth()
        {
            if (LoginTb.Text.Trim() == "" || PasswordTb.Text.Trim() == "")
            {
                MessageBox.Show("Заполните все поля", "Уведомления", MessageBoxButton.OK, MessageBoxImage.Information);
            }
            else
            {
                SaveSomeData.storeEmployee = Connection.db.StoreEmployee.ToList().Find(x => x.Login == LoginTb.Text.Trim() && x.Password == PasswordTb.Text.Trim());
                if (SaveSomeData.storeEmployee != null)
                {
                    SaveSomeData.main.MainFrame.Navigate(new ProductPage());
                }
                else
                {
                    MessageBox.Show("Не верно введены данные", "Уведомление", MessageBoxButton.OK, MessageBoxImage.Warning);
                }
            }
        }

        private void Page_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.Enter)
                Auth();
        }
    }
}
