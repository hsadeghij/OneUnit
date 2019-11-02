using Microsoft.AspNetCore.Identity;
using OneUnit.Areas.QC.Data.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OneUnit.Areas.Admin.Data.Entities
{
    public class StoreUser:IdentityUser
    {
        public string Name { get; set; }
        public DateTime Birthdate { get; set; }
        public string City { get; set; }
        public string Country { get; set; }

        /// <summary>IdentityUserRole<int>
        /// Navigation property for the roles this user belongs to.
        /// </summary>
        public virtual ICollection<IdentityUserRole<string>> Roles { get; } = new List<IdentityUserRole<string>>();

        /// <summary>
        /// Navigation property for the claims this user possesses.
        /// </summary>
        public virtual ICollection<IdentityUserClaim<string>> Claims { get; } = new List<IdentityUserClaim<string>>();

        /// <summary>
        /// Navigation property for this users login accounts.
        /// </summary>
        public virtual ICollection<IdentityUserLogin<string>> Logins { get; } = new List<IdentityUserLogin<string>>();
        //public virtual ICollection<QualityDesign> QualityDesignSampler { get; set; }
        //public virtual ICollection<QualityDesign> QualityDesignTester { get; set; }
        //public virtual ICollection<QualityDesign> QualityDesignControllerUser { get; set; }

        public virtual ICollection<IdentityUserClaim<string>> Workers { get; } = new List<IdentityUserClaim<string>>();
    }
}
