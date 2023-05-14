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
using Oborydovanue_Engineer.Windows;

namespace Oborydovanue_Engineer.Pages.VuvodDannax
{
    /// <summary>
    /// Логика взаимодействия для CompountPage.xaml
    /// </summary>
    public partial class CompountPage : Page
    {
        public IEnumerable<Product> Products => Connection.db.Product.Local;

        public CompountPage()
        {
            Connection.db.Product.Load();
            Connection.db.Compound.Load();

            InitializeComponent();

            EditingElement.MouseDown += (sender, e) => { EditCompond(); };
        }

        private void EditCompond()
        {
            if (DelListView.SelectedItem == null)
            {
                return;
            }

            DataBase.Product objectProduct = DelListView.SelectedItem as DataBase.Product;

            new Pages.RedactDannax.EditCompoundWindow(objectProduct) { Owner = OrganizationPAgeWork.Instance }.Show();
            OrganizationPAgeWork.Instance.IsEnabled = false;
        }
    }
}
