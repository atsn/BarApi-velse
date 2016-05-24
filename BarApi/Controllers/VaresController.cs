using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web.Http;
using System.Web.Http.Description;
using BarApi.Models;

namespace BarApi.Controllers
{
    public class VaresController : ApiController
    {
        private Fredagsbarcontext db = new Fredagsbarcontext();

        // GET: api/Vares
        public IQueryable<Vare> GetVare()
        {
            return db.Vare;
        }

        // GET: api/Vares/5
        [ResponseType(typeof(Vare))]
        public async Task<IHttpActionResult> GetVare(int id)
        {
            Vare vare = await db.Vare.FindAsync(id);
            if (vare == null)
            {
                return NotFound();
            }

            return Ok(vare);
        }

        // PUT: api/Vares/5
        [ResponseType(typeof(void))]
        public async Task<IHttpActionResult> PutVare(int id, Vare vare)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != vare.Id)
            {
                return BadRequest();
            }

            db.Entry(vare).State = EntityState.Modified;

            try
            {
                await db.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!VareExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return StatusCode(HttpStatusCode.NoContent);
        }

        // POST: api/Vares
        [ResponseType(typeof(Vare))]
        public async Task<IHttpActionResult> PostVare(Vare vare)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.Vare.Add(vare);
            await db.SaveChangesAsync();

            return CreatedAtRoute("DefaultApi", new { id = vare.Id }, vare);
        }

        // DELETE: api/Vares/5
        [ResponseType(typeof(Vare))]
        public async Task<IHttpActionResult> DeleteVare(int id)
        {
            Vare vare = await db.Vare.FindAsync(id);
            if (vare == null)
            {
                return NotFound();
            }

            db.Vare.Remove(vare);
            await db.SaveChangesAsync();

            return Ok(vare);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool VareExists(int id)
        {
            return db.Vare.Count(e => e.Id == id) > 0;
        }
    }
}