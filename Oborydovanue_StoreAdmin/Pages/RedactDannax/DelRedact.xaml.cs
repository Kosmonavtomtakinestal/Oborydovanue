using Oborydovanue_Deliverier.DataBase;
using Oborydovanue_StoreAdmin.Pages.VuvodDannax;
using Oborydovanue_StoreAdmin.Windows;
using System.Linq;
using System.Text.RegularExpressions;
using System.Windows;
using System.Windows.Controls;

namespace Oborydovanue_StoreAdmin.Pages.RedactDannax
{
    /// <summary>
    /// Логика взаимодействия для DelRedact.xaml
    /// </summary>
    public partial class DelRedact : Window
    {
        private DataBase.Deliverier DeliverierObject { get; set; }
        public DelRedact(DataBase.Deliverier deliverier = null)
        {
            InitializeComponent();
            if (deliverier == null)
            {
                DeliverierObject = new DataBase.Deliverier();
            }
            else
            {
                DeliverierObject = deliverier;
                LoginRedact.Text = DeliverierObject.Login;
                PassRedact.Text = DeliverierObject.Password;
                SurRedact.Text = DeliverierObject.Surname;
                NameRedact.Text = DeliverierObject.Name;
                PatrRedact.Text = DeliverierObject.Patronymic;
            }
            SaveChangesBtn.Click += (sender, e) => { SavingEndExiting(); };
        }
        private void SavingEndExiting()
        {
            SaveChanges();
            OrganizationPAgeWork.Instance.MainFrame.Navigate(new DelPage());
            Close();
        }
        private void SaveChanges()
        {
            DeliverierObject.Login = LoginRedact.Text.Trim();
            DeliverierObject.Password = PassRedact.Text.Trim();

            if (!Connection.db.Deliverier.ToList().Contains(DeliverierObject))
            {
                Connection.db.Deliverier.Add(DeliverierObject);
            }

            Connection.db.SaveChanges();
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
