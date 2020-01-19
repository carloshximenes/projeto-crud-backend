using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ProjetoCRUDBackend.Models;

namespace ProjetoCRUDBackend.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PersonDetailsController : ControllerBase
    {
        private readonly PersonDetailContext _context;

        public PersonDetailsController(PersonDetailContext context)
        {
            _context = context;
        }

        // GET: api/PersonDetails
        [HttpGet]
        public IEnumerable<PersonDetail> GetPersonDetails()
        {
            return _context.PersonDetails;
        }

        // GET: api/PersonDetails/5
        [HttpGet("{id}")]
        public async Task<IActionResult> GetPersonDetail([FromRoute] int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var personDetail = await _context.PersonDetails.FindAsync(id);

            if (personDetail == null)
            {
                return NotFound();
            }

            return Ok(personDetail);
        }

        // PUT: api/PersonDetails/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutPersonDetail([FromRoute] int id, [FromBody] PersonDetail personDetail)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != personDetail.PersonId)
            {
                return BadRequest();
            }

            _context.Entry(personDetail).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!PersonDetailExists(id))
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

        // POST: api/PersonDetails
        [HttpPost]
        public async Task<IActionResult> PostPersonDetail([FromBody] PersonDetail personDetail)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            _context.PersonDetails.Add(personDetail);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetPersonDetail", new { id = personDetail.PersonId }, personDetail);
        }

        // DELETE: api/PersonDetails/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeletePersonDetail([FromRoute] int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var personDetail = await _context.PersonDetails.FindAsync(id);
            if (personDetail == null)
            {
                return NotFound();
            }

            var allContacts = _context.ContactList.Where(contact => contact.ContactPersonId == id);

            _context.ContactList.RemoveRange(allContacts);
            _context.PersonDetails.Remove(personDetail);
            await _context.SaveChangesAsync();

            return Ok(personDetail);
        }

        private bool PersonDetailExists(int id)
        {
            return _context.PersonDetails.Any(e => e.PersonId == id);
        }
    }
}