using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Oborydovanie_Client.DataBase
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
    }
}
