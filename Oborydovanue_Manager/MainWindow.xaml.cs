
using Oborydovanue_Deliverier.DataBase;
using Oborydovanue_Manager.Pages;
using System.Linq;
using System.Windows;

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
                _ = MessageBox.Show("Заполните все поля", "Уведомления", MessageBoxButton.OK, MessageBoxImage.Information);
            }
            else
            {

                DataBase.Manager cd = Connection.db.Manager.ToList().Find(x => x.Login == LoginTb.Text.Trim() && x.Password == PasswordTb.Text.Trim());
                SaveSomeData.manager = cd;
                if (SaveSomeData.manager != null)
                {
                    new ManagerWork().Show();
                    Close();
                }
                else
                {
                    _ = MessageBox.Show("Не верно введены данные", "Уведомление", MessageBoxButton.OK, MessageBoxImage.Warning);
                }
            }
        }
    }
}
