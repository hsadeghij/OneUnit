using OneUnit.Areas.QC.Data.Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace OneUnit.Areas.QC.ViewModels
{
    public class QParameterStatusViewModel
    {
        public int Id { get; set; }
        [Required]
        [Display(Name = "وضعیت پارامتر کیفی")]
        public string Name { get; set; }
        //----------------------------------------
        [Display(Name = "وضعیت")]
        public Confirmation Confirmation { get; set; }
        [Required]
        public int ConfirmationId { get; set; }
        //---------------------------------------------------------

    }
}
