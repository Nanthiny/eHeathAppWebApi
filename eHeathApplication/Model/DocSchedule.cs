using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace eHeathApplication.Model
{
    public class DocSchedule
    {
        [Key]
        public int DocScheduleID { get; set; }
        [ForeignKey("ID")]
        public int DoctorID { get; set; }
        public virtual Doctor Doctor { get; set; }
        public DateTime AvailableDate { get; set; }
    }
}
