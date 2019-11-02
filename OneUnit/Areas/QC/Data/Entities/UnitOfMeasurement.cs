using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace OneUnit.Areas.QC.Data.Entities
{
    [Table("UnitOfMeasurement", Schema = "QC")]
    public class UnitOfMeasurement
    {
        public int Id { get; set; }
        public string  Name { get; set; }
        public virtual ICollection<ControlParameter> ControlParameters { get; set; }
    }
}
