using Oborydovanue_Deliverier.DataBase;
using Oborydovanue_StoreAdmin.DataBase;
using Oborydovanue_StoreAdmin.Pages.RedactDannax;
using Oborydovanue_StoreAdmin.Windows;
using System.Collections.Generic;
using System.Linq;
using System.Windows;
using System.Windows.Controls;

namespace Oborydovanue_StoreAdmin.Pages.VuvodDannax
{
    /// <summary>
    /// Логика взаимодействия для DeliveryPageAll.xaml
    /// </summary>
    public partial class DeliveryPageAll : Page
    {
        public IEnumerable<Delivery> Deliveries
        {
            get { return (IEnumerable<Delivery>)GetValue(DeliveriesProperty); }
            set { SetValue(DeliveriesProperty, value); }
        }

        public static readonly DependencyProperty DeliveriesProperty =
            DependencyProperty.Register("Deliveries", typeof(IEnumerable<Delivery>), typeof(DeliveryPageAll));


        public DeliveryPageAll()
        {
            Deliveries = Connection.db.Delivery.ToList();
            
            InitializeComponent();

            EditingElement.MouseDown += (sender, e) => { EditSupplier(); };
            DeletingElement.MouseDown += (sender, e) => { DeleteSupplier(); };
        }
        private void EditSupplier()
        {
            if (DelListView.SelectedItem == null)
            {
                return;
            }

            DataBase.Delivery objectDelivery = DelListView.SelectedItem as DataBase.Delivery;

            new Pages.RedactDannax.DeliverAllRedact(objectDelivery) { Owner = OrganizationPAgeWork.Instance }.Show();
            OrganizationPAgeWork.Instance.IsEnabled = false;
        }

        private void DeleteSupplier()
        {
            if (DelListView.SelectedItems == null || DelListView.SelectedItem == null)
            {
                return;
            }


            Connection.db.Delivery.RemoveRange(DelListView.SelectedItems.Cast<DataBase.Delivery>());
            Connection.db.SaveChanges();
            OrganizationPAgeWork.Instance.MainFrame.Navigate(new EngPageView());
        }

       
    }
}
