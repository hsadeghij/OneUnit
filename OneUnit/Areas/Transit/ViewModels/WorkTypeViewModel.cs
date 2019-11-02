using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace OneUnit.Areas.Transit.ViewModels
{
    public class WorkTypeViewModel
    {
        public int Id { get; set; }
        [Required]
        [Display(Name = "نوع کار")]
        public string Name { get; set; }
    }
}
