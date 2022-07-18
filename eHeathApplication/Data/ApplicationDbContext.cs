
using eHeathApplication.Model;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace eHeathApplication.Data
{
    public class ApplicationDbContext:DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options): base(options)
        {

        }

        public DbSet<Doctor> Doctors { get; set; }
        public DbSet<DoctorModel> DoctorModels { get; set; }
        //  public DbSet<HospitalDoctor> HospitalDoctors { get; set; }
        public DbSet<Department> Departments { get; set; }
        public DbSet<PatientModel> PatientModels { get; set; }
        public DbSet<Appointment> Appointments { get; set; }
        public DbSet<DocSchedule> DoctorSchedules { get; set; }
        public DbSet<Schedule> Schedule { get; set; }
        public DbSet<OnlineAppointment> OnlineAppointments { get; set; }
        public DbSet<User> Users { get; set; }
    }
}
