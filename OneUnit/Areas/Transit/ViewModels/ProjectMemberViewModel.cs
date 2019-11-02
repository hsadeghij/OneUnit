using OneUnit.Areas.Transit.Data.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OneUnit.Areas.Transit.ViewModels
{
    public class ProjectMemberViewModel
    {
        public int Id { get; set; }
        public virtual ProjectPlan ProjectPlan { get; set; }
        public int? ProjectPlanId { get; set; }
        public virtual Person Person { get; set; }
        public int? PersonId { get; set; }
    }
}
