using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using HomeManager.Domain;

namespace HomeManager.Web
{
    public class InventoryFactory
    {
        public IList<Location> GetLocations()
        {
            return (new InventoryDb()).Locations.ToList();
        }

        public IList<InventoryItem> GetItems()
        {
            return (new InventoryDb()).InventoryItems.ToList();
        }
        
    }
}
