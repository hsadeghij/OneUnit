using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace OneUnit.Areas.QC.Data.Entities
{
    [Table("Company", Schema = "QC")]
    public class Company
    {
        [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        public string Name { get; set; }
        public virtual Site Site { get; set; }
        public int? SiteId { get; set; }
        public virtual ICollection<ProcessName> ProcessNames { get; set; }
        public virtual ICollection<SamplingLocation> SamplingLocations { get; set; }
        public virtual ICollection<ControlParameter> ControlParameters { get; set; }
        public virtual ICollection<QualityDesign> QualityDesigns { get; set; }
        public virtual ICollection<PauseTime> PauseTimes { get; set; }

    }
}
