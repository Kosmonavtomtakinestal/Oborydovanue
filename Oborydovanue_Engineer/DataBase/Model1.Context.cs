﻿//------------------------------------------------------------------------------
// <auto-generated>
//     Этот код создан по шаблону.
//
//     Изменения, вносимые в этот файл вручную, могут привести к непредвиденной работе приложения.
//     Изменения, вносимые в этот файл вручную, будут перезаписаны при повторном создании кода.
// </auto-generated>
//------------------------------------------------------------------------------

namespace Oborydovanue_Engineer.DataBase
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Infrastructure;
    
    public partial class ArendaEntities : DbContext
    {
        public ArendaEntities()
            : base("name=ArendaEntities")
        {
        }
    
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            throw new UnintentionalCodeFirstException();
        }
    
        public virtual DbSet<Client> Client { get; set; }
        public virtual DbSet<Compound> Compound { get; set; }
        public virtual DbSet<Delivered> Delivered { get; set; }
        public virtual DbSet<Deliverier> Deliverier { get; set; }
        public virtual DbSet<Delivery> Delivery { get; set; }
        public virtual DbSet<DeliveryProducts> DeliveryProducts { get; set; }
        public virtual DbSet<Engineer> Engineer { get; set; }
        public virtual DbSet<Manager> Manager { get; set; }
        public virtual DbSet<Material> Material { get; set; }
        public virtual DbSet<Order> Order { get; set; }
        public virtual DbSet<OrganizationEmployee> OrganizationEmployee { get; set; }
        public virtual DbSet<PointOfIssue> PointOfIssue { get; set; }
        public virtual DbSet<Product> Product { get; set; }
        public virtual DbSet<Rent> Rent { get; set; }
        public virtual DbSet<Status> Status { get; set; }
        public virtual DbSet<Stock> Stock { get; set; }
        public virtual DbSet<StoreEmployee> StoreEmployee { get; set; }
        public virtual DbSet<Supplier> Supplier { get; set; }
        public virtual DbSet<Supply> Supply { get; set; }
        public virtual DbSet<sysdiagrams> sysdiagrams { get; set; }
    }
}
