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
    /// Логика взаимодействия для EngPageView.xaml
    /// </summary>
    public partial class EngPageView : Page
    {
        public EngPageView()
        {
            InitializeComponent();
            List<DataBase.Engineer> engineers = Connection.db.Engineer.ToList();

            EngineerListView.ItemsSource = engineers;

            EditingElement.MouseDown += (sender, e) => { EditSupplier(); };
            DeletingElement.MouseDown += (sender, e) => { DeleteSupplier(); };
        }
        private void EditSupplier()
        {
            if (EngineerListView.SelectedItem == null)
            {
                return;
            }

            DataBase.Engineer objectSupplier = EngineerListView.SelectedItem as DataBase.Engineer;

            new  Pages.RedactDannax.EngRedact(objectSupplier) { Owner = OrganizationPAgeWork.Instance }.Show();
            OrganizationPAgeWork.Instance.IsEnabled = false;
        }

        private void DeleteSupplier()
        {
            if (EngineerListView.SelectedItems == null || EngineerListView.SelectedItem == null)
            {
                return;
            }


           Connection.db.Engineer.RemoveRange(EngineerListView.SelectedItems.Cast<DataBase.Engineer>());
           Connection.db.SaveChanges();
           OrganizationPAgeWork.Instance.MainFrame.Navigate(new EngPageView());
        }
        public class EngInfo
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
            new EngRedact() { Owner = OrganizationPAgeWork.Instance }.Show();
            OrganizationPAgeWork.Instance.IsEnabled = false;
        }
    }
}
