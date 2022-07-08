using eHeathApplication.Data;
using eHeathApplication.IRepository;
using eHeathApplication.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace eHeathApplication.Repository
{

    public class OnlineAppointmentRepo : IOnlineAppointmentRepo
    {
        private readonly ApplicationDbContext _db;
        public OnlineAppointmentRepo(ApplicationDbContext db)
        {
            _db = db;
        }
        public async Task<OnlineAppointment> addAppointment(OnlineAppointment apt)
        {
            _db.OnlineAppointments.Add(apt);
            await _db.SaveChangesAsync();
            return apt;
        }

        public Task<OnlineAppointment> changeAppointment(OnlineAppointment apt)
        {
            throw new NotImplementedException();
        }

        public async Task<OnlineAppointment> getAppointment(int id)
        {
           OnlineAppointment apt= await _db.OnlineAppointments.FindAsync(id);
            return apt;
        }
    }
}
