using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace OneUnit.Areas.Transit.Data.Entities
{
    [Table("Project", Schema = "Tran")]
    public class Project
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public virtual ICollection<ProjectPlan> ProjectPlans { get; set; }

    }
}
