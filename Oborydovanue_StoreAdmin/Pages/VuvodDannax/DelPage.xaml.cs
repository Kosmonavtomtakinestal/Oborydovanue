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
    /// Логика взаимодействия для DelPage.xaml
    /// </summary>
    public partial class DelPage : Page
    {
        public DelPage()
        {
            InitializeComponent();
            List<DataBase.Deliverier> deliveriers = Connection.db.Deliverier.ToList();

            DelListView.ItemsSource = deliveriers;

            EditingElement.MouseDown += (sender, e) => { EditSupplier(); };
            DeletingElement.MouseDown += (sender, e) => { DeleteSupplier(); };
        }
        private void EditSupplier()
        {
            if (DelListView.SelectedItem == null)
            {
                return;
            }

            DataBase.Deliverier objectSupplier = DelListView.SelectedItem as DataBase.Deliverier;

            new Pages.RedactDannax.DelRedact(objectSupplier) { Owner = OrganizationPAgeWork.Instance }.Show();
            OrganizationPAgeWork.Instance.IsEnabled = false;
        }

        private void DeleteSupplier()
        {
            if (DelListView.SelectedItems == null || DelListView.SelectedItem == null)
            {
                return;
            }


            Connection.db.Deliverier.RemoveRange(DelListView.SelectedItems.Cast<DataBase.Deliverier>());
            Connection.db.SaveChanges();
            OrganizationPAgeWork.Instance.MainFrame.Navigate(new EngPageView());
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
            new DelRedact() { Owner = OrganizationPAgeWork.Instance }.Show();
            OrganizationPAgeWork.Instance.IsEnabled = false;
        }
    }
}
