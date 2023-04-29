using Oborydovanue_Deliverier.DataBase;
using System.Collections.Generic;
using System.Linq;
using System.Windows;
using System.Windows.Controls;

namespace Oborydovanue_Manager.Pages
{
    /// <summary>
    /// Логика взаимодействия для SupplierPage.xaml
    /// </summary>
    public partial class SupplierPage : Page
    {

        public SupplierPage()
        {
            InitializeComponent();
            List<DataBase.Supplier> suppliers = Connection.db.Supplier.ToList();

            supplierListView.ItemsSource = suppliers;

            EditingElement.MouseDown += (sender, e) => { EditSupplier(); };
            DeletingElement.MouseDown += (sender, e) => { DeleteSupplier(); };
        }

        private void EditSupplier()
        {
            if (supplierListView.SelectedItem == null)
            {
                return;
            }

            DataBase.Supplier objectSupplier = supplierListView.SelectedItem as DataBase.Supplier;

            new DobavSupplier(objectSupplier) { Owner = ManagerWork.Instance }.Show();
            ManagerWork.Instance.IsEnabled = false;
        }

        private void DeleteSupplier()
        {
            if (supplierListView.SelectedItems == null || supplierListView.SelectedItem == null)
            {
                return;
            }


            _ = Connection.db.Supplier.RemoveRange(supplierListView.SelectedItems.Cast<DataBase.Supplier>());
            _ = Connection.db.SaveChanges();
            _ = ManagerWork.Instance.MainFrame.Navigate(new SupplierPage());
        }

        public class Supplier
        {
            public string Id { get; set; }
            public string Name { get; set; }
            public string Phone { get; set; }
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            new DobavSupplier() { Owner = ManagerWork.Instance }.Show();
            ManagerWork.Instance.IsEnabled = false;
        }
    }
}
