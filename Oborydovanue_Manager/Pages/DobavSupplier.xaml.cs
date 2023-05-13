using Oborydovanue_Deliverier.DataBase;
using System.Linq;
using System.Windows;

namespace Oborydovanue_Manager.Pages
{
    /// <summary>
    /// Логика взаимодействия для DobavSupplier.xaml
    /// </summary>
    public partial class DobavSupplier : Window
    {
        private DataBase.Supplier SupplierObject { get; set; }

        public DobavSupplier(DataBase.Supplier supplier = null)
        {
            InitializeComponent();
            if (supplier == null)
            {
                SupplierObject = new DataBase.Supplier();
            }
            else
            {
                SupplierObject = supplier;
                NameSuplier.Text = SupplierObject.Name;
                PhoneSuplier.Text = SupplierObject.Phone;
            }
            SaveChangesBtn.Click += (sender, e) => { SavingEndExiting(); };
        }

        private void SavingEndExiting()
        {
            SaveChanges();
            ManagerWork.Instance.MainFrame.Navigate(new SupplierPage());
            Close();
        }

        private void SaveChanges()
        {
            SupplierObject.Name = NameSuplier.Text.Trim();
            SupplierObject.Phone = PhoneSuplier.Text.Trim();

            if (!Connection.db.Supplier.ToList().Contains(SupplierObject))
            {
                _ = Connection.db.Supplier.Add(SupplierObject);
            }

            _ = Connection.db.SaveChanges();
        }
        private void Window_Closing(object sender, System.ComponentModel.CancelEventArgs e)
        {
            OrganizationPAgeWork.Instance.IsEnabled = true;
        }
    }
}
