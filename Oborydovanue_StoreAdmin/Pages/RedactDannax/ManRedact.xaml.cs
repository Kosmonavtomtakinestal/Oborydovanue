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
    /// Логика взаимодействия для ManRedact.xaml
    /// </summary>
    public partial class ManRedact : Window
    {
        private DataBase.Manager ManagerObject { get; set; }
        public ManRedact(DataBase.Manager manager = null)
        {
            InitializeComponent();
            if (manager == null)
            {
                ManagerObject = new DataBase.Manager();
            }
            else
            {
                ManagerObject = manager;
                LoginRedact.Text = ManagerObject.Login;
                PassRedact.Text = ManagerObject.Password;
                SurRedact.Text = ManagerObject.Surname;
                NameRedact.Text = ManagerObject.Name;
                PatrRedact.Text = ManagerObject.Patronymic;
            }
            SaveChangesBtn.Click += (sender, e) => { SavingEndExiting(); };
        }
        private void SavingEndExiting()
        {
            SaveChanges();
            OrganizationPAgeWork.Instance.MainFrame.Navigate(new ManPageView());
            Close();
        }
        private void SaveChanges()
        {
            ManagerObject.Login = LoginRedact.Text.Trim();
            ManagerObject.Password = PassRedact.Text.Trim();

            if (!Connection.db.Manager.ToList().Contains(ManagerObject))
            {
                _ = Connection.db.Manager.Add(ManagerObject);
            }

            _ = Connection.db.SaveChanges();
        }
        private void Window_Closing(object sender, System.ComponentModel.CancelEventArgs e)
        {
            OrganizationPAgeWork.Instance.IsEnabled = true;
        }
        private void LoginRedact_TextChanged(object sender, System.Windows.Controls.TextChangedEventArgs e)
        {
            TextBox textBox = (TextBox)sender; string input = textBox.Text;
            // Паттерн для проверки латинских символов
            Regex regex = new Regex("^[a-zA-Z0-9]*$");
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

        private void PassRedact_TextChanged(object sender, TextChangedEventArgs e)
        {
            TextBox textBox = (TextBox)sender; string input = textBox.Text;
            // Паттерн для проверки латинских символов
            Regex regex = new Regex("^[a-zA-Z0-9]*$");
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

        private void SurRedact_TextChanged(object sender, TextChangedEventArgs e)
        {
            TextBox textBox = (TextBox)sender; string input = textBox.Text;
            // Паттерн для проверки латинских символов
            Regex regex = new Regex("^[а-яА-Я]*$");
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



        private void NameRedact_TextChanged(object sender, TextChangedEventArgs e)
        {
            TextBox textBox = (TextBox)sender; string input = textBox.Text;
            // Паттерн для проверки латинских символов
            Regex regex = new Regex("^[а-яА-Я]*$");
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

        private void PatrRedact_TextChanged(object sender, TextChangedEventArgs e)
        {
            TextBox textBox = (TextBox)sender; string input = textBox.Text;
            // Паттерн для проверки латинских символов
            Regex regex = new Regex("^[а-яА-Я]*$");
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
