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
using Oborydovanue_StoreEmployee.DataBase;

namespace Oborydovanue_StoreEmployee.Pages
{
    /// <summary>
    /// Логика взаимодействия для WindowToDelivery.xaml
    /// </summary>
    public partial class WindowToDelivery : Window
    {
        public static Stock stock;
        public WindowToDelivery(Stock _stock)
        {
            InitializeComponent();
            stock = _stock;
            NameProd.Text = stock.Product.Name;
        }

        private void YesBTN_Click(object sender, RoutedEventArgs e)
        {
            if (CountTB.Text.Trim() == "")
            {
                MessageBox.Show("Заполните поле", "", MessageBoxButton.OK);
            }
            else
            {
                if (SaveSomeData.stocks.Contains(stock))
                {
                    foreach (var item in SaveSomeData.stocks)
                    {
                        if (item.IdProduct == stock.IdProduct)
                        {
                            item.MinCreateCount += int.Parse(CountTB.Text.Trim());
                        }
                    }
                }
                else
                {
                    stock.MinCreateCount += int.Parse(CountTB.Text.Trim());
                    SaveSomeData.stocks.Add(stock);
                }
                Close();

            }        
        }

        private void Count_PreviewTextInput(object sender, TextCompositionEventArgs e)
        {
            if (!(Char.IsDigit(e.Text, 0)))
            {
                e.Handled = true;
            }
        }
    }
}
