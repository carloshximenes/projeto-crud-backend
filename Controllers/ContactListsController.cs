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
    public class ContactListsController : ControllerBase
    {
        private readonly PersonDetailContext _context;

        public ContactListsController(PersonDetailContext context)
        {
            _context = context;
        }

        // GET: api/ContactLists/5
        [HttpGet("{id}")]
        public IEnumerable<ContactList> GetContactList([FromRoute] int id)
        {
            return //_context.ContactList;
            _context.ContactList.Where(contact => contact.ContactPersonId == id);
        }

        /*
        // GET: api/ContactLists/5
        [HttpGet("{id}")]
        public async Task<IActionResult> GetContactList([FromRoute] int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var contactList = await _context.ContactList.FindAsync(id);

            if (contactList == null)
            {
                return NotFound();
            }

            return Ok(contactList);
        }
*/

        // PUT: api/ContactLists/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutContactList([FromRoute] int id, [FromBody] ContactList contactList)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != contactList.ContactId)
            {
                return BadRequest();
            }

            _context.Entry(contactList).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ContactListExists(id))
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

        // POST: api/ContactLists
        [HttpPost]
        public async Task<IActionResult> PostContactList([FromBody] ContactList contactList)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            _context.ContactList.Add(contactList);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetContactList", new { id = contactList.ContactId }, contactList);
        }

        // DELETE: api/ContactLists/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteContactList([FromRoute] int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var contactList = await _context.ContactList.FindAsync(id);
            if (contactList == null)
            {
                return NotFound();
            }

            _context.ContactList.Remove(contactList);
            await _context.SaveChangesAsync();

            return Ok(contactList);
        }

        private bool ContactListExists(int id)
        {
            return _context.ContactList.Any(e => e.ContactId == id);
        }
    }
}