using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using eHeathApplication.Data;
using eHeathApplication.Model;
using eHeathApplication.IRepository;
using Microsoft.AspNetCore.Cors;

namespace eHeathApplication.Controllers.Appointment
{
    [Route("api/[controller]")]
    [ApiController]
    [EnableCors("MyPolicy")]
    public class OnlineAppointmentsController : ControllerBase
    {
        private readonly IOnlineAppointmentRepo _onlineapt;

        public OnlineAppointmentsController(IOnlineAppointmentRepo onlineapt)
        {
            _onlineapt = onlineapt;
        }
        [HttpPost("addappointment")]
        public async Task<ActionResult<OnlineAppointment>> AddOnlineAppointment([FromBody] OnlineAppointment onlineAppointment)
        {
           var apt= await _onlineapt.addAppointment(onlineAppointment);
          

            return CreatedAtAction("GetOnlineAppointment", new { id = onlineAppointment.OnlineAppointmentID }, onlineAppointment);
        }


        // GET: api/OnlineAppointments

        // GET: api/OnlineAppointments/5

        [HttpGet("{id}")]
        public async Task<ActionResult<OnlineAppointment>> GetOnlineAppointment(int id)
        {
            var onlineAppointment = await _onlineapt.getAppointment(id);

            if (onlineAppointment == null)
            {
                return NotFound();
            }

            return onlineAppointment;
        }
        /*

        // PUT: api/OnlineAppointments/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutOnlineAppointment(int id, OnlineAppointment onlineAppointment)
        {
            if (id != onlineAppointment.OnlineAppointmentID)
            {
                return BadRequest();
            }

            _context.Entry(onlineAppointment).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!OnlineAppointmentExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return NoContent();
        }

        // POST: api/OnlineAppointments
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<OnlineAppointment>> PostOnlineAppointment(OnlineAppointment onlineAppointment)
        {
            _context.OnlineAppointments.Add(onlineAppointment);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetOnlineAppointment", new { id = onlineAppointment.OnlineAppointmentID }, onlineAppointment);
        }

        // DELETE: api/OnlineAppointments/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteOnlineAppointment(int id)
        {
            var onlineAppointment = await _context.OnlineAppointments.FindAsync(id);
            if (onlineAppointment == null)
            {
                return NotFound();
            }

            _context.OnlineAppointments.Remove(onlineAppointment);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool OnlineAppointmentExists(int id)
        {
            return _context.OnlineAppointments.Any(e => e.OnlineAppointmentID == id);
        }*/
    }
}
