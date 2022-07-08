using eHeathApplication.Data;
using eHeathApplication.IRepository;
using eHeathApplication.Model;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace eHeathApplication.Repository
{
    public class DoctorRepo : IDoctorRepository
    {
        private readonly ApplicationDbContext _db;
        public DoctorRepo(ApplicationDbContext db)
        {
            _db = db;
        }
        public async Task<DoctorModel> AddDoctorToDb(DoctorModel model)
        {
           _db.DoctorModels.Add(model);
            await _db.SaveChangesAsync();
            return model;
        }

        public async Task<Schedule> addSchedule(Schedule sch)
        {
            _db.Schedule.Add(sch);
            await _db.SaveChangesAsync();
            return sch;
        }

        public async Task<IEnumerable<DoctorModel>> getAllDoctors()
        {
           var doctorlist= await _db.DoctorModels.Include(s=>s.Schedules).ToListAsync();
            return doctorlist;
        }

        public async Task<IEnumerable<OnlineAppointment>> getAppointments(int docid)
        {
            var aptlist=await _db.OnlineAppointments.Where(d => d.DoctorModelID == docid).ToListAsync();
            return aptlist;
        }

        public async Task<DoctorModel> getDoctorbyid(int id)
        {
         DoctorModel doct=  await _db.DoctorModels.Include(s => s.Schedules).FirstOrDefaultAsync(d => d.DoctorModelID == id);
            return doct;
        }
    }
}
