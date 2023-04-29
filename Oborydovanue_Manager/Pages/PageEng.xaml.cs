using Oborydovanue_Deliverier.DataBase;
using Oborydovanue_Manager.DataBase;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
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
    /// Логика взаимодействия для PageEng.xaml
    /// </summary>
    public partial class PageEng : Page
    {
        public IEnumerable<Order> OrderNotInSupply
        {
            get { return (IEnumerable<Order>)GetValue(OrderNotInSupplyProperty); }
            set { SetValue(OrderNotInSupplyProperty, value); }
        }

        public static readonly DependencyProperty OrderNotInSupplyProperty =
            DependencyProperty.Register("OrderNotInSupply", typeof(IEnumerable<Order>), typeof(PageEng));


        public PageEng()
        {
            InitializeComponent();
        
            var db = Connection.db;

            db.Supplier.Load();
            db.Order.Load();
            db.Material.Load();

            OrderNotInSupply
                = db.Order.Local.Where(x => x.Supply.FirstOrDefault(s => s.IdManager == null) != null);
        }

        private void Button_Click(object sender, RoutedEventArgs e) =>
            new OrderWork((sender as Button).DataContext as Order).ShowDialog();

        private void EngListView_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        {
            if (EngListView.SelectedItem == null) return;

            new OrderPage(EngListView.SelectedItem as Order).ShowDialog();

            OrderNotInSupply
                = Connection.db.Order.Local.Where(x => x.Supply.FirstOrDefault(s => s.IdManager == null) != null);
        }
    }
}
