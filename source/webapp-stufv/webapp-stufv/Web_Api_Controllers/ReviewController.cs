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
    public class ReviewController : ApiController {

        private STUFVModelContext _context = new STUFVModelContext ( );

        // GET: api/Reviews
        public async Task<IHttpActionResult> Get ( ) {
            IEnumerable<Review> reviews = await _context.Reviews.ToListAsync ( );

            if (reviews == null ) {
                return NotFound ( );
            } else {
                return Ok ( reviews );
            }
        }

        // GET: api/Reviews/5
        public async Task<IHttpActionResult> Get ( int id ) {
            Review review = await _context.Reviews.FindAsync ( id );

            if (review == null ) {
                return NotFound ( );
            } else {
                return Ok ( review );
            }
        }

        // POST: api/Reviews
        public async Task<IHttpActionResult> Post ( Review value ) {
            if (!ModelState.IsValid) {
                return BadRequest ( ModelState );
            }

            _context.Reviews.Add ( value );
            await _context.SaveChangesAsync ( );

            return CreatedAtRoute ( "DefaultApi", new { id = value.Id }, value );
        }

        // PUT: api/Reviews/5
        public async Task<IHttpActionResult> Put ( int id, Review review ) {
            if ( !ModelState.IsValid ) {
                return BadRequest ( ModelState );
            }

            if (id != review.Id) {
                return BadRequest ( );
            }

            _context.Entry ( review ).State = EntityState.Modified;

            try {
                await _context.SaveChangesAsync ( );
            } catch (DBConcurrencyException ex) {
                if (!reviewExists( id ) ) {
                    return NotFound ( );
                } else {
                    throw;
                }
            }

            return StatusCode ( HttpStatusCode.NoContent );
        }

        // DELETE: api/Reviews/5
        public async Task<IHttpActionResult> Delete ( int id ) {
            Review review = await _context.Reviews.FindAsync ( id );

            if (review == null ) {
                return NotFound ( );
            }

            _context.Reviews.Remove ( review );
            await _context.SaveChangesAsync ( );

            return Ok ( review );
        }

        // Returns true if a review with the specified ID was found
        private bool reviewExists (int id) {
            return _context.Reviews.Find ( id ) != null;
        }
    }
}
