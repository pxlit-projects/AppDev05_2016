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
    public class EmergencyController : ApiController {

        private STUFVModelContext _context = new STUFVModelContext ( );

        // GET: api/Reviews
        public async Task<IHttpActionResult> Get ( ) {
            IEnumerable<Emergency> emergencies = await _context.Emergencies.ToListAsync ( );

            if ( emergencies == null ) {
                return NotFound ( );
            } else {
                return Ok ( emergencies );
            }
        }

        // GET: api/Reviews/5
        public async Task<IHttpActionResult> Get ( int id ) {
            Emergency emergency = await _context.Emergencies.FindAsync ( id );

            if ( emergency == null ) {
                return NotFound ( );
            } else {
                return Ok ( emergency );
            }
        }

        // POST: api/Reviews
        public async Task<IHttpActionResult> Post ( Emergency value ) {
            if ( !ModelState.IsValid ) {
                return BadRequest ( ModelState );
            }

            _context.Emergencies.Add ( value );
            await _context.SaveChangesAsync ( );

            return CreatedAtRoute ( "DefaultApi", new { id = value.Id }, value );
        }

        // PUT: api/Reviews/5
        public async Task<IHttpActionResult> Put ( int id, Emergency emergency ) {
            if ( !ModelState.IsValid ) {
                return BadRequest ( ModelState );
            }

            if ( id != emergency.Id ) {
                return BadRequest ( );
            }

            _context.Entry ( emergency ).State = EntityState.Modified;

            try {
                await _context.SaveChangesAsync ( );
            } catch ( DBConcurrencyException ex ) {
                if ( !EmergencyExists ( id ) ) {
                    return NotFound ( );
                } else {
                    throw;
                }
            }

            return StatusCode ( HttpStatusCode.NoContent );
        }

        // DELETE: api/Reviews/5
        public async Task<IHttpActionResult> Delete ( int id ) {
            Emergency emergency = await _context.Emergencies.FindAsync ( id );

            if ( emergency == null ) {
                return NotFound ( );
            }

            _context.Emergencies.Remove ( emergency );
            await _context.SaveChangesAsync ( );

            return Ok ( emergency );
        }

        // Returns true if a review with the specified ID was found
        private bool EmergencyExists ( int id ) {
            return _context.Emergencies.Find ( id ) != null;
        }
    }
}
