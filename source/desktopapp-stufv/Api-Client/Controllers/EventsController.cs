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

namespace Api_Client.Controllers {
    public class EventsController : ApiController {

        private STUFVModelContext _context = new STUFVModelContext ( );

        // GET: api/Reviews
        public async Task<IHttpActionResult> Get ( ) {
            IEnumerable<Event> evnt = await _context.Events.ToListAsync ( );

            if ( evnt == null ) {
                return NotFound ( );
            } else {
                return Ok ( evnt );
            }
        }

        // GET: api/Reviews/5
        public async Task<IHttpActionResult> Get ( int id ) {
            Event evnt = await _context.Events.FindAsync ( id );

            if ( evnt == null ) {
                return NotFound ( );
            } else {
                return Ok ( evnt );
            }
        }

        // POST: api/Reviews
        public async Task<IHttpActionResult> Post ( Event value ) {
            if ( !ModelState.IsValid ) {
                return BadRequest ( ModelState );
            }

            _context.Events.Add ( value );
            await _context.SaveChangesAsync ( );

            return CreatedAtRoute ( "DefaultApi", new { id = value.Id }, value );
        }

        // PUT: api/Reviews/5
        public async Task<IHttpActionResult> Put ( int id, Event evnt ) {
            if ( !ModelState.IsValid ) {
                return BadRequest ( ModelState );
            }

            if ( id != evnt.Id ) {
                return BadRequest ( );
            }

            _context.Entry ( evnt ).State = EntityState.Modified;

            try {
                await _context.SaveChangesAsync ( );
            } catch ( DBConcurrencyException ex ) {
                if ( !eventExists ( id ) ) {
                    return NotFound ( );
                } else {
                    throw;
                }
            }

            return StatusCode ( HttpStatusCode.NoContent );
        }

        // DELETE: api/Reviews/5
        public async Task<IHttpActionResult> Delete ( int id ) {
            Event evnt = await _context.Events.FindAsync ( id );

            if ( evnt == null ) {
                return NotFound ( );
            }

            _context.Events.Remove ( evnt );
            await _context.SaveChangesAsync ( );

            return Ok ( evnt );
        }

        // Returns true if a review with the specified ID was found
        private bool eventExists ( int id ) {
            return _context.Events.Find ( id ) != null;
        }
    }
}
