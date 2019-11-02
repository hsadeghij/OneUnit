using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace OneUnit.Areas.Transit.Data.Entities
{
    [Table("CurrentState", Schema = "Tran")]
    public class CurrentState
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public virtual ICollection<TransitInfo> TransitInfos { get; set; }
    }
}
