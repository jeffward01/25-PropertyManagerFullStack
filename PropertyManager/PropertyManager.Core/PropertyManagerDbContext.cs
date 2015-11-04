using Microsoft.AspNet.Identity.EntityFramework;
using PropertyManager.Core.Domain;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PropertyManager.Core.Infrastructure
{
     public class PropertyManagerDbContext : IdentityDbContext  
    {
        //Constructor | Referencing Base Constructor and launching configuration string 
        public PropertyManagerDbContext() : base("PropertyManager")
        {}

        //DataBase Sets
        public IDbSet<Property> Properties { get; set; }
        public IDbSet<Tenant> Tenants { get; set; }
        public IDbSet<Lease> Leases { get; set; }
        //Possibly add img here later


        //Code First Fluid API
        //Creates Database on these parameters
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Property>().HasKey(p => p.PropertyId);
            modelBuilder.Entity<Property>().HasMany(p => p.Leases)
                .WithRequired(l => l.Property)
                .HasForeignKey(l => l.PropertyId);

            modelBuilder.Entity<Tenant>().HasKey(t => t.TenantId);
            modelBuilder.Entity<Tenant>().HasMany(l => l.Leases)
                .WithRequired(l => l.Tenant)
                .HasForeignKey(l => l.TenantId);

            modelBuilder.Entity<Lease>().HasKey(l => l.LeaseId);
         
            base.OnModelCreating(modelBuilder);
        }
    }
}
