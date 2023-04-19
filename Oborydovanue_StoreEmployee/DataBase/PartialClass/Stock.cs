using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Oborydovanue_StoreEmployee.DataBase
{
    partial class Stock
    {
        public int CountInRent
        {
            get
            {
                int count = 0;
                foreach (var item in Rent)
                {
                    if (item.Stock.IdPoinOfIssue == IdPoinOfIssue && item.Stock.IdProduct == IdProduct && item.IdStoreEmployee != null && item.Returned == false)
                    {
                        count ++;
                    }
                }
                return count;
            }
        }
    }
}
