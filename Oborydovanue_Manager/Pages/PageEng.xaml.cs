using Oborydovanue_Deliverier.DataBase;
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


namespace Oborydovanue_Manager.Pages
{
    /// <summary>
    /// Логика взаимодействия для PageEng.xaml
    /// </summary>
    public partial class PageEng : Page
    {
        public PageEng()
        {
            InitializeComponent();

            var db = Connection.db;

            var ordersNotInSupply
                = db.Order.Where(o => db.Supply.Any(s => s.IdOrder != o.Id));
            ListEng.ItemsSource = ordersNotInSupply;
        }
    }
}
