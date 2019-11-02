using OneUnit.Areas.QC.Data.Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace OneUnit.Areas.QC.ViewModels
{
    public class CompanyViewModel
    {
        public int Id { get; set; }
        [Required]
        [Display(Name = "شرکت")]
        public string Name { get; set; }
        [Display(Name = "سایت")]
        public Site Site { get; set; }
        public int SiteId { get; set; }
    }
}
