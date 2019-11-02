using OneUnit.Areas.Admin.Data.Entities;
using OneUnit.Areas.QC.Data.Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace OneUnit.Areas.QC.ViewModels
{
    public class QualityDesignViewModel
    {
        //public QualityDesignViewModel()
        //{
        //    Sampler = new StoreUser();
        //    Tester = new StoreUser();
        //    ControllerUser = new StoreUser();
        //}
      //  public QualityDesignViewModel()
     //   {
           // Sampler = new List<StoreUser>();
            //tester = new List<StoreUser>();
            //controller = new List<StoreUser>();
       // }
        public int Id { get; set; }
        //---------------------------------------------------------
        [Display(Name = "تاریخ")]
        [Required]
        public string DateQD { get; set; }
        //---------------------------------------------------------
        [Display(Name = "ساعت ثبت")]
        [Required]
        public string RegistrationTime { get; set; }
        //---------------------------------------------------------
        [Display(Name = "شیفت")]
        public Shift Shift { get; set; }
        [Required]
        public byte ShiftId { get; set; }
        //---------------------------------------------------------
        [Display(Name = "مقدار")]
        public Decimal? ValueLimit { get; set; }
        //---------------------------------------------------------
        //وضعیت پارامتر کیفی
        [Display(Name = "وضعیت پارامتر کیفی")]
        public virtual QParameterStatus QParameterStatus { get; set; }
        public int? QParameterStatusId { get; set; }
        //---------------------------------------------------------
        [Display(Name = "نام فرآیند")]
        public ProcessName ProcessName { get; set; }
        [Required]
        public int ProcessNameId { get; set; }
        //---------------------------------------------------------
        [Display(Name = "محل نمونه برداری")]
        public virtual SamplingLocation SamplingLocation { get; set; }
        public int SamplingLocationId { get; set; }
        //-------------------------------------------------------------
        [Display(Name = "پارامتر کنترلی")]
        public ControlParameter ControlParameter { get; set; }
        [Required]
        public int ControlParameterId { get; set; }
        //------------------------------------------------------------
        [Display(Name = "وضعیت تایید")]
        public virtual Confirmation Confirmation { get; set; }
        [Required]
        public int ConfirmationId { get; set; }
        //-----------------------------------------------------------
        //-----------
        [Display(Name = "Storage هدف")]
        public virtual Storage Storage { get; set; }
        [Required]
        public int? StorageId { get; set; }
        //-----------------------------------------------------------
        [Display(Name = "ساعت انتقال به storage")]
        [Required]
        public string TransferTimeToStorage { get; set; }
        //---------------------------------------------------------
        [Display(Name = "توضیحات")]
        [Required]
        public string Description { get; set; }
        //--------------------------------------------------------
        [Display(Name = "شرکت")]
        public virtual Company Company { get; set; }
        [Required]
        public int? CompanyId { get; set; }
        //------------------------------------------------------
        [Display(Name = "نوع ذرت")]
        public virtual TypeOfCorn TypeOfCorn { get; set; }
        public int? TypeOfCornId { get; set; }
        ////شماره مخزن
        //[Display(Name = "شماره مخزن")]
        //public virtual Tank Tank { get; set; }
        //public int TankId { get; set; }
        ////تاریخ وساعت پر شدن مخزن
        //[Display(Name = "تاریخ وساعت پر شدن مخزن")]
        //public string DateTankFilling { get; set; }
        ////تاریخ و ساعت تخلیه مخزن
        //[Display(Name = "تاریخ و ساعت تخلیه مخزن")]
        //public string DateTankDrain { get; set; }
        ////سطح مخزن
        //[Display(Name = "سطح مخزن")]
        //public decimal LevelTank { get; set; }
        //[Display(Name = "Storage")]
        //public virtual Storage Storage { get; set; }
        //public int StorageId { get; set; }
        //[Display(Name = "تاریخ انتقال به Storage")]
        //public string DateStorageTransfer { get; set; }
        ////نام محصول
        //[Display(Name = "نام محصول")]
        //public virtual Production Production { get; set; }
        //public int ProductionId { get; set; }
        ////شماره ستون
        //[Display(Name = "شماره ستون")]
        //public virtual ColumnNumber ColumnNumber { get; set; }
        //public int ColumnNumberId { get; set; }
        ////---------
        //[Display(Name = "نمونه بردار")]
        //public virtual StoreUser  Sampler { get; set; }
        //public string SamplerId { get; set; }
        ////---------
        //[Display(Name = "آزمایش کننده")]
        //public virtual StoreUser Tester { get; set; }
        //public string TesterId { get; set; }
        ////----------
        //[Display(Name = "کنترلر")]
        //public virtual StoreUser ControllerUser { get; set; }
        //public string ControllerUserId { get; set; }
        ////---------

        //[Display(Name = "توضیحات")]
        //public string Description { get; set; }
    }
}
