using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OneUnit.Areas.QC.Data.Entities
{
    public class DateForQualityDesign
    {
        public int Id { get; set; }
        public String DateForQD { get; set; }
        public virtual ICollection<QualityDesign> QualityDesigns { get; set; }

    }
}
