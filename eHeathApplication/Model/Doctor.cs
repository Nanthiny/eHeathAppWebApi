using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace eHeathApplication.Model
{
    public class Doctor
    {
        
        public int ID { get; set; }
        public string DocCode { get; set; }
        public string DoctorName { get; set; }
        public string DoctorPassword { get; set; }
        public string Address { get; set; }
        public int Age { get; set; }
        public int DepartmentID { get; set; }
        public string Qualification { get; set; }
        public int Experience { get; set; }
        public Department Department { get; set; }
        public IEnumerable<DocSchedule> Schedules { get; set; }
    }
}
