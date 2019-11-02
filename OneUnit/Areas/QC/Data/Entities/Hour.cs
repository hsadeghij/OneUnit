using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace OneUnit.Areas.QC.Data.Entities
{
    [Table("Hour", Schema = "QC")]
    public class Hour
    {
        [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public byte Id { get; set; }
        public string Name  { get; set; }
        public virtual ICollection<QualityControl> QualityControls { get; set; }
        public virtual ICollection<PauseTime> PauseTimes { get; set; }
    }
}

