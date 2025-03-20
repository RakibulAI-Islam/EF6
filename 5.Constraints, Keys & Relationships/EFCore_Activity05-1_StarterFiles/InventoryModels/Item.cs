using System;
using System.ComponentModel.DataAnnotations;
using System.Collections.Generic;

//using InventoryModelConstants;

namespace InventoryModels
{
    public class Item : FullAuditModel
    {
        [Required]
        [StringLength(InventoryModelsConstants.MAX_NAME_LENGTH)]
        public string Name { get; set; }

        [Range(InventoryModelsConstants.MINIMUM_QUANTITY, InventoryModelsConstants.MAXIMUM_QUANTITY)]
        public int Quantity { get; set; }
        
        [StringLength(InventoryModelsConstants.MAX_DESCRIPTION_LENGTH)]
        public string Description { get; set; }

        [StringLength(InventoryModelsConstants.MAX_NOTES_LENGTH, MinimumLength = 10)]
        public string Notes { get; set; }
        public bool IsOnSale { get; set; }
        public DateTime? PurchasedDate { get; set; }
        public DateTime? SoldDate { get; set; }

        [Range(InventoryModelsConstants.MINIMUM_PRICE, InventoryModelsConstants.MAXIMUM_PRICE)]
        public decimal? PurchasePrice { get; set; }

        [Range(InventoryModelsConstants.MINIMUM_PRICE, InventoryModelsConstants.MAXIMUM_PRICE)]
        public decimal? CurrentOrFinalPrice { get; set; }

        /*One to Many - Relationship.*/
        public int? CategoryId { get; set; }
        public virtual Category Category { get; set; }

    }

}
