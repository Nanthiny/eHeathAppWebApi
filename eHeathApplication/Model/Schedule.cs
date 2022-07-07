using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace eHeathApplication.Model
{
    public class Schedule
    {
        [Key]
        public int DocScheduleID { get; set; }
        [ForeignKey("DoctorModelID")]
        public int DoctorID { get; set; }
        public virtual DoctorModel Doctor { get; set; }
        public DateTime AvailableDate { get; set; }
    }
}
