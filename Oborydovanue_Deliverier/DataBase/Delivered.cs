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
    
    public partial class Delivered
    {
        public int Id { get; set; }
        public Nullable<int> IdDelivery { get; set; }
        public Nullable<int> IdStoreemployee { get; set; }
        public Nullable<System.DateTime> DateTine { get; set; }
    
        public virtual Delivery Delivery { get; set; }
        public virtual StoreEmployee StoreEmployee { get; set; }
    }
}
