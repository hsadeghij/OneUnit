using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace OneUnit.Areas.Transit.ViewModels
{
    public class ActivityViewModel
    {
        public int Id { get; set; }
        [Required]
        [Display(Name = "نام پروژه")]
        public string Name { get; set; }
    }
}
