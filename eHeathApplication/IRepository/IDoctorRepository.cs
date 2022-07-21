using eHeathApplication.Model;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace eHeathApplication.IRepository
{
    public interface IDoctorRepository
    {
        public Task<DoctorModel> AddDoctorToDb(DoctorRegisterModel model);
        public Task<SigninResponse> AuthenticateDoctor(string docCode, string password);
        public Task<IEnumerable<DoctorModel>> getAllDoctors();
        public Task<ScheduleResponse> addSchedule(Schedule sch);
        public Task<IEnumerable<OnlineAppointment>> getAppointments(int docid);
        public Task<IEnumerable<Schedule>> getSchedules(int id);
        public Task<Schedule> getSchedulebyid(int id);
        public Task<DoctorModel> getDoctorbyid(int id);
    }
}
