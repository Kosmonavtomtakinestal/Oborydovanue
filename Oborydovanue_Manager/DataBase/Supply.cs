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
    
    public partial class Supply
    {
        public int Id { get; set; }
        public Nullable<int> IdOrder { get; set; }
        public Nullable<int> IdSupplier { get; set; }
        public Nullable<int> IdManager { get; set; }
        public Nullable<int> IdStatus { get; set; }
    
        public virtual Manager Manager { get; set; }
        public virtual Order Order { get; set; }
        public virtual Status Status { get; set; }
        public virtual Supplier Supplier { get; set; }
    }
}
