using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace OneUnit.Areas.QC.ViewModels
{
    public class DayViewModel
    {
        public int Id { get; set; }
        [Required]
        [Display(Name = "روز")]
        public string Name { get; set; }
    }
}
