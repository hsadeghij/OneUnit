using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace OneUnit.Areas.Transit.Data.Entities
{
    [Table("Rating", Schema = "Tran")]
    public class Rating
    {
        [Key]
        public byte Id { get; set; }
        public string Name { get; set; }
        public virtual ICollection<TransitInfo> TransitInfos { get; set; }
    }
}
