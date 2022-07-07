using eHeathApplication.Data;
using eHeathApplication.IRepository;
using eHeathApplication.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace eHeathApplication.Repository
{
    public class PatientRepo : IPatientRepo
    {
        private readonly ApplicationDbContext _db;
        public PatientRepo(ApplicationDbContext db)
        {
            _db = db;
        }
        public async Task<PatientModel> AddPatientToDb(PatientModel model)
        {
            _db.PatientModels.Add(model);
            await _db.SaveChangesAsync();
            return model;
        }
    }
}
