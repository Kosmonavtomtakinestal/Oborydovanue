using Oborydovanue_Deliverier.DataBase;
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

namespace Oborydovanue_Deliverier.Pages
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

        private void Avtor_Click(object sender, RoutedEventArgs e)
        {
            if (LoginTb.Text.Trim() == "" || PasswordTb.Text.Trim() == "")
            {
                MessageBox.Show("Заполните все поля", "Уведомления", MessageBoxButton.OK, MessageBoxImage.Information);
            }
            else
            {
                SaveSomeData.deliverier = Connection.db.Deliverier.ToList().Find(x => x.Login == LoginTb.Text.Trim() || x.Password == PasswordTb.Text.Trim());
                if (SaveSomeData.deliverier != null)
                {
                    SaveSomeData.main.MainFrame.Navigate(new DeliveriesPage());
                }
                else
                {
                    MessageBox.Show("Не верно введены данные", "Уведомление", MessageBoxButton.OK, MessageBoxImage.Warning);
                }
            }
        }
    }
}
