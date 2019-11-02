using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace OneUnit.Areas.QC.Data.Entities
{
    [Table("SamplingLocation", Schema = "QC")]
    public class SamplingLocation
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public virtual ICollection<QualityDesign> QualityDesigns { get; set; }
        public virtual ICollection<ControlParameter> ControlParameters { get; set; }

        //-------------
        public virtual Company Company { get; set; }
        public int? CompanyId { get; set; }
        //------------
        public virtual ProcessName ProcessName { get; set; }
        public int? ProcessNameId { get; set; }
    }
}
