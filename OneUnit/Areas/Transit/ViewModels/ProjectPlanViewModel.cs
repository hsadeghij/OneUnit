using OneUnit.Areas.Transit.Data.Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace OneUnit.Areas.Transit.ViewModels
{
    public class ProjectPlanViewModel
    {
        public int Id { get; set; }
        [Required]
        [Display(Name = "نام پروژه")]
        public virtual Project Project { get; set; }
        public int? ProjectId { get; set; }
        [Required]
        [Display(Name = "نام پیمانکار")]
        public virtual Person Person { get; set; }
        public int? PersonId { get; set; }
        [Display(Name = "تاریخ")]
        public string DateReg { get; set; }
        [Display(Name = "فعالیت")]
        public string Activity { get; set; }
        [Required]
        [Display(Name = "نوع کار")]
        public virtual WorkType WorkType { get; set; }
        public int? WorkTypeId { get; set; }
        [Display(Name = "توضیحات")]
        public string Description { get; set; }
        [Display(Name = "کارگران")]
        public string WorkerList { get; set; }
        public string WorkerListCodes { get; set; }
        [Display(Name = "استادکاران")]
        public string OstadKarList { get; set; }
        public string OstadKarCodes { get; set; }
        [Display(Name = "سرپرستان")]
        public string SarparastList { get; set; }
        public string SarparastCodes { get; set; }

        public virtual List<Person> GetWorkerList { get; set; }
        public virtual string[] workerList { get; set; }

        public virtual List<Person> GetSarparastList { get; set; }
        public virtual string[] sarparastList { get; set; }

        public virtual List<Person> GetOstadKarList { get; set; }
        public virtual string[] ostadkarList { get; set; }


    }
}
