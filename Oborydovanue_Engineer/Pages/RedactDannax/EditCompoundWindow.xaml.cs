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
using Oborydovanue_Engineer.DataBase;
using Oborydovanue_Engineer.Windows;

namespace Oborydovanue_Engineer.Pages.RedactDannax
{
    /// <summary>
    /// Логика взаимодействия для EditCompoundWindow.xaml
    /// </summary>
    public partial class EditCompoundWindow : Window
    {
        public Product ProductObject
        {
            get { return (Product)GetValue(ProductObjectProperty); }
            set { SetValue(ProductObjectProperty, value); }
        }

        public static readonly DependencyProperty ProductObjectProperty =
            DependencyProperty.Register("ProductObject", typeof(Product), typeof(EditCompoundWindow));

        public IEnumerable<Compound> Compounds => Connection.db.Compound.Local.Where(x => x.IdProduct == ProductObject.Id);

        public EditCompoundWindow(Product product = null)
        {
            ProductObject = product ?? new Product();

            Connection.db.Compound.Load();

            InitializeComponent();
            
        }
        private void Window_Closing(object sender, System.ComponentModel.CancelEventArgs e)
        {
            OrganizationPAgeWork.Instance.IsEnabled = true;
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            if (MatList.SelectedItem == null)
            {
                return;
            }
            var sel = MatList.SelectedItem as Compound;
            sel.Count = int.Parse(Count1TB.Text);
            Connection.db.Compound.Load();

            InitializeComponent();
        }
    }
}
