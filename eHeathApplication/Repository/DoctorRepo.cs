using eHeathApplication.Data;
using eHeathApplication.Helpers;
using eHeathApplication.IRepository;
using eHeathApplication.Model;

using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
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
        public async Task<DoctorModel> AddDoctorToDb(DoctorRegisterModel model)
        {
            byte[] passwordhash, passwordkey;
            DoctorModel docmodel = new DoctorModel();
            if (model != null)
            {
                using (var hmac = new HMACSHA512())
                {
                    passwordkey = hmac.Key;
                    passwordhash = hmac.ComputeHash(System.Text.Encoding.UTF8.GetBytes(model.Password));
                    

                }
                docmodel.DoctorCode = model.DoctorCode;
                docmodel.DepartmentID = model.DepartmentID;
                docmodel.DoctorName = model.DoctorName;
                docmodel.Qualification = model.Qualification;
                docmodel.Role = "Doctor";
                docmodel.Address = model.Address;
                docmodel.Age = model.Age;
                docmodel.Experience = model.Experience;
                docmodel.Password = passwordhash;
                docmodel.PasswordKey = passwordkey;
            }
          
            _db.DoctorModels.Add(docmodel);
            await _db.SaveChangesAsync();
            return docmodel;
        }

        public async Task<ScheduleResponse> addSchedule(Schedule sch)
        {
            _db.Schedule.Add(sch);           
            await _db.SaveChangesAsync();
            ScheduleResponse res = new ScheduleResponse();
            if (sch!=null) {
                res.Success = true;
                res.Message = "Successfully added";
            }
            else
            {
                res.Success = false;
                res.Message = "Failed";
            }
            return res;
        }

        public async Task<SigninResponse> AuthenticateDoctor(string docCode,string password)
        {
            var doctor = await _db.DoctorModels.FirstOrDefaultAsync(x => x.DoctorCode == docCode);
            AuthHelper helper = new AuthHelper();
            if (doctor == null)
            {
                return new SigninResponse
                {
                    Success = false,
                    Message = "User not exist"
                };
            }
            if (!helper.MatchPassword(password, doctor.Password, doctor.PasswordKey))
            {
                return new SigninResponse
                {
                    Success = false,
                    Message = "User password not match"
                };
            }

           
            string tokenString = helper.Generatetoken();
            return new SigninResponse
            {
                Success = true,
                Message = "Successfully login",
                token = tokenString,
                userId = doctor.DoctorModelID,
                Firstname = doctor.DoctorName,
                Role=doctor.Role
            };
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

        public async Task<IEnumerable<Schedule>> getSchedules(int id)
        {
            var res = await _db.Schedule.Where(d => d.DoctorID == id).ToListAsync();
            return res;
        }
    }
}
