using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace eHeathApplication.Model
{
    public class PatientModel
    {
        public int PatientModelID { get; set; }
        public string PatientCode { get; set; }
        public string PatientName { get; set; }
        public string Address { get; set; }
        public int Age { get; set; }
        public string Problem { get; set; }
        public IEnumerable<Appointment> Appointments { get; set; }
    }
}
