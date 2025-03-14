using InventoryModels.Interfaces;
using System;
using System.ComponentModel.DataAnnotations;

namespace InventoryModels
{
    public abstract class FullAuditModel : IIdentityModel, IAuditedModel, IActivatableModel
    {
        [Key]
        public int Id { get; set; }

        [StringLength(InventoryModelsConstants.MAX_USERID_LENGTH)]
        public string CreatedByUserId { get; set; }
        public DateTime CreatedDate { get; set; }

        [StringLength(InventoryModelsConstants.MAX_USERID_LENGTH)]
        public string LastModifiedUserId { get; set; }
        public DateTime? LastModifiedDate { get; set; }
        public bool IsActive { get; set; }
    }

}
