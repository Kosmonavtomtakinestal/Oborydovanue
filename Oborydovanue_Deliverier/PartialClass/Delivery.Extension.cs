using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Oborydovanue_Deliverier.DataBase
{
    partial class Delivery
    {
        public string StartTime
        {
            get
            {
                var text = BeginDateTime == null ? "" : $"Начало доставки: {BeginDateTime}";
                return text;
            }
        }
        public bool EnabledSP
        {
            get 
            {
                var b = BeginDateTime == null ? true : false;
                return b;
            }
        }
    }
}
