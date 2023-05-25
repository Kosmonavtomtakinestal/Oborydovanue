using Oborydovanue_Deliverier.DataBase;
using Oborydovanue_StoreAdmin.Pages.VuvodDannax;
using Oborydovanue_StoreAdmin.Windows;
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
using System.Windows.Shapes;

namespace Oborydovanue_StoreAdmin.Pages.RedactDannax
{
    /// <summary>
    /// Логика взаимодействия для StEplRedact.xaml
    /// </summary>
    public partial class StEplRedact : Window
    {
        private DataBase.StoreEmployee StoreEmployeeObject { get; set; }
        public StEplRedact(DataBase.StoreEmployee storeEmployee = null)
        {
            InitializeComponent();
            if (storeEmployee == null)
            {
                StoreEmployeeObject = new DataBase.StoreEmployee();
            }
            else
            {
                StoreEmployeeObject = storeEmployee;
                LoginRedact.Text = StoreEmployeeObject.Login;
                PassRedact.Text = StoreEmployeeObject.Password;
                SurRedact.Text = StoreEmployeeObject.Surname;
                NameRedact.Text = StoreEmployeeObject.Name;
                PatrRedact.Text = StoreEmployeeObject.Patronymic;
            }
            SaveChangesBtn.Click += (sender, e) => { SavingEndExiting(); };
        }
        private void SavingEndExiting()
        {
            SaveChanges();
            OrganizationPAgeWork.Instance.MainFrame.Navigate(new StoreEnpPage());
            Close();
        }
        private void SaveChanges()
        {
            StoreEmployeeObject.Login = LoginRedact.Text.Trim();
            StoreEmployeeObject.Password = PassRedact.Text.Trim();
                
            if (!Connection.db.StoreEmployee.ToList().Contains(StoreEmployeeObject))
            {
                _ = Connection.db.StoreEmployee.Add(StoreEmployeeObject);
            }

            _ = Connection.db.SaveChanges();
        }
        private void Window_Closing(object sender, System.ComponentModel.CancelEventArgs e)
        {
            OrganizationPAgeWork.Instance.IsEnabled = true;
        }
        private void LoginRedact_TextChanged(object sender, System.Windows.Controls.TextChangedEventArgs e)
        {
            Validating(sender, "^[a-zA-Z0-9]*$");
        }

        private void PassRedact_TextChanged(object sender, TextChangedEventArgs e)
        {
            Validating(sender, "^[a-zA-Z0-9]*$");
        }

        private void SurRedact_TextChanged(object sender, TextChangedEventArgs e)
        {
            Validating(sender, "^[а-яА-Я]*$");
        }

        private void NameRedact_TextChanged(object sender, TextChangedEventArgs e)
        {
            Validating(sender, "^[а-яА-Я]*$");
        }

        private void PatrRedact_TextChanged(object sender, TextChangedEventArgs e)
        {
            Validating(sender, "^[а-яА-Я]*$");
        }

        private static void Validating(object sender, string patternForRegex)
        {
            TextBox textBox = (TextBox)sender; string input = textBox.Text;
            // Паттерн для проверки латинских символов
            Regex regex = new Regex(patternForRegex);
            // Если не прошло проверку, то удаляем последний символ из текстбокса
            if (!regex.IsMatch(input))
            {
                int caretPosition = textBox.SelectionStart - 1;
                if (caretPosition >= 0)
                {
                    textBox.Text = textBox.Text.Remove(caretPosition, 1); textBox.SelectionStart = caretPosition;
                    textBox.SelectionLength = 0;
                }
            }
        }
    }
}
