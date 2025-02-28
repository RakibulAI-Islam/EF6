using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Inventory_Models.Interfaces
{
    public interface IAuditedModel
    {
        public string CreatedByUserId { get; set; }
        public DateTime CreatedDate { get; set; }
        public string LastModifiedUserId { get; set; }
        public DateTime? LastModifiedDate { get; set; }
    }
}
