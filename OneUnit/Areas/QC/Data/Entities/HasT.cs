using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace OneUnit.Areas.QC.Data.Entities
{
    [Table("HasT", Schema = "QC")]
    public class HasT
    {
        public byte Id { get; set; }
        public string Name { get; set; }
        public virtual ICollection<ProcessName> ProcessNames { get; set; }
    }
}
