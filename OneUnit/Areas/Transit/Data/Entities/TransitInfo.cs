using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace OneUnit.Areas.Transit.Data.Entities
{
    [Table("TransitInfo", Schema = "Tran")]
    public class TransitInfo
    {
        public int Id { get; set; }
        public virtual Person Person { get; set; }
        public int? PersonId { get; set; }
        public string DateReg { get; set; }
        public string TimeReg { get; set; }
        public Rating Rating { get; set; }
        public virtual byte RatingId { get; set; }
        public virtual CurrentState CurrentState { get; set; }
        public int? CurrentStateId { get; set; }
        public virtual ICollection<TraceWorker> TraceWorkers { get; set; }


    }
}
