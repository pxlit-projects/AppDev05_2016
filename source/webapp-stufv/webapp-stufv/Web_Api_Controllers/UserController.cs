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

namespace webapp_stufv.Web_Api_Controllers {
    public class UserController : ApiController {

        private STUFVModelContext _context = new STUFVModelContext ( );

        // GET: api/Reviews
        public async Task<IHttpActionResult> Get ( ) {
            IEnumerable<User> users = await _context.Users.ToListAsync ( );

            if ( users == null ) {
                return NotFound ( );
            } else {
                return Ok ( users );
            }
        }

        // GET: api/Reviews/5
        public async Task<IHttpActionResult> Get ( int id ) {
            User user = await _context.Users.FindAsync ( id );

            if ( user == null ) {
                return NotFound ( );
            } else {
                return Ok ( user );
            }
        }

        // POST: api/Reviews
        public async Task<IHttpActionResult> Post ( User value ) {
            if ( !ModelState.IsValid ) {
                return BadRequest ( ModelState );
            }

            _context.Users.Add ( value );
            await _context.SaveChangesAsync ( );

            return CreatedAtRoute ( "DefaultApi", new { id = value.Id }, value );
        }

        // PUT: api/Reviews/5
        public async Task<IHttpActionResult> Put ( int id, User user ) {
            if ( !ModelState.IsValid ) {
                return BadRequest ( ModelState );
            }

            if ( id != user.Id ) {
                return BadRequest ( );
            }

            _context.Entry ( user ).State = EntityState.Modified;

            try {
                await _context.SaveChangesAsync ( );
            } catch ( DBConcurrencyException ex ) {
                if ( !userExists ( id ) ) {
                    return NotFound ( );
                } else {
                    throw;
                }
            }

            return StatusCode ( HttpStatusCode.NoContent );
        }

        // DELETE: api/Reviews/5
        public async Task<IHttpActionResult> Delete ( int id ) {
            User user = await _context.Users.FindAsync ( id );

            if ( user == null ) {
                return NotFound ( );
            }

            _context.Users.Remove ( user );
            await _context.SaveChangesAsync ( );

            return Ok ( user );
        }

        // Returns true if a review with the specified ID was found
        private bool userExists ( int id ) {
            return _context.Users.Find ( id ) != null;
        }
    }
}
