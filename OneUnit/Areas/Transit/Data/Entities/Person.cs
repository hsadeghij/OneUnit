using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace OneUnit.Areas.Transit.Data.Entities
{
    [Table("Person", Schema = "Tran")]
    public class Person
    {
        public int Id  { get; set; }
        public string FullName { get; set; }
        [RegularExpression("^[0-9]*$", ErrorMessage = "UPRN must be numeric")]
        public string PersonalCode { get; set; }
        [RegularExpression("^[0-9]*$", ErrorMessage = "UPRN must be numeric")]
        public string NationalCode { get; set; }
        public string Address { get; set; }
        [RegularExpression("^[0-9]*$", ErrorMessage = "UPRN must be numeric")]
        public string Mobile { get; set; }
        public virtual Post Post { get; set; }
        public int? PostId { get; set; }
        public byte[] Image { get; set; }
        public virtual ICollection<ProjectPlan> ProjectPlans { get; set; }
        public virtual ICollection<TransitInfo> TransitInfos { get; set; }


    }
}
