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

namespace Oborydovanue_Manager.Pages
{
    /// <summary>
    /// Логика взаимодействия для ManagerWork.xaml
    /// </summary>
    public partial class ManagerWork : Window
    {

        public static ManagerWork Instance { get; private set; }

        public ManagerWork()
        {
            InitializeComponent();
            
            Instance = this;
            MainFrame.Navigate(new PageEng());
        }

        

        private void DeliverBtn_Click(object sender, RoutedEventArgs e)
        {
            MainFrame.Navigate(new SupplierPage());
        }

        private void EngBtn_Click(object sender, RoutedEventArgs e)
        {
            MainFrame.Navigate(new PageEng());
        }

        private void MangBtn_Click(object sender, RoutedEventArgs e)
        {
        MainFrame.Navigate(new PageManager());
        }

        private void HistoryBtn_Click(object sender, RoutedEventArgs e)
        {
            MainFrame.Navigate(new HistoryPage());
        }

        private void ProfileBtn_Click(object sender, RoutedEventArgs e)
        {
            MainFrame.Navigate(new ProfilePage());
        }
    }
}
