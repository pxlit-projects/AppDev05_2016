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
    public class LoginController : ApiController
    {
        private STUFVModelContext _context = new STUFVModelContext();

        // GET: api/Reviews
        public async Task<IHttpActionResult> Get()
        {
            IEnumerable<Login> logins = await _context.Logins.ToListAsync();

            if (logins == null)
            {
                return NotFound();
            }
            else {
                return Ok(logins);
            }
        }

        // GET: api/Reviews/5
        public async Task<IHttpActionResult> Get(int id)
        {
            Login user = await _context.Logins.FindAsync(id);

            if (user == null)
            {
                return NotFound();
            }
            else {
                return Ok(user);
            }
        }

        // POST: api/Reviews
        public async Task<IHttpActionResult> Post(Login value)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            _context.Logins.Add(value);
            await _context.SaveChangesAsync();

            return CreatedAtRoute("DefaultApi", new { id = value.Id }, value);
        }

        // PUT: api/Reviews/5
        public async Task<IHttpActionResult> Put(int id, Login login)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != login.Id)
            {
                return BadRequest();
            }

            _context.Entry(login).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DBConcurrencyException ex)
            {
                if (!LoginExists(id))
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
            Login login = await _context.Logins.FindAsync(id);

            if (login == null)
            {
                return NotFound();
            }

            _context.Logins.Remove(login);
            await _context.SaveChangesAsync();

            return Ok(login);
        }

        private bool LoginExists(int id)
        {
            return _context.Logins.Find(id) != null;
        }
    }
}
