//------------------------------------------------------------------------------
// <auto-generated>
//     Этот код создан по шаблону.
//
//     Изменения, вносимые в этот файл вручную, могут привести к непредвиденной работе приложения.
//     Изменения, вносимые в этот файл вручную, будут перезаписаны при повторном создании кода.
// </auto-generated>
//------------------------------------------------------------------------------

namespace Oborydovanue_Manager.DataBase
{
    using System;
    using System.Collections.Generic;
    
    public partial class DeliveryProducts
    {
        public int Id { get; set; }
        public int IdDelivery { get; set; }
        public int IdProduct { get; set; }
        public int Count { get; set; }
    
        public virtual Delivery Delivery { get; set; }
        public virtual Product Product { get; set; }
    }
}
