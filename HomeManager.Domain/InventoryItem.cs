using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.ComponentModel.DataAnnotations;

namespace HomeManager.Domain
{
    public  class InventoryItem

    {
        public virtual  int Id { get; set; }
        public virtual DateTime Added { get; set; }
        [Required]
        [StringLength(50, ErrorMessage="Item name cannot exceed 50 characters.")]
        public virtual string Name { get; set; }
        public virtual string Size { get; set; }
        public virtual Location Location { get; set; }
        public virtual string Instructions { get; set; }
        public virtual int Count { get; set; }

        public virtual string UPC { get; set; }

        public InventoryItem()
        {
            // default non null dattetimevalues
            Added = DateTime.Now;
            Count = 1; 

        }
    }
    


}
