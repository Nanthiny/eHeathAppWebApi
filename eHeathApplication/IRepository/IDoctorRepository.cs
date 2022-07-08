using eHeathApplication.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace eHeathApplication.IRepository
{
    public interface IDoctorRepository
    {
        public Task<DoctorModel> AddDoctorToDb(DoctorModel model);
        public Task<IEnumerable<DoctorModel>> getAllDoctors();
        public Task<Schedule> addSchedule(Schedule sch);
        public Task<IEnumerable<OnlineAppointment>> getAppointments(int docid);
        public Task<DoctorModel> getDoctorbyid(int id);
    }
}
