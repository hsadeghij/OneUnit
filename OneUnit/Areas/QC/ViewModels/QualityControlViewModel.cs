using OneUnit.Areas.QC.Data.Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace OneUnit.Areas.QC.ViewModels
{
    public class QualityControlViewModel
    {
        public int Id { get; set; }
        public Decimal Amount { get; set; }
        //---------------------------------------------------------
        [Display(Name = "سال")]
        public Year Year { get; set; }
        [Required]
        public byte YearId { get; set; }
        //---------------------------------------------------------
        [Display(Name = "ماه")]
        public Month Month { get; set; }
        [Required]
        public byte MonthId { get; set; }
        //---------------------------------------------------------
        [Display(Name = "روز")]
        public Day Day { get; set; }
        [Required]
        public byte DayId { get; set; }
        //---------------------------------------------------------
        [Display(Name = "شیفت")]
        public Shift Shift { get; set; }
        [Required]
        public byte ShiftId { get; set; }
        //---------------------------------------------------------
        [Display(Name = "ساعت")]
        public Hour Hour { get; set; }
        [Required]
        public byte HourId { get; set; }
        //---------------------------------------------------------
        [Display(Name = "وضعیت")]
        public Confirmation Confirmation { get; set; }
        [Required]
        public byte ConfirmationId { get; set; }
        //---------------------------------------------------------
        [Display(Name = "نام فرآیند")]
        public QualityDesign QualityDesign { get; set; }
        [Required]
        public int QualityDesignId { get; set; }
        //---------------------------------------------------------
    }
}
