using eHeathApplication.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace eHeathApplication.IRepository
{
   public interface IOnlineAppointmentRepo
    {
        public Task<OnlineAppointment> addAppointment(OnlineAppointment apt);
        public Task<OnlineAppointment> changeAppointment(OnlineAppointment apt);
    }
}
