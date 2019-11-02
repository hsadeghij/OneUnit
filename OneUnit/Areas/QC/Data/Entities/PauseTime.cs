using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace OneUnit.Areas.QC.Data.Entities
{
    [Table("PauseTime", Schema = "QC")]
    public class PauseTime
    {
        public int Id { get; set; }
        [Display(Name = "تاریخ وقفه")]
        public string BreakDate { get; set; }
        [Display(Name = "مدت وقفه")]
        public virtual Hour Hour { get; set; }
        public byte? HourId { get; set; }
        public virtual Company Company { get; set; }
        public int? CompanyId { get; set; }
    }
}
