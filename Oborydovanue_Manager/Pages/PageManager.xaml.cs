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
    /// Логика взаимодействия для PageManager.xaml
    /// </summary>
    public partial class PageManager : Page
    {
        public IEnumerable<Supply> OrderManager
        {
            get { return (IEnumerable<Supply>)GetValue(OrderManagerProperty); }
            set { SetValue(OrderManagerProperty, value); }
        }

        public static readonly DependencyProperty OrderManagerProperty =
            DependencyProperty.Register("OrderManager", typeof(IEnumerable<Supply>), typeof(PageManager));
        //public IEnumerable<Order> OrderMaterial
        //{
        //    get { return (IEnumerable<Order>)GetValue(OrderMaterialProperty); }
        //    set { SetValue(OrderMaterialProperty, value); }
        //}

        //public static readonly DependencyProperty OrderMaterialProperty =
        //    DependencyProperty.Register("OrderMaterial", typeof(IEnumerable<Order>), typeof(PageEng));

        public PageManager()
        {
            InitializeComponent();
            var db = Connection.db;
            db.Supplier.Load();
            db.Supply.Load();
            db.Order.Load();
            db.Material.Load();
            OrderManager
               = db.Supply.Local.Where(x => x.IdManager == SaveSomeData.manager.Id);
            //OrderMaterial = (IEnumerable<Order>)db.Order.ToList();

        }

        private void supplierListView_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        {
            if (supplierListView.SelectedItem == null) return;
            new OrderPage(supplierListView.SelectedItem as Order) { Owner = ManagerWork.Instance }.ShowDialog();
        }
    }
}
