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
    public class CityController : ApiController
    {
        private STUFVModelContext _context = new STUFVModelContext();

        // GET: api/City
        public async Task<IHttpActionResult> Get()
        {
            IEnumerable<Cities> cities = await _context.Cities.ToListAsync();

            if (cities == null)
            {
                return NotFound();
            }
            else {
                return Ok(cities);
            }
        }

        // GET: api/City/5
        public async Task<IHttpActionResult> Get(string id)
        {
            Cities city = await _context.Cities.FindAsync(id);

            if (city == null)
            {
                return NotFound();
            }
            else {
                return Ok(city);
            }
        }

        // POST: api/City
        public async Task<IHttpActionResult> Post(Cities value)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            _context.Cities.Add(value);
            await _context.SaveChangesAsync();

            return CreatedAtRoute("DefaultApi", new { id = value.ZipCode }, value);
        }

        // PUT: api/City/5
        public async Task<IHttpActionResult> Put(string id, Cities city)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != city.ZipCode)
            {
                return BadRequest();
            }

            _context.Entry(city).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DBConcurrencyException ex)
            {
                if (!cityExists(id))
                {
                    return NotFound();
                }
                else {
                    throw;
                }
            }

            return StatusCode(HttpStatusCode.NoContent);
        }

        // DELETE: api/City/5
        public async Task<IHttpActionResult> Delete(string id)
        {
            Cities city = await _context.Cities.FindAsync(id);

            if (city == null)
            {
                return NotFound();
            }

            _context.Cities.Remove(city);
            await _context.SaveChangesAsync();

            return Ok(city);
        }

        // Returns true if a review with the specified ID was found
        private bool cityExists(string id)
        {
            return _context.Cities.Find(id) != null;
        }
    }
}
