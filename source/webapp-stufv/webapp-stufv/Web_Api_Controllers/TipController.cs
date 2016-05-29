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
    public class TipController : ApiController
    {
        private STUFVModelContext _context = new STUFVModelContext( );

        // GET: api/Reviews
        public async Task<IHttpActionResult> Get()
        {
            IEnumerable<Tip> tips = await _context.Tips.ToListAsync();

            if (tips == null)
            {
                return NotFound();
            }
            else {
                return Ok(tips);
            }
        }

        // GET: api/Reviews/5
        public async Task<IHttpActionResult> Get(int id)
        {
            Tip tip = await _context.Tips.FindAsync(id);

            if (tip == null)
            {
                return NotFound();
            }
            else {
                return Ok(tip);
            }
        }

        // POST: api/Reviews
        public async Task<IHttpActionResult> Post(Tip tip)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            _context.Tips.Add(tip);
            await _context.SaveChangesAsync();

            return CreatedAtRoute("DefaultApi", new { id = tip.Id }, tip);
        }

        // PUT: api/Reviews/5
        public async Task<IHttpActionResult> Put(int id, Tip tip)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != tip.Id)
            {
                return BadRequest();
            }

            _context.Entry(tip).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DBConcurrencyException ex)
            {
                if (!TipExists(id))
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
            Tip tip = await _context.Tips.FindAsync(id);

            if (tip == null)
            {
                return NotFound();
            }

            _context.Tips.Remove(tip);
            await _context.SaveChangesAsync();

            return Ok(tip);
        }

        // Returns true if a review with the specified ID was found
        private bool TipExists(int id)
        {
            return _context.Tips.Find(id) != null;
        }
    }
}
