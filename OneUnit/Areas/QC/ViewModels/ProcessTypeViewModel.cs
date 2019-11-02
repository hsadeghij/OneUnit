﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace OneUnit.Areas.QC.ViewModels
{
    public class ProcessTypeViewModel
    {
        public int Id { get; set; }
        [Required]
        [Display(Name = "نوع فرآیند")]
        public string Name { get; set; }
    }
}
