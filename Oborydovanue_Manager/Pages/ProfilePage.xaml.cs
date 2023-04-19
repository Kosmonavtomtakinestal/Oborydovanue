using Oborydovanue_Deliverier.DataBase;
using Oborydovanue_Manager.DataBase;
using System;
using System.Collections.Generic;
using System.Data.Entity;
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

namespace Oborydovanue_Manager.Pages
{
    /// <summary>
    /// Логика взаимодействия для ProfilePage.xaml
    /// </summary>
    public partial class ProfilePage : Page
    {
        public string NameManager
        {
            get { return (string)GetValue(NameManagerProperty); }
            set { SetValue(NameManagerProperty, value); }
        }

        public static readonly DependencyProperty NameManagerProperty =
            DependencyProperty.Register("NameManager", typeof(string), typeof(ProfilePage));

        public string Surname
        {
            get { return (string)GetValue(SurnameProperty); }
            set { SetValue(SurnameProperty, value); }
        }

        public static readonly DependencyProperty SurnameProperty =
            DependencyProperty.Register("Name", typeof(string), typeof(ProfilePage));

        public string Patronymic
        {
            get { return (string)GetValue(PatronymicProperty); }
            set { SetValue(PatronymicProperty, value); }
        }

        public static readonly DependencyProperty PatronymicProperty =
            DependencyProperty.Register("Patronymic", typeof(string), typeof(ProfilePage));






        public ProfilePage()
        {
            NameManager = SaveSomeData.manager.Name;
            Surname = SaveSomeData.manager.Surname;
            Patronymic = SaveSomeData.manager.Patronymic;
            InitializeComponent();
            var db = Connection.db;
       

            SavaChanges.Click += (sender, e) => 
            {
                
                SaveSomeData.manager.Name = NameManager;
                SaveSomeData.manager.Surname = Surname;
                SaveSomeData.manager.Patronymic = Patronymic;
                Connection.db.SaveChanges(); 
            };
        }
    }
        
    }

