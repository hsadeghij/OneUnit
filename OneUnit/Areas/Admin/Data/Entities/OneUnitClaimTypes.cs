using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OneUnit.Areas.Admin.Data.Entities
{
    public class OneUnitClaimTypes
    {
        public static List<string> ClaimsList { get; set; } = new List<string> { "Delete ProcessName", "Add ProcessName", "Age for ordering", "Add ProcessName1" };
    }
}
