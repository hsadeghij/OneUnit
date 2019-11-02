using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OneUnit.Areas.Transit.ViewModels
{
    public class ModalFooter
    {
        public string SubmitButtonText { get; set; } = "ذخیره";
        public string CancelButtonText { get; set; } = "رد کردن";
        public string SubmitButtonID { get; set; } = "btn-submit";
        public string CancelButtonID { get; set; } = "btn-cancel";
        public bool OnlyCancelButton { get; set; }
    }
}
