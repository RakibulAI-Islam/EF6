using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InventoryModels
{
    public class Category : FullAuditModel
    {
        [StringLength(InventoryModelsConstants.MAX_NAME_LENGTH)]
        public string Name { get; set; }

        /*One to Many - Relationship.*/
        public virtual List<Item> Items { get; set; } = new List<Item>();

        /*One to one - Relationship.*/
        public virtual CategoryDetail CategoryDetail { get; set; }
    }
}
