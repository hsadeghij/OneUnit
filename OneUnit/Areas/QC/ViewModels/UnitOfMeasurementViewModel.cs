using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace OneUnit.Areas.QC.ViewModels
{
    public class UnitOfMeasurementViewModel
    {
        public int Id { get; set; }
        [Required]
        [Display(Name = "واحد اندازه گیری")]
        public string Name { get; set; }
    }
}
