using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Auto.Models;
using System.Reflection.Metadata;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.AspNetCore.Authorization;
using System.Data;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Auto.Controllers
{
    [Route("api/[controller]")]
    [EnableCors]
    [ApiController]
    public class AutoController : ControllerBase
    {
        private readonly AutoContext _context;

        public AutoController(AutoContext context)
        {
            _context = context;
            if (!_context.InsuranceType.Any())
            {
                _context.InsuranceType.Add(new InsuranceType
                {
                    Name = "kasko"

                }) ;
               
                
                _context.SaveChanges();
            }
         
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<Insurance>>> GetInsurance()
        {
            return await _context.Insurance.Include(p => p.InsuranceType).ToListAsync();
        }
        
        [HttpGet("{id}")]
        public async Task<ActionResult<InsuranceType>> GetInsuranceType(int id)
        {
            var insurancetype = await _context.InsuranceType.FindAsync(id);
            if (insurancetype == null)
            {
                return NotFound();
            }
            return insurancetype;
        }

        [HttpPost]
        public async Task<ActionResult<InsuranceType>> PostInsuranceType (InsuranceType insurancetype)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            _context.InsuranceType.Add(insurancetype);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetInsuranceType", new { id = insurancetype.Id }, insurancetype);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> PutInsuranceType(int id, InsuranceType insurancetype)
        {
            if (id != insurancetype.Id)
            {
                return BadRequest();
            }

            _context.Entry(insurancetype).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!InsuranceTypeExists(id))
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
        private bool InsuranceTypeExists(int id)
        {
            return _context.InsuranceType.Any(e => e.Id == id);
        }


        [HttpDelete("{id}")]
        [Authorize(Roles = "admin")]
        public async Task<IActionResult> DeleteInsuranceType(int id)
        {
            var insurancetype = await _context.InsuranceType.FindAsync(id);
            if (insurancetype == null)
            {
                return NotFound();
            }

            _context.InsuranceType.Remove(insurancetype);
            await _context.SaveChangesAsync();

            return NoContent();
        }
    }
}
