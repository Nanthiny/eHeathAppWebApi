using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace eHeathApplication.Model
{
    public class OnlineAppointment
    {
        [Key]
        public int OnlineAppointmentID { get; set; }
        public string PatientName { get; set; }
        public int Age { get; set; }
        public string Address { get; set; }
        public DateTime AppointmentDate { get; set; }
        public bool AppointmentStatus { get; set; }
        public string Problem { get; set; }
        public int DoctorModelID { get; set; }
        public DoctorModel Doctor { get; set; }
    }
}
