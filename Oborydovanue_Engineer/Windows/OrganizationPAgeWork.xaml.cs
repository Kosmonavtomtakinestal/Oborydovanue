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
using Oborydovanue_Engineer.Pages.VuvodDannax;

namespace Oborydovanue_Engineer.Windows
{
    /// <summary>
    /// Логика взаимодействия для OrganizationPAgeWork.xaml
    /// </summary>
    public partial class OrganizationPAgeWork : Window
    {
        public static OrganizationPAgeWork Instance { get; private set; }
        public OrganizationPAgeWork()
        {
            InitializeComponent();
            Instance = this;
            MainFrame.Navigate(new CompountPage());
        }

        private void InstructionBtn_Click(object sender, RoutedEventArgs e)
        {
            MainFrame.Navigate(new CompountPage());
        }

        private void ProdBtn_Click(object sender, RoutedEventArgs e)
        {

        }

        private void MaterialBtn_Click(object sender, RoutedEventArgs e)
        {

        }

        private void OrderBTN_Click(object sender, RoutedEventArgs e)
        {

        }
    }
}
