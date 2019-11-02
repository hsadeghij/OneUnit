using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace OneUnit.Areas.QC.ViewModels
{
    public class TypeOfCornViewModel
    {
        public int Id { get; set; }
        [Required]
        [Display(Name = "نوع ذرت")]
        public String Name { get; set; }
    }
}
