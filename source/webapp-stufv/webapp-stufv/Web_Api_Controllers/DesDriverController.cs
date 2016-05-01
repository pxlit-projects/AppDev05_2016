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
    public class DesDriverController : ApiController {

        private STUFVModelContext _context = new STUFVModelContext ( );

        // GET: api/Reviews
        public async Task<IHttpActionResult> Get ( ) {
            IEnumerable<DesDriver> desdrivers = await _context.DesDrivers.ToListAsync ( );

            if ( desdrivers == null ) {
                return NotFound ( );
            } else {
                return Ok ( desdrivers );
            }
        }

        // GET: api/Reviews/5
        public async Task<IHttpActionResult> Get ( int id ) {
            DesDriver desdriver = await _context.DesDrivers.FindAsync ( id );

            if ( desdriver == null ) {
                return NotFound ( );
            } else {
                return Ok ( desdriver );
            }
        }

        // POST: api/Reviews
        public async Task<IHttpActionResult> Post ( DesDriver value ) {
            if ( !ModelState.IsValid ) {
                return BadRequest ( ModelState );
            }

            _context.DesDrivers.Add ( value );
            await _context.SaveChangesAsync ( );

            return CreatedAtRoute ( "DefaultApi", new { id = value.Id }, value );
        }

        // PUT: api/Reviews/5
        public async Task<IHttpActionResult> Put ( int id, DesDriver desdriver ) {
            if ( !ModelState.IsValid ) {
                return BadRequest ( ModelState );
            }

            if ( id != desdriver.Id ) {
                return BadRequest ( );
            }

            _context.Entry ( desdriver ).State = EntityState.Modified;

            try {
                await _context.SaveChangesAsync ( );
            } catch ( DBConcurrencyException ex ) {
                if ( !DesDriverExists ( id ) ) {
                    return NotFound ( );
                } else {
                    throw;
                }
            }

            return StatusCode ( HttpStatusCode.NoContent );
        }

        // DELETE: api/Reviews/5
        public async Task<IHttpActionResult> Delete ( int id ) {
            DesDriver desdriver = await _context.DesDrivers.FindAsync ( id );

            if ( desdriver == null ) {
                return NotFound ( );
            }

            _context.DesDrivers.Remove ( desdriver );
            await _context.SaveChangesAsync ( );

            return Ok ( desdriver );
        }

        // Returns true if a review with the specified ID was found
        private bool DesDriverExists ( int id ) {
            return _context.DesDrivers.Find ( id ) != null;
        }
    }
}
