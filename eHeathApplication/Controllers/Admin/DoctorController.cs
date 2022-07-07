using eHeathApplication.Data;
using eHeathApplication.IRepository;
using eHeathApplication.Model;
using eHeathApplication.Repository;
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
        public async Task<IActionResult> addDoctor([FromBody] DoctorModel doctor)
        {
           var res=await _doctorRepo.AddDoctorToDb(doctor);
            return Ok(res);
        }
        [HttpPost("addschedule")]
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

    }
}
