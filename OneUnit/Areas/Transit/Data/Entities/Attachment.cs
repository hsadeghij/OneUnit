using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace OneUnit.Areas.Transit.Data.Entities
{
    [Table("Attachment", Schema = "Tran")]
    public class Attachment
    {
        public int Id { get; set; }
        public string Description { get; set; }
        public string PicUrl { get; set; }
        public virtual ProjectPlan ProjectPlan { get; set; }
        public int? ProjectPlanId { get; set; }
    }
}
