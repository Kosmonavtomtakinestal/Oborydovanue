//------------------------------------------------------------------------------
// <auto-generated>
//     Этот код создан по шаблону.
//
//     Изменения, вносимые в этот файл вручную, могут привести к непредвиденной работе приложения.
//     Изменения, вносимые в этот файл вручную, будут перезаписаны при повторном создании кода.
// </auto-generated>
//------------------------------------------------------------------------------

namespace Oborydovanue_Deliverier.DataBase
{
    using System;
    using System.Collections.Generic;
    
    public partial class Rent
    {
        public int Id { get; set; }
        public Nullable<System.DateTime> Date { get; set; }
        public Nullable<int> RentTime { get; set; }
        public Nullable<int> IdStoreEmployee { get; set; }
        public Nullable<int> IdClient { get; set; }
        public Nullable<int> IdStock { get; set; }
        public Nullable<bool> Returned { get; set; }
    
        public virtual Client Client { get; set; }
        public virtual Stock Stock { get; set; }
        public virtual StoreEmployee StoreEmployee { get; set; }
    }
}
