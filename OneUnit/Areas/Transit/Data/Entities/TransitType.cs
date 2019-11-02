using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace OneUnit.Areas.Transit.Data.Entities
{
    [Table("TransitType", Schema = "Tran")]
    public class TransitType
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public virtual ICollection<TraceWorker> TraceWorkers { get; set; }
    }
}
