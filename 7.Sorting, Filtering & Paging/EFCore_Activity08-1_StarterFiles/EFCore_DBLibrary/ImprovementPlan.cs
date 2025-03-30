using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EFCore_DBLibrary
{
    public class ImprovementPlan
    {
        [Key]
        [ForeignKey("Employee")]
        public int BusinessEntityId { get; set; }
        public virtual Employee Employee { get; set; }

        [Required]
        public DateTime PlanStart { get; set; }
        public DateTime PlanComplete => PlanStart.AddDays(90);
    }

}
