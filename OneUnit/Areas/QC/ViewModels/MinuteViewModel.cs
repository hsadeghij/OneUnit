using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace OneUnit.Areas.QC.ViewModels
{
    public class MinuteViewModel
    {
        public byte Id { get; set; }
        [Required]
        [Display(Name = "دقیقه")]
        public string Name { get; set; }
    }
}
