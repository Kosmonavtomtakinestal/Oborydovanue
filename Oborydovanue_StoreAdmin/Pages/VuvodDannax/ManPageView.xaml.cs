using Oborydovanue_Deliverier.DataBase;
using Oborydovanue_StoreAdmin.Pages.RedactDannax;
using Oborydovanue_StoreAdmin.Windows;
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

namespace Oborydovanue_StoreAdmin.Pages.VuvodDannax
{
    /// <summary>
    /// Логика взаимодействия для ManPageView.xaml
    /// </summary>
    public partial class ManPageView : Page
    {
        public ManPageView()
        {
            InitializeComponent();
            List<DataBase.Manager> managers = Connection.db.Manager.ToList();

            ManListView.ItemsSource =   managers;

            EditingElement.MouseDown += (sender, e) => { EditSupplier(); };
            DeletingElement.MouseDown += (sender, e) => { DeleteSupplier(); };
        }
        private void EditSupplier()
        {
            if (ManListView.SelectedItem == null)
            {
                return;
            }

            DataBase.Manager objectSupplier = ManListView.SelectedItem as DataBase.Manager;

            new Pages.RedactDannax.ManRedact(objectSupplier) { Owner = OrganizationPAgeWork.Instance }.Show();
            OrganizationPAgeWork.Instance.IsEnabled = false;
        }

        private void DeleteSupplier()
        {
            if (ManListView.SelectedItems == null || ManListView.SelectedItem == null)
            {
                return;
            }


            Connection.db.Manager.RemoveRange(ManListView.SelectedItems.Cast<DataBase.Manager>());
            Connection.db.SaveChanges();
            OrganizationPAgeWork.Instance.MainFrame.Navigate(new ManPageView());
        }
        public class ManInfo
        {
            public string Id { get; set; }
            public string Login { get; set; }
            public string Password { get; set; }
            public string Surname { get; set; }
            public string Name { get; set; }
            public string Patronymic { get; set; }

        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            new ManRedact() { Owner = OrganizationPAgeWork.Instance }.Show();
            OrganizationPAgeWork.Instance.IsEnabled = false;
        }
    }
}
