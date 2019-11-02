using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace OneUnit.ViewModels
{
    public class ContactViewModel
    {
        [Required]
        [MinLength(5,ErrorMessage ="نام باید 5 کاراتر یا بیشتر باشد.")]
        public string Name { get; set; }
        [Required]
        [EmailAddress]
        public string Email { get; set; }
        [Required]
        public string Subject { get; set; }
        [Required]
        [MaxLength(250,ErrorMessage ="کاراکترها بیشتر از حد مجاز است")]
        public string Message { get; set; }

    }
}
