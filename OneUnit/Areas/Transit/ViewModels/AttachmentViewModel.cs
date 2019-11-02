using Microsoft.AspNetCore.Http;
using OneUnit.Areas.Transit.Data.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
namespace OneUnit.Areas.Transit.ViewModels
{

    public class AttachmentViewModel
    {
        public int Id { get; set; }
        public string Description { get; set; }
        public string PicUrl { get; set; }
        public virtual ProjectPlan ProjectPlan { get; set; }
        public int? ProjectPlanId { get; set; }
        public IFormFile ImageUpload { get; set; }
    }
}
