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
    public class GuidelineController : ApiController {

        private STUFVModelContext _context = new STUFVModelContext ( );

        // GET: api/Reviews
        public async Task<IHttpActionResult> Get ( ) {
            IEnumerable<Guideline> guidelines = await _context.Guidelines.ToListAsync ( );

            if ( guidelines == null ) {
                return NotFound ( );
            } else {
                return Ok ( guidelines );
            }
        }

        // GET: api/Reviews/5
        public async Task<IHttpActionResult> Get ( int id ) {
            Guideline guideline = await _context.Guidelines.FindAsync ( id );

            if ( guideline == null ) {
                return NotFound ( );
            } else {
                return Ok ( guideline );
            }
        }

        // POST: api/Reviews
        public async Task<IHttpActionResult> Post ( Guideline value ) {
            if ( !ModelState.IsValid ) {
                return BadRequest ( ModelState );
            }

            _context.Guidelines.Add ( value );
            await _context.SaveChangesAsync ( );

            return CreatedAtRoute ( "DefaultApi", new { id = value.Id }, value );
        }

        // PUT: api/Reviews/5
        public async Task<IHttpActionResult> Put ( int id, Guideline guideline ) {
            if ( !ModelState.IsValid ) {
                return BadRequest ( ModelState );
            }

            if ( id != guideline.Id ) {
                return BadRequest ( );
            }

            _context.Entry ( guideline ).State = EntityState.Modified;

            try {
                await _context.SaveChangesAsync ( );
            } catch ( DBConcurrencyException ex ) {
                if ( !GuidelineExists ( id ) ) {
                    return NotFound ( );
                } else {
                    throw;
                }
            }

            return StatusCode ( HttpStatusCode.NoContent );
        }

        // DELETE: api/Reviews/5
        public async Task<IHttpActionResult> Delete ( int id ) {
            Guideline guideline = await _context.Guidelines.FindAsync ( id );

            if ( guideline == null ) {
                return NotFound ( );
            }

            _context.Guidelines.Remove ( guideline );
            await _context.SaveChangesAsync ( );

            return Ok ( guideline );
        }

        // Returns true if a review with the specified ID was found
        private bool GuidelineExists ( int id ) {
            return _context.Guidelines.Find ( id ) != null;
        }
    }
}
