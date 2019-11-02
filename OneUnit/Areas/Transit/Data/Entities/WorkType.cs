using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace OneUnit.Areas.Transit.Data.Entities
{
    [Table("WorkType", Schema = "Tran")]
    public class WorkType
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public virtual ICollection<ProjectPlan> ProjectPlans { get; set; }

    }
}
