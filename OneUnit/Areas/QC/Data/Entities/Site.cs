using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace OneUnit.Areas.QC.Data.Entities
{
    [Table("Site", Schema = "QC")]
    public class Site
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public virtual ICollection<Company> Companies { get; set; }

    }
}
