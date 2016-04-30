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
    public class FAQController : ApiController {

        private STUFVModelContext _context = new STUFVModelContext ( );

        // GET: api/Reviews
        public async Task<IHttpActionResult> Get ( ) {
            IEnumerable<FAQ> faqs = await _context.FAQs.ToListAsync ( );

            if ( faqs == null ) {
                return NotFound ( );
            } else {
                return Ok ( faqs );
            }
        }

        // GET: api/Reviews/5
        public async Task<IHttpActionResult> Get ( int id ) {
            FAQ faq = await _context.FAQs.FindAsync ( id );

            if ( faq == null ) {
                return NotFound ( );
            } else {
                return Ok ( faq );
            }
        }

        // POST: api/Reviews
        public async Task<IHttpActionResult> Post ( FAQ value ) {
            if ( !ModelState.IsValid ) {
                return BadRequest ( ModelState );
            }

            _context.FAQs.Add ( value );
            await _context.SaveChangesAsync ( );

            return CreatedAtRoute ( "DefaultApi", new { id = value.Id }, value );
        }

        // PUT: api/Reviews/5
        public async Task<IHttpActionResult> Put ( int id, FAQ faq ) {
            if ( !ModelState.IsValid ) {
                return BadRequest ( ModelState );
            }

            if ( id != faq.Id ) {
                return BadRequest ( );
            }

            _context.Entry ( faq ).State = EntityState.Modified;

            try {
                await _context.SaveChangesAsync ( );
            } catch ( DBConcurrencyException ex ) {
                if ( !FAQExists ( id ) ) {
                    return NotFound ( );
                } else {
                    throw;
                }
            }

            return StatusCode ( HttpStatusCode.NoContent );
        }

        // DELETE: api/Reviews/5
        public async Task<IHttpActionResult> Delete ( int id ) {
            FAQ faq = await _context.FAQs.FindAsync ( id );

            if ( faq == null ) {
                return NotFound ( );
            }

            _context.FAQs.Remove ( faq );
            await _context.SaveChangesAsync ( );

            return Ok ( faq );
        }

        // Returns true if a review with the specified ID was found
        private bool FAQExists ( int id ) {
            return _context.FAQs.Find ( id ) != null;
        }
    }
}
