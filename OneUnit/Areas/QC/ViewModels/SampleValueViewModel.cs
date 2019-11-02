using OneUnit.Areas.QC.Data.Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace OneUnit.Areas.QC.ViewModels
{
    public class SampleValueViewModel
    {
        public int Id { get; set; }
        [Required]
        [Display(Name = "مقدار نمونه")]
        public string Name { get; set; }
    }
}
