using OneUnit.Areas.Transit.Data.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OneUnit.Areas.Transit.ViewModels
{
    public class TransitInfo_Person
    {
        public Person person { get; set; }
        public TransitInfo transitinfo { get; set; }
    }
}
