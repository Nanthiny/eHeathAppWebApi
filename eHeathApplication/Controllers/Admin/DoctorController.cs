using eHeathApplication.Data;
using eHeathApplication.IRepository;
using eHeathApplication.Model;
using eHeathApplication.Repository;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace eHeathApplication.Controllers.Admin
{
    [Route("api/[controller]")]
    [ApiController]
    [EnableCors("MyPolicy")]
    public class DoctorController : ControllerBase
    {
        private readonly IDoctorRepository _doctorRepo;
        public DoctorController(IDoctorRepository doctorRepo)
        {
            _doctorRepo = doctorRepo;
        }
        [HttpPost("adddoctor")]
        public async Task<IActionResult> addDoctor([FromBody] DoctorRegisterModel doctor)
        {
            var res = await _doctorRepo.AddDoctorToDb(doctor);
            return Ok(res);
        }
        [HttpPost("logindoctor")]
        public async Task<IActionResult> Authdoctor([FromBody] Signinrequest request)
        {
            var res = await _doctorRepo.AuthenticateDoctor(request.docCode, request.password);
            return Ok(res);
        }
        [HttpPost("addschedule")]
        [Authorize]
        public async Task<IActionResult> addSchedule([FromBody] Schedule schedule)
        {
            var res = await _doctorRepo.addSchedule(schedule);
            return Ok(res);
        }
        [HttpGet]
        public async Task<ActionResult<IEnumerable<DoctorModel>>> getDoctors()
        {
            var res = await _doctorRepo.getAllDoctors();
            return Ok(res);
        }
        [HttpGet("{id}")]
        public async Task<ActionResult<DoctorModel>> getDoctorbyID([FromRoute] int id)
        {
            var res = await _doctorRepo.getDoctorbyid(id);
            return Ok(res);
        }
        [HttpGet("viewappointments/{docid}")]
        [Authorize(Roles ="Doctor")]
        public async Task<ActionResult<IEnumerable<OnlineAppointment>>> getAppointments([FromRoute] int docid)
        {
            var res = await _doctorRepo.getAppointments(docid);
            return Ok(res);
        }
        [HttpGet("getschedules/{id}")]
        [Authorize(Roles = "Admin")]
        public async Task<ActionResult<IEnumerable<Schedule>>> getSchedules([FromRoute] int id)
        {
            var res = await _doctorRepo.getSchedules(id);
            return Ok(res);
        }
        [HttpGet("getschedule/{id}")]
        [Authorize]
        public async Task<ActionResult<IEnumerable<Schedule>>> getSchedulebyid([FromRoute] int id)
        {
            var res = await _doctorRepo.getSchedulebyid(id);
            return Ok(res);
        }
    }
    
}
