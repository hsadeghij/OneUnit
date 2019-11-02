using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace OneUnit.Areas.QC.Data.Entities
{
    [Table("QParameterStatus", Schema = "QC")]
    public class QParameterStatus
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public virtual ICollection<QualityDesign> QualityDesigns { get; set; }
        //----------
        public virtual Confirmation Confirmation { get; set; }
        public int? ConfirmationId { get; set; }
    }
}
