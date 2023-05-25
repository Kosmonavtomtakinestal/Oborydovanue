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
using Oborydovanue_Engineer.DataBase;

namespace Oborydovanue_Engineer.Pages.VuvodDannax
{
    /// <summary>
    /// Логика взаимодействия для CompountPage.xaml
    /// </summary>
    public partial class CompountPage : Page
    {
        public IEnumerable<Delivery> Products => Connection.db.Delivery.Local;

        public CompountPage()
        {
            Connection.db.Product.Load();
            Connection.db.Compound.Load();

            InitializeComponent();
        }
    }
}
