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
    /// Логика взаимодействия для HistoryPage.xaml
    /// </summary>
    public partial class HistoryPage : Page
    {
        public IEnumerable<Supply> OrderManagerHistory
        {
            get { return (IEnumerable<Supply>)GetValue(OrderManagerHistoryProperty); }
            set { SetValue(OrderManagerHistoryProperty, value); }
        }

        // Using a DependencyProperty as the backing store for OrderManagerHistory.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty OrderManagerHistoryProperty =
            DependencyProperty.Register("OrderManagerHistory", typeof(IEnumerable<Supply>), typeof(HistoryPage));


        public HistoryPage()
        {
            InitializeComponent();
            var db = Connection.db;
            db.Supplier.Load();
            db.Supply.Load();
            db.Order.Load();
            db.Material.Load();
            OrderManagerHistory
               = db.Supply.Local.Where(x => x.IdManager == SaveSomeData.manager.Id && x.IdStatus == 3 );
        }
    }
}
