using OneUnit.Areas.Transit.Data.Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace OneUnit.Areas.Transit.ViewModels
{
    public class ProjectActivityViewModel
    {
        public int Id { get; set; }
        [Required]
        [Display(Name = "نام پروژه")]
        public virtual ProjectPlan ProjectPlan { get; set; }
        public int? ProjectPlanId { get; set; }
        [Required]
        [Display(Name = "نام کارگر")]
        public virtual TransitInfo TransitInfo { get; set; }
        public int? TransitInfoId { get; set; }
        [Display(Name = "تاریخ")]
        public string DateReg { get; set; }
    }
}
