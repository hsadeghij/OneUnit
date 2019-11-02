using OneUnit.Areas.Admin.Data.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OneUnit.Areas.QC.ViewModels
{
    public class UsersQualityDesignViewModel
    {
        public UsersQualityDesignViewModel()
        {
            Sampler = new List<StoreUser>();
            Tester = new List<StoreUser>();
            ControllerUser = new List<StoreUser>();
        }
        public virtual List<StoreUser> Sampler { get; set; }
        public string SamplerId { get; set; }
        //----------
        public virtual List<StoreUser> Tester { get; set; }
        public string TesterId { get; set; }
        //----------
        public virtual List<StoreUser> ControllerUser { get; set; }
        public string ControllerUserId { get; set; }
    }
}
