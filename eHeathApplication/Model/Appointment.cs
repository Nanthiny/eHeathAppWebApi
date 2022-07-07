using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace eHeathApplication.Model
{
    public class Appointment
    {
        [Key]
        public int AppintmentID { get; set; }
        public int PatientModelID { get; set; }
        public int DoctorModelID { get; set; }
        public string Problem { get; set; }
        public DoctorModel Doctor { get; set; }
        public PatientModel Patient { get; set; }
    }
}
