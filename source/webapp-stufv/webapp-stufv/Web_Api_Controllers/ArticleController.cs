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
    public class ArticleController : ApiController {

        private STUFVModelContext _context = new STUFVModelContext ( );

        // GET: api/Reviews
        public async Task<IHttpActionResult> Get ( ) {
            IEnumerable<Article> articles = await _context.Articles.ToListAsync ( );

            if ( articles == null ) {
                return NotFound ( );
            } else {
                return Ok ( articles );
            }
        }

        // GET: api/Reviews/5
        public async Task<IHttpActionResult> Get ( int id ) {
            Article article = await _context.Articles.FindAsync ( id );

            if ( article == null ) {
                return NotFound ( );
            } else {
                return Ok ( article );
            }
        }

        // POST: api/Reviews
        public async Task<IHttpActionResult> Post ( Article value ) {
            if ( !ModelState.IsValid ) {
                return BadRequest ( ModelState );
            }

            _context.Articles.Add ( value );
            await _context.SaveChangesAsync ( );

            return CreatedAtRoute ( "DefaultApi", new { id = value.Id }, value );
        }

        // PUT: api/Reviews/5
        public async Task<IHttpActionResult> Put ( int id, Article article ) {
            if ( !ModelState.IsValid ) {
                return BadRequest ( ModelState );
            }

            if ( id != article.Id ) {
                return BadRequest ( );
            }

            _context.Entry ( article ).State = EntityState.Modified;

            try {
                await _context.SaveChangesAsync ( );
            } catch ( DBConcurrencyException ex ) {
                if ( !ArticleExists ( id ) ) {
                    return NotFound ( );
                } else {
                    throw;
                }
            }

            return StatusCode ( HttpStatusCode.NoContent );
        }

        // DELETE: api/Reviews/5
        public async Task<IHttpActionResult> Delete ( int id ) {
            Article article = await _context.Articles.FindAsync ( id );

            if ( article == null ) {
                return NotFound ( );
            }

            _context.Articles.Remove ( article );
            await _context.SaveChangesAsync ( );

            return Ok ( article );
        }

        // Returns true if a review with the specified ID was found
        private bool ArticleExists ( int id ) {
            return _context.Articles.Find ( id ) != null;
        }
    }
}
