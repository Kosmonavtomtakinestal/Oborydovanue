//------------------------------------------------------------------------------
// <auto-generated>
//     Этот код создан по шаблону.
//
//     Изменения, вносимые в этот файл вручную, могут привести к непредвиденной работе приложения.
//     Изменения, вносимые в этот файл вручную, будут перезаписаны при повторном создании кода.
// </auto-generated>
//------------------------------------------------------------------------------

namespace Oborydovanue_StoreEmployee.DataBase
{
    using System;
    using System.Collections.Generic;
    
    public partial class Delivered
    {
        public int Id { get; set; }
        public int IdDelivery { get; set; }
        public int IdStoreemployee { get; set; }
        public System.DateTime DateTine { get; set; }
    
        public virtual Delivery Delivery { get; set; }
        public virtual StoreEmployee StoreEmployee { get; set; }
    }
}