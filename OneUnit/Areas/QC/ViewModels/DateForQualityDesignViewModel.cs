using OneUnit.Areas.QC.Data.Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace OneUnit.Areas.QC.ViewModels
{
    public class DateForQualityDesignViewModel
    {
        public int Id { get; set; }
        [Display(Name = "تاریخ")]
        public String DateForQD { get; set; }
        public virtual ICollection<QualityDesign> QualityDesigns { get; set; }
    }
}
