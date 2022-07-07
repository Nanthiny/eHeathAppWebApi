using eHeathApplication.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace eHeathApplication.IRepository
{
    public interface IPatientRepo
    {
        public Task<PatientModel> AddPatientToDb(PatientModel model);
    }
}
