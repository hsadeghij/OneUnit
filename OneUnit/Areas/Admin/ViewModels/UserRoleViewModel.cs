using OneUnit.Areas.Admin.Data.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OneUnit.Areas.Admin.ViewModels
{
    public class UserRoleViewModel
    {
        public UserRoleViewModel()
        {
            Users = new List<StoreUser>();
        }
        public string UserId { get; set; }
        public string RoleId { get; set; }
        public List<StoreUser> Users { get; set; }
    }
}
