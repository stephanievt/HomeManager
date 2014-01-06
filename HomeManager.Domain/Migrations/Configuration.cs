namespace HomeManager.Web.Migrations
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;
    using HomeManager.Domain;
    internal sealed class Configuration : DbMigrationsConfiguration<HomeManager.Domain.InventoryDb>
    {
        public Configuration()
        {

            AutomaticMigrationsEnabled = true;
            ContextKey = "HomeManager.Domain.InventoryDb";
        }

        protected override void Seed(HomeManager.Domain.InventoryDb context)
        {
            //  This method will be called after migrating to the latest version.
            // use the below to force the debugger
            //if (System.Diagnostics.Debugger.IsAttached == false)
            //    System.Diagnostics.Debugger.Launch();

            context.Locations.AddOrUpdate(l => l.Name,
                new Location() { Name = "Basement freezer" },
                new Location() { Name = "Kitchen freezer" });

            context.SaveChanges();

            var loc = context.Locations.SingleOrDefault(l => l.Name =="Basement freezer" );
            context.InventoryItems.AddOrUpdate(h => h.Name, 
                new InventoryItem {Name = "meatloaf", Instructions ="Thaw, add sauce, bake", Location = loc, Count=2}
                );

            context.InventoryItems.AddOrUpdate(h => h.Name,
                new InventoryItem { Name = "stew", Instructions = "heat on stove", Location = loc }
                );

            loc = context.Locations.SingleOrDefault(l => l.Name == "Kitchen freezer");
            context.InventoryItems.AddOrUpdate(h => h.Name,
                new InventoryItem { Name = "peas", Instructions = "Thaw, add sauce, bake", Location = loc }
                );
            context.SaveChanges();
        }
    }
}
