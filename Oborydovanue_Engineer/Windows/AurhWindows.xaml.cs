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
using System.Windows.Shapes;
using Oborydovanue_Engineer.DataBase;

namespace Oborydovanue_Engineer.Windows
{
    /// <summary>
    /// Логика взаимодействия для AurhWindows.xaml
    /// </summary>
    public partial class AurhWindows : Window
    {
        public AurhWindows()
        {
            InitializeComponent();
        }
        private void Avtor_Click(object sender, RoutedEventArgs e)
        {
            if (LoginTb.Text.Trim() == "" || PasswordTb.Text.Trim() == "")
            {
                _ = MessageBox.Show("Заполните все поля", "Уведомления", MessageBoxButton.OK, MessageBoxImage.Information);
            }
            else
            {

                Engineer cd = Connection.db.Engineer.ToList().Find(x => x.Login == LoginTb.Text.Trim() && x.Password == PasswordTb.Text.Trim());
                SaveSomeData.engineer = cd;
                if (SaveSomeData.engineer != null)
                {
                    new OrganizationPAgeWork().Show();
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
