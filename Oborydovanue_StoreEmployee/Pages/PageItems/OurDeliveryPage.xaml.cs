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
using Oborydovanue_StoreEmployee.DataBase;

namespace Oborydovanue_StoreEmployee.Pages.PageItems
{
    /// <summary>
    /// Логика взаимодействия для OurDeliveryPage.xaml
    /// </summary>
    public partial class OurDeliveryPage : Page
    {
        public IEnumerable<Delivery> Deliveries => Connection.db.Delivery.Local.Where(x => x.IdPointOfIssue == SaveSomeData.storeEmployee.IdpoinOfIssue);
        public OurDeliveryPage()
        {
            Connection.db.Delivery.Load();
            Connection.db.Delivered.Load();

            InitializeComponent();
            DelList.ItemsSource = Connection.db.Delivery.Where(x => x.IdPointOfIssue == SaveSomeData.storeEmployee.IdpoinOfIssue).ToList();
        }

        private void ReadyDeliveryBTN_Click(object sender, RoutedEventArgs e)
        {

        }
    }
}
