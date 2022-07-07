using eHeathApplication.IRepository;
using eHeathApplication.Model;
using eHeathApplication.Repository;
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
    public class PatientController : ControllerBase
    {
        private readonly IPatientRepo _patientRepo;
        public PatientController(IPatientRepo patientRepo)
        {
            _patientRepo = patientRepo;
        }

        [HttpPost("addPatient")]
        public async Task<IActionResult> addPatient([FromBody] PatientModel patient)
        {
            var res = await _patientRepo.AddPatientToDb(patient);
            return Ok(res);
        }
    }
}
