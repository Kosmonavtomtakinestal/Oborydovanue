using Oborydovanue_Deliverier.Pages;
using System.Windows;


namespace Oborydovanue_Deliverier
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            SaveSomeData.main = this;
            MainFrame.Navigate(new AuthPage());
        }
    }
}
