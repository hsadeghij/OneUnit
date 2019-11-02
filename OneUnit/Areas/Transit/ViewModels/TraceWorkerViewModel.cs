using OneUnit.Areas.Transit.Data.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OneUnit.Areas.Transit.ViewModels
{
    public class TraceWorkerViewModel
    {
        public int Id { get; set; }
        public virtual TransitInfo TransitInfo { get; set; }
        public int TransitInfoId { get; set; }
        public virtual Project Project { get; set; }
        public int ProjectId { get; set; }
        public string DateReg { get; set; }
        public string TimeReg { get; set; }
        public virtual TransitType TransitType { get; set; }
        public int TransitTypeId { get; set; }
    }
}
