﻿//------------------------------------------------------------------------------
// <auto-generated>
//     Этот код создан по шаблону.
//
//     Изменения, вносимые в этот файл вручную, могут привести к непредвиденной работе приложения.
//     Изменения, вносимые в этот файл вручную, будут перезаписаны при повторном создании кода.
// </auto-generated>
//------------------------------------------------------------------------------

namespace kd2020
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Infrastructure;
    
    public partial class avtoserviceEntities2 : DbContext
    {
        private static avtoserviceEntities2 _context;
        public avtoserviceEntities2()
        : base("name=avtoserviceEntities2")
        {
        }
        public static avtoserviceEntities2 GetContext()
        {
            if (_context == null)
                _context = new avtoserviceEntities2();
            return _context;
        }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            throw new UnintentionalCodeFirstException();
        }
    
        public virtual DbSet<Cars> Cars { get; set; }
        public virtual DbSet<Customers_cars> Customers_cars { get; set; }
        public virtual DbSet<Masters> Masters { get; set; }
        public virtual DbSet<New_spare_parts> New_spare_parts { get; set; }
        public virtual DbSet<Orders> Orders { get; set; }
        public virtual DbSet<Owners> Owners { get; set; }
        public virtual DbSet<Role> Role { get; set; }
        public virtual DbSet<Servicess> Servicess { get; set; }
        public virtual DbSet<Spare_parts_in_servics> Spare_parts_in_servics { get; set; }
        public virtual DbSet<sysdiagrams> sysdiagrams { get; set; }
        public virtual DbSet<Type_of_jobs> Type_of_jobs { get; set; }
    }
}
