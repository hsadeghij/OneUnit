using OneUnit.Areas.QC.Data.Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace OneUnit.Areas.QC.ViewModels
{
    public class SamplingLocationViewModel
    {
        public int Id { get; set; }
        [Required]
        [Display(Name = "محل نمونه برداری")]
        public string Name { get; set; }

        //---------------------------------------------------------
        [Display(Name = "شرکت")]
        public Company Company { get; set; }
        [Required]
        public int CompanyId { get; set; }
        //---------------------------------------------------------
        [Display(Name = "نام فرآیند")]
        public ProcessName ProcessName { get; set; }
        [Required]
        public int ProcessNameId { get; set; }
        //---------------------------------------------------------
    }
}
