using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace OneUnit.Areas.QC.Data.Entities
{
    [Table("OrganizationalUnit", Schema = "QC")]
    public class OrganizationalUnit
    {
        public int Id { get; set; }
        [Display(Name = "نام")]
        public string Name { get; set; }
        public virtual ICollection<ControlParameter> ControlParameterRControls { get; set; }
        public virtual ICollection<ControlParameter> ControlParameterRActions { get; set; }

    }
}
