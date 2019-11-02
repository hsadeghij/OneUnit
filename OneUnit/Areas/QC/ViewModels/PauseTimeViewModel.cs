using OneUnit.Areas.QC.Data.Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace OneUnit.Areas.QC.ViewModels
{
    public class PauseTimeViewModel
    {
        public int Id { get; set; }
        [Display(Name = "تاریخ وقفه")]
        public string BreakDate { get; set; }
        [Display(Name = "مدت وقفه")]
        public virtual Hour Hour { get; set; }
        public int? HourId { get; set; }
        public virtual Company Company { get; set; }
        public int? CompanyId { get; set; }
    }
}
