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
    
    public partial class Delivery
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Delivery()
        {
            this.Delivered = new HashSet<Delivered>();
            this.DeliveryProducts = new HashSet<DeliveryProducts>();
        }
    
        public int Id { get; set; }
        public System.DateTime BeginDateTime { get; set; }
        public int IdPointOfIssue { get; set; }
        public int IdDeliverier { get; set; }
    
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Delivered> Delivered { get; set; }
        public virtual Deliverier Deliverier { get; set; }
        public virtual PointOfIssue PointOfIssue { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<DeliveryProducts> DeliveryProducts { get; set; }
    }
}
