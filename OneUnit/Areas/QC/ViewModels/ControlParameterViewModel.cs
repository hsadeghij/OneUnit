using OneUnit.Areas.QC.Data.Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace OneUnit.Areas.QC.ViewModels
{
    public class ControlParameterViewModel
    {
        public int Id { get; set; }
        //---------------------------------------------------------
       // public int MyProperty { get; set; }
        [Required]
        [Display(Name = "پارامتر کنترلی")]
        public string Name { get; set; }
        //---------------------------------------------------------
        [Display(Name = "نوع فرآیند")]
        public ProcessType ProcessType { get; set; }
        [Required]
        public int ProcessTypeId { get; set; }
        //---------------------------------------------------------
        [Display(Name = "نام فرآیند")]
        public ProcessName ProcessName { get; set; }
        [Required]
        public int ProcessNameId { get; set; }
        //---------------------------------------------------------
        [Display(Name = "حد پایین")]
        public Decimal BottomLimit { get; set; }

        [Display(Name = "حد بالا")]
        public Decimal UpperLimit { get; set; }
        //--------------------------------------------------------

        [Display(Name = "درجه اهمیت")]
        public DegreeOfImportance DegreeOfImportance { get; set; }
        [Required]
        public int DegreeOfImportanceId { get; set; }
        //--------------------------------------------------------

        [Display(Name = "واحد اندازه گیری")]
        public UnitOfMeasurement UnitOfMeasurement { get; set; }
        [Required]
        public int UnitOfMeasurementId { get; set; }
        //--------------------------------------------------------
        [Display(Name = "محل نمونه برداری")]
        public SamplingLocation SamplingLocation { get; set; }
        [Required]
        public int SamplingLocationId { get; set; }
        //--------------------------------------------------------

        [Display(Name = "مقدار نمونه")]
        public SampleValue SampleValue { get; set; }
        [Required]
        public int SampleValueId { get; set; }
        //----------------------------------------------------------
        [Display(Name = "مقدار آزمونه")]
        public TestValue TestValue { get; set; }
        [Required]
        public int TestValueId { get; set; }
        //----------------------------------------------------------
        [Display(Name = "مسئول اصلاح و اقدام")]
        public OrganizationalUnit RAction { get; set; }
        [Required]
        public int RActionId { get; set; }
        //-----------------------------------------------------------
        [Display(Name = "شرکت")]
        public Company Company { get; set; }
        [Required]
        public int CompanyId { get; set; }
    }
}
