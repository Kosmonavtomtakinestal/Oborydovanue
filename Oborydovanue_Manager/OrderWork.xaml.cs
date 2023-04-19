using Oborydovanue_Deliverier.DataBase;
using Oborydovanue_Manager.DataBase;
using Oborydovanue_Manager.Pages;
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
using System.Windows.Shapes;

namespace Oborydovanue_Manager
{
    /// <summary>
    /// Логика взаимодействия для OrderWork.xaml
    /// </summary>
    public partial class OrderWork : Window
    {
        public string ErrorText
        {
            get { return (string)GetValue(ErrorTextProperty); }
            set { SetValue(ErrorTextProperty, value); }
        }

        public static readonly DependencyProperty ErrorTextProperty =
            DependencyProperty.Register("ErrorText", typeof(string), typeof(OrderWork));

        public List<Supplier> Suppliers {  get; set; }

        public Order Order { get; private set; }
        public OrderWork(Order orderOut)
        {
            Suppliers = Connection.db.Supplier.ToList();

            Order = orderOut;

            InitializeComponent();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            if (SuppliersCb.SelectedItem == null)
            {
                ErrorText = "Поставщик не выбран";
                return;
            }

            Supply supply = new Supply()
            {
                Order = Order,
                IdStatus = 1,
                Supplier = SuppliersCb.SelectedItem as Supplier,
                Manager = SaveSomeData.manager
            };

            Connection.db.Supply.Add(supply);
            Connection.db.SaveChanges();
        }
    }
}
