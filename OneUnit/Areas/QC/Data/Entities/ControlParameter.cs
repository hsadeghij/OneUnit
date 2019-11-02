using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace OneUnit.Areas.QC.Data.Entities
{
    [Table("ControlParameter", Schema ="QC")]
    public class ControlParameter
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public virtual ICollection<QualityDesign> QualityDesigns { get; set; }
        //-------------
        public virtual ProcessType ProcessType { get; set; }
        public int ProcessTypeId { get; set; }
        //------------
        public virtual ProcessName ProcessName { get; set; }
        public int ProcessNameId { get; set; }
        //------------
        [RegularExpression("([1-9][0-9]*)", ErrorMessage = "Count must be a natural number")]
        public Decimal BottomLimit { get; set; }
        [RegularExpression("([1-9][0-9]*)", ErrorMessage = "Count must be a natural number")]
        public Decimal UpperLimit { get; set; }
        //-------------
        public virtual DegreeOfImportance DegreeOfImportance { get; set; }
        public int DegreeOfImportanceId { get; set; }
        //-------------
        public virtual UnitOfMeasurement UnitOfMeasurement { get; set; }
        public int UnitOfMeasurementId { get; set; }
        //-------------
        public int SamplingFrequencyId { get; set; }
        //---------
        public virtual SampleValue SampleValue { get; set; }
        public int SampleValueId { get; set; }
        //---------
        public virtual TestValue TestValue { get; set; }
        public int TestValueId { get; set; }
        //---------
        public virtual SamplingLocation SamplingLocation { get; set; }
        public int SamplingLocationId { get; set; }
        //---------
        public virtual OrganizationalUnit RAction { get; set; }
        public int RActionId { get; set; }
        //---------
        public virtual Company Company { get; set; }
        public int? CompanyId { get; set; }


    }
}
