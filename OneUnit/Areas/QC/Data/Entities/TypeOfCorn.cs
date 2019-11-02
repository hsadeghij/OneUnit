using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace OneUnit.Areas.QC.Data.Entities
{
    [Table("TypeOfCorn", Schema = "QC")]
    public class TypeOfCorn
    {
        public int Id { get; set; }
        public String Name { get; set; }
        public virtual ICollection<QualityDesign> QualityDesigns { get; set; }
    }
}
