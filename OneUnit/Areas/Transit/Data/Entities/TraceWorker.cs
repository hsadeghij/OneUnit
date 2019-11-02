using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace OneUnit.Areas.Transit.Data.Entities
{
    [Table("TraceWorker", Schema = "Tran")]
    public class TraceWorker
    {
        public int Id { get; set; }
        public virtual  TransitInfo TransitInfo { get; set; }
        public int TransitInfoId { get; set; }
        public virtual ProjectPlan ProjectPlan { get; set; }
        public int? ProjectPlanId { get; set; }
        public string DateReg { get; set; }
        public string TimeReg { get; set; }
        public virtual TransitType TransitType { get; set; }
        public int TransitTypeId { get; set; }
        public virtual Post Post { get; set; }
        public int PostId { get; set; }

    }
}
