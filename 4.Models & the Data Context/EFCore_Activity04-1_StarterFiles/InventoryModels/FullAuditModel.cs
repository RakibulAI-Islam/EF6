using Inventory_Models.Interfaces;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Inventory_Models
{
    public abstract class FullAuditModel : IIdentityModel, IAuditedModel, IActivatableModel
    {
        public int Id { get; set; }
        public string CreatedByUserId { get; set; }
        public DateTime CreatedDate { get; set; }
        public string LastModifiedUserId { get; set; }
        public DateTime? LastModifiedDate { get; set; }
        public bool IsActive { get; set; }
    }
}
