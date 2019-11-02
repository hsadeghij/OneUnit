using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace OneUnit.Areas.QC.Data.Entities
{
    [Table("Confirmation", Schema = "QC")]
    public class Confirmation
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public virtual ICollection<QParameterStatus> QParameterStatuss { get; set; }
    }
}
