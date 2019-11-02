using OneUnit.Data.Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace OneUnit.Areas.QC.Data.Entities
{
    [Table("QualityControl", Schema = "QC")]
    public class QualityControl
    {
        public int Id { get; set; }
        //----------------
        public virtual Year Year { get; set; }
        public byte YearId { get; set; }
        //----------------

        public virtual Month Month { get; set; }
        public byte MonthId { get; set; }
        //---------------
        public virtual Day Day { get; set; }
        public byte DayId { get; set; }
        //---------------
        public virtual Shift Shift { get; set; }
        public byte ShiftId { get; set; }
        //---------------
        public virtual Hour Hour { get; set; }
        public byte HourId { get; set; }
        //---------------

    }
}
