using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.Entity;


namespace HomeManager.Domain
{
    public class InventoryDb : DbContext

    {

        public DbSet<InventoryItem> InventoryItems { get; set; }
        public DbSet<Location> Locations { get; set; }


        public InventoryDb()
            : base("DefaultConnection")
        {

        }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.Entity<InventoryItem>().Property(p => p.Name).IsRequired();
            modelBuilder.Entity<Location>().Property(p => p.Name).IsRequired();

        }


    }
}
