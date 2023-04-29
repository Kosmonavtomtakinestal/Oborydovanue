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
using System.Windows.Shapes;

namespace Oborydovanue_Manager.Pages
{
    /// <summary>
    /// Логика взаимодействия для OrderPage.xaml
    /// </summary>
    public partial class OrderPage : Window
    {

        public Order Order4len
        {
            get { return (Order)GetValue(Order4lenProperty); }
            set { SetValue(Order4lenProperty, value); }
        }

        public static readonly DependencyProperty Order4lenProperty =
            DependencyProperty.Register("Order4len", typeof(Order), typeof(OrderPage));

        public IEnumerable<Supplier> Suppliers
        {
            get { return (IEnumerable<Supplier>)GetValue(SuppliersProperty); }
            set { SetValue(SuppliersProperty, value); }
        }

        public static readonly DependencyProperty SuppliersProperty =
            DependencyProperty.Register("Suppliers", typeof(IEnumerable<Supplier>), typeof(OrderPage));

        public Manager Managers
        {
            get { return (Manager)GetValue(ManagersProperty); }
            set { SetValue(ManagersProperty, value); }
        }

        public static readonly DependencyProperty ManagersProperty =
            DependencyProperty.Register("Managers", typeof(Manager), typeof(OrderPage));

        public OrderPage( Order order)
        {
            Order4len = order;

            Suppliers = Connection.db.Supplier.ToList();

            InitializeComponent();

        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            if (Postavshic.SelectedItem == null) return;

            Supply supply = Connection.db.Supply.ToList().FirstOrDefault(x => x.IdOrder == Order4len.Id);

            supply.Manager = SaveSomeData.manager;
            supply.IdStatus = 1;
            supply.Supplier = Postavshic.SelectedItem as Supplier;

            Connection.db.SaveChanges();
            
            Close();
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            Close();
        }
    }
}
