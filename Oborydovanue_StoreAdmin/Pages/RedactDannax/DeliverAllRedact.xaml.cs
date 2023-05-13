using Oborydovanue_Deliverier.DataBase;
using Oborydovanue_StoreAdmin.DataBase;
using Oborydovanue_StoreAdmin.Pages.VuvodDannax;
using Oborydovanue_StoreAdmin.Windows;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Windows;
using System.Windows.Documents;

namespace Oborydovanue_StoreAdmin.Pages.RedactDannax
{
    /// <summary>
    /// Логика взаимодействия для DeliverAllRedact.xaml
    /// </summary>
    public partial class DeliverAllRedact : Window
    {
        public  Delivery DeliveryObject
        {
            get { return (Delivery)GetValue(DeliveryObjectProperty); }
            set { SetValue(DeliveryObjectProperty, value); }
        }

        public static readonly DependencyProperty DeliveryObjectProperty =
            DependencyProperty.Register("DeliveryObject", typeof(Delivery), typeof(DeliverAllRedact));

        public List<PointOfIssue> PointOfIssueList { get; set; } 
        public List<Deliverier> DeliveriersList{ get; set; } 

        public DeliverAllRedact(Delivery delivery = null)
        {
            DeliveryObject = delivery ?? new Delivery();

            PointOfIssueList = Connection.db.PointOfIssue.ToList();
            DeliveriersList = Connection.db.Deliverier.ToList();   

            InitializeComponent();

            SaveChangesBtn.Click += (sender, e) => { SavingEndExiting(); };
        }
        private void SavingEndExiting()
        {
            SaveChanges();

            OrganizationPAgeWork.Instance.MainFrame.Navigate(new DeliveryPageAll());

            Close();
        }
        private void SaveChanges()
        {
           

            Connection.db.SaveChanges();
        }
        private void Window_Closing(object sender, System.ComponentModel.CancelEventArgs e)
        {
            OrganizationPAgeWork.Instance.IsEnabled = true;
        }

    }
}
