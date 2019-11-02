using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OneUnit.Areas.Transit.ViewModels
{
    public class ProjectPlanInCurrentDateViewModel
    {
        public int Id { get; set; }
        public string FullName { get; set; }
        public string Activity { get; set; }
        public string Description { get; set; }
        public string WorkTypeName { get; set; }
        public string SarparastList { get; set; }
        public string OstadKarList { get; set; }
        public string WorkerList { get; set; }
        public string DateReg { get; set; }
    }
}
