using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web.Http;
using webapp_stufv.Models;


namespace webapp_stufv.Web_Api_Controllers
{
    public class partnerController : ApiController
    {
        private STUFVModelContext _context = new STUFVModelContext();

        // GET: api/Reviews
        public async Task<IHttpActionResult> Get()
        {
            IEnumerable<Partner> partners = await _context.Partners.ToListAsync();

            if (partners == null)
            {
                return NotFound();
            }
            else {
                return Ok(partners);
            }
        }

        // GET: api/Reviews/5
        public async Task<IHttpActionResult> Get(int id)
        {
            Partner partner = await _context.Partners.FindAsync(id);

            if (partner == null)
            {
                return NotFound();
            }
            else {
                return Ok(partner);
            }
        }

        // POST: api/Reviews
        public async Task<IHttpActionResult> Post(Partner partner)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            _context.Partners.Add(partner);
            await _context.SaveChangesAsync();

            return CreatedAtRoute("DefaultApi", new { id = partner.Id }, partner);
        }

        // PUT: api/Reviews/5
        public async Task<IHttpActionResult> Put(int id, Partner partner)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != partner.Id)
            {
                return BadRequest();
            }

            _context.Entry(partner).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DBConcurrencyException ex)
            {
                if (!partnerExists(id))
                {
                    return NotFound();
                }
                else {
                    throw;
                }
            }

            return StatusCode(HttpStatusCode.NoContent);
        }

        // DELETE: api/Reviews/5
        public async Task<IHttpActionResult> Delete(int id)
        {
            Partner partner = await _context.Partners.FindAsync(id);

            if (partner == null)
            {
                return NotFound();
            }

            _context.Partners.Remove(partner);
            await _context.SaveChangesAsync();

            return Ok(partner);
        }

        // Returns true if a review with the specified ID was found
        private bool partnerExists(int id)
        {
            return _context.Partners.Find(id) != null;
        }
    }
}
