//------------------------------------------------------------------------------
// <auto-generated>
//     Этот код создан по шаблону.
//
//     Изменения, вносимые в этот файл вручную, могут привести к непредвиденной работе приложения.
//     Изменения, вносимые в этот файл вручную, будут перезаписаны при повторном создании кода.
// </auto-generated>
//------------------------------------------------------------------------------

namespace Oborydovanue_StoreAdmin.DataBase
{
    using System;
    using System.Collections.Generic;
    
    public partial class Compound
    {
        public int Id { get; set; }
        public Nullable<int> IdProduct { get; set; }
        public Nullable<int> IdMaterial { get; set; }
        public Nullable<int> Count { get; set; }
    
        public virtual Material Material { get; set; }
        public virtual Product Product { get; set; }
    }
}
