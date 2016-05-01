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
    public class OrganisationController : ApiController {

        
        private STUFVModelContext _context = new STUFVModelContext ( );

        // GET: api/Reviews
        public async Task<IHttpActionResult> Get ( ) {
            IEnumerable<Organisation> organisations = await _context.Organisations.ToListAsync ( );

            if ( organisations == null ) {
                return NotFound ( );
            } else {
                return Ok ( organisations );
            }
        }

        // GET: api/Reviews/5
        public async Task<IHttpActionResult> Get ( int id ) {
            Organisation organisation = await _context.Organisations.FindAsync ( id );

            if ( organisation == null ) {
                return NotFound ( );
            } else {
                return Ok ( organisation );
            }
        }

        // POST: api/Reviews
        public async Task<IHttpActionResult> Post ( Organisation value ) {
            if ( !ModelState.IsValid ) {
                return BadRequest ( ModelState );
            }

            _context.Organisations.Add ( value );
            await _context.SaveChangesAsync ( );

            return CreatedAtRoute ( "DefaultApi", new { id = value.Id }, value );
        }

        // PUT: api/Reviews/5
        public async Task<IHttpActionResult> Put ( int id, Organisation organisation ) {
            if ( !ModelState.IsValid ) {
                return BadRequest ( ModelState );
            }

            if ( id != organisation.Id ) {
                return BadRequest ( );
            }

            _context.Entry ( organisation ).State = EntityState.Modified;

            try {
                await _context.SaveChangesAsync ( );
            } catch ( DBConcurrencyException ex ) {
                if ( !organisationExists ( id ) ) {
                    return NotFound ( );
                } else {
                    throw;
                }
            }

            return StatusCode ( HttpStatusCode.NoContent );
        }

        // DELETE: api/Reviews/5
        public async Task<IHttpActionResult> Delete ( int id ) {
            Organisation organisation = await _context.Organisations.FindAsync ( id );

            if ( organisation == null ) {
                return NotFound ( );
            }

            _context.Organisations.Remove ( organisation );
            await _context.SaveChangesAsync ( );

            return Ok ( organisation );
        }

        // Returns true if a review with the specified ID was found
        private bool organisationExists ( int id ) {
            return _context.Organisations.Find ( id ) != null;
        }
    }
}
