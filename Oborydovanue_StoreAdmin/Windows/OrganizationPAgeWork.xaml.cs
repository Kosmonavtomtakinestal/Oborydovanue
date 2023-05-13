using Oborydovanue_StoreAdmin.Pages.VuvodDannax;
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

namespace Oborydovanue_StoreAdmin.Windows
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
            MainFrame.Navigate(new EngPageView());
        }

        private void MangBtn_Click(object sender, RoutedEventArgs e)
        {
            MainFrame.Navigate(new ManPageView());
        }

        private void EngBtn_Click(object sender, RoutedEventArgs e)
        {
            MainFrame.Navigate(new EngPageView());
        }

        private void DeliverBtn_Click(object sender, RoutedEventArgs e)
        {
            MainFrame.Navigate(new DelPage());
        }

        

        private void EmployeeBtn_Click(object sender, RoutedEventArgs e)
        {
            MainFrame.Navigate(new StoreEnpPage());
        }

        private void DeliveryPage_Click(object sender, RoutedEventArgs e)
        {
            MainFrame.Navigate(new DeliveryPageAll());
        }
    }
}
