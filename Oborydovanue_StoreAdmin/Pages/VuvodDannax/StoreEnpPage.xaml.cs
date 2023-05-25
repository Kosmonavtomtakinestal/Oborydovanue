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
    /// Логика взаимодействия для StoreEnpPage.xaml
    /// </summary>
    public partial class StoreEnpPage : Page
    {
        public StoreEnpPage()
        {
            InitializeComponent();
            List<DataBase.StoreEmployee> storeEmployees = Connection.db.StoreEmployee.ToList();

            StoreEmpListView.ItemsSource = storeEmployees;

            EditingElement.MouseDown += (sender, e) => { EditSupplier(); };
            DeletingElement.MouseDown += (sender, e) => { DeleteSupplier(); };
        }
        private void EditSupplier()
        {
            if (StoreEmpListView.SelectedItem == null)
            {
                return;
            }

            DataBase.StoreEmployee objectSupplier = StoreEmpListView.SelectedItem as DataBase.StoreEmployee;

            new Pages.RedactDannax.StEplRedact(objectSupplier) { Owner = OrganizationPAgeWork.Instance }.Show();
            OrganizationPAgeWork.Instance.IsEnabled = false;
        }

        private void DeleteSupplier()
        {
            if (StoreEmpListView.SelectedItems == null || StoreEmpListView.SelectedItem == null)
            {
                return;
            }


            Connection.db.StoreEmployee.RemoveRange(StoreEmpListView.SelectedItems.Cast<DataBase.StoreEmployee>());
            Connection.db.SaveChanges();
            OrganizationPAgeWork.Instance.MainFrame.Navigate(new StoreEnpPage());
        }

        public class StEplInfo
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
            new StEplRedact() { Owner = OrganizationPAgeWork.Instance }.Show();
            OrganizationPAgeWork.Instance.IsEnabled = false;
        }
    }
}
