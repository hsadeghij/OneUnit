using OneUnit.Areas.Transit.Data.Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace OneUnit.Areas.Transit.ViewModels
{
    public class PersonViewModel
    {
        public int Id { get; set; }

        [Required]
        [Display(Name = "نام")]
        public string FullName { get; set; }

        [Required]
        [Display(Name = "کد پرسنلی")]
        public string PersonalCode { get; set; }

        [Required]
        [Display(Name = "کد ملی")]
        public string NationalCode { get; set; }

        [Required]
        [Display(Name = "آدرس")]
        public string Address { get; set; }

        [Required]
        [Display(Name = "موبایل")]
        [RegularExpression("^[0-9]*$", ErrorMessage = "UPRN must be numeric")]
        public string Mobile { get; set; }

        [Display(Name = "پست")]
        public  Post Post { get; set; }
        public int? PostId { get; set; }
        public byte[] Image { get; set; }
    }
}
