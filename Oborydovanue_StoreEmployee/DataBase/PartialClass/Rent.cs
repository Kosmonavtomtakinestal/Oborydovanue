using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace Oborydovanue_StoreEmployee.DataBase
{
    partial class Rent
    {
        public string StatusRent
        {
            get
            {
                if ((bool)Returned)
                {
                    return "Товар возвращен";
                }
                else if (!(bool)Returned && IdStoreEmployee != null)
                {
                    return "Товар в прокате";
                }
                else
                {
                    return "Готовится к прокату";
                }
            }
        }

        public string BtnVis
        {
            get
            {
                if (!(bool)Returned && IdStoreEmployee != null)
                {
                    return "Visible";
                }
                else
                {
                    return "Collapsed";
                }
            }
        }
        
        public string BtnVis1
        {
            get
            {
                if ((bool)Returned)
                {
                    return "Collapsed";
                }
                else if (!(bool)Returned && IdStoreEmployee != null)
                {
                    return "Collapsed";
                }
                else
                {
                    return "Visible";
                }
            }
        }
    }
}
