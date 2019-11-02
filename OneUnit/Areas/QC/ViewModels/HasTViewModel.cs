using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace OneUnit.Areas.QC.ViewModels
{
    public class HasTViewModel
    {
        public byte Id { get; set; }
        [Required]
        [Display(Name = "دارد")]
        public string Name { get; set; }
    }
}
