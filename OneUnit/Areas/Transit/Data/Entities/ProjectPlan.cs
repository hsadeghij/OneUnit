using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace OneUnit.Areas.Transit.Data.Entities
{
    [Table("ProjectPlan", Schema = "Tran")]
    public class ProjectPlan
    {
        public int Id { get; set; }
        public virtual Person Person { get; set; }
        public int? PersonId { get; set; }
        public virtual Project Project { get; set; }
        public int? ProjectId { get; set; }
        public string DateReg { get; set; }
        public string Activity { get; set; }
        public virtual WorkType WorkType { get; set; }
        public int? WorkTypeId { get; set; }
        public string Description { get; set; }
        public string WorkerList { get; set; }
        public string WorkerListCodes { get; set; }
        public string OstadKarList { get; set; }
        public string OstadKarCodes { get; set; }
        public string SarparastList { get; set; }
        public string SarparastCodes { get; set; }
        public virtual ICollection<Attachment> Attachments { get; set; }
        public virtual ICollection<TraceWorker> TraceWorkers { get; set; }
    }

}
