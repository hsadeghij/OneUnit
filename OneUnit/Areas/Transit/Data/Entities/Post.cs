using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace OneUnit.Areas.Transit.Data.Entities
{
    [Table("Post", Schema = "Tran")]
    public class Post
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public virtual ICollection<Person> Persons { get; set; }
        public virtual ICollection<TraceWorker> TraceWorkers { get; set; }
    }
}
