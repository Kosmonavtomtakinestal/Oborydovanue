using Oborydovanue_Deliverier.DataBase;
using Oborydovanue_Manager.Pages;
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

namespace Oborydovanue_Manager
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            SaveSomeData.main = this;
           
        }
        private void Avtor_Click(object sender, RoutedEventArgs e)
        {
            if (LoginTb.Text.Trim() == "" || PasswordTb.Text.Trim() == "")
            {
                MessageBox.Show("Заполните все поля", "Уведомления", MessageBoxButton.OK, MessageBoxImage.Information);
            }
            else
            {

                SaveSomeData.manager = Connection.db.Manager.ToList().Find(x => x.Login == LoginTb.Text.Trim() && x.Password == PasswordTb.Text.Trim());
                if (SaveSomeData.manager != null)
                {
                    new ManagerWork().Show();
                   Close();
                }
                else
                {
                    MessageBox.Show("Не верно введены данные", "Уведомление", MessageBoxButton.OK, MessageBoxImage.Warning);
                }
            }
        }
    }
}
