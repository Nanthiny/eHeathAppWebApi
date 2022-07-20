using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace eHeathApplication.Model
{
    public class DoctorRegisterModel
    {
        public string DoctorCode { get; set; }
        public string DoctorName { get; set; }
        public string Password { get; set; }
        public string Address { get; set; }
        public int Age { get; set; }
        public string Qualification { get; set; }
        public int Experience { get; set; }
        public int DepartmentID { get; set; }
        public string Role { get; set; }
        public virtual Department Department { get; set; }
        public IEnumerable<Schedule> Schedules { get; set; }
        public IEnumerable<OnlineAppointment> Appointments { get; set; }
    }
}
