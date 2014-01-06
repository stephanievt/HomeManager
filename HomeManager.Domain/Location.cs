using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.ComponentModel.DataAnnotations;


namespace HomeManager.Domain
{
    public class Location
    {
        
        public virtual int Id { get; set; }
        [Required]
        [StringLength(50, ErrorMessage="The location name cannot be longer that 50 characters.")]
        public virtual string Name { get; set; }
        public virtual ICollection<InventoryItem> InventoryItems { get; set;}


    }
}
