using OneUnit.Areas.Admin.Data.Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace OneUnit.Areas.QC.Data.Entities
{
    [Table("QualityDesign", Schema = "QC")]
    public class QualityDesign
    {
        //public QualityDesign()
        //{
        //    Sampler = new StoreUser();
        //    Tester = new StoreUser();
        //    ControllerUser = new StoreUser();
        //}
        //public QualityDesign()
        //{
        //    Sampler = new List<StoreUser>();
        //   //tester = new List<StoreUser>();
        //   //controller = new List<StoreUser>();
        //}
        public int Id { get; set; }
        //-------------
        public string DateQD { get; set; }
        public string RegistrationTime { get; set; }
        //-------------
        public virtual Shift Shift { get; set; }
        public byte  ShiftId { get; set; }
        //-------------
        public virtual ProcessName ProcessName { get; set; }
        public int ProcessNameId { get; set; }
        //-------------
        [RegularExpression("([1-9][0-9]*)", ErrorMessage = "Count must be a natural number")]
        public Decimal? ValueLimit { get; set; }
        //------------
        //وضعیت پارامتر کیفی
        public virtual QParameterStatus QParameterStatus { get; set; }
        public int? QParameterStatusId { get; set; }
        //------------
        public virtual ControlParameter ControlParameter { get; set; }
        public int ControlParameterId { get; set; }
        //--------------
        public virtual Confirmation Confirmation { get; set; }
        public int ConfirmationId { get; set; }
        //--------------
        public string TransferTimeToStorage { get; set; }
        //-----------
        public virtual SamplingLocation SamplingLocation { get; set; }
        public int? SamplingLocationId { get; set; }
        //-----------
        public virtual Storage Storage { get; set; }
        public int? StorageId { get; set; }
        //-----------
        public string Description { get; set; }
        //-----------
        public virtual Company Company { get; set; }
        public int? CompanyId { get; set; }
        public virtual TypeOfCorn TypeOfCorn { get; set; }
        public int? TypeOfCornId { get; set; }
    }
    
}
