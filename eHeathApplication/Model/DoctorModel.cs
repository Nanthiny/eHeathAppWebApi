using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace eHeathApplication.Model
{
    public class DoctorModel
    {
        [Key]
        public int DoctorModelID { get; set; }
        public string DoctorCode { get; set; }
        public string DoctorName { get; set; }
        public string DoctorPassword { get; set; }
        public string Address { get; set; }
        public int Age { get; set; }
        public string Qualification { get; set; }
        public int Experience { get; set; }
        public int DepartmentID { get; set; }
        public virtual Department Department { get; set; }
        public IEnumerable<Schedule> Schedules { get; set; }
        public IEnumerable<OnlineAppointment> Appointments { get; set; }

    }
}
