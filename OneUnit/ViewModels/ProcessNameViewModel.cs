﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace OneUnit.ViewModels
{
    public class ProcessNameViewModel
    {
        public int Id { get; set; }
        [Required]
        [MinLength(4)]
        public string Name { get; set; }

    }
}
