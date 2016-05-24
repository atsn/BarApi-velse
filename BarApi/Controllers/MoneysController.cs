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
    public class MoneysController : ApiController
    {
        private Fredagsbarcontext db = new Fredagsbarcontext();

        // GET: api/Moneys
        public IQueryable<Money> GetMoney()
        {
            return db.Money;
        }

        // GET: api/Moneys/5
        [ResponseType(typeof(Money))]
        public async Task<IHttpActionResult> GetMoney(int id)
        {
            Money money = await db.Money.FindAsync(id);
            if (money == null)
            {
                return NotFound();
            }

            return Ok(money);
        }

        // PUT: api/Moneys/5
        [ResponseType(typeof(void))]
        public async Task<IHttpActionResult> PutMoney(int id, Money money)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != money.Id)
            {
                return BadRequest();
            }

            db.Entry(money).State = EntityState.Modified;

            try
            {
                await db.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!MoneyExists(id))
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

        // POST: api/Moneys
        [ResponseType(typeof(Money))]
        public async Task<IHttpActionResult> PostMoney(Money money)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.Money.Add(money);
            await db.SaveChangesAsync();

            return CreatedAtRoute("DefaultApi", new { id = money.Id }, money);
        }

        // DELETE: api/Moneys/5
        [ResponseType(typeof(Money))]
        public async Task<IHttpActionResult> DeleteMoney(int id)
        {
            Money money = await db.Money.FindAsync(id);
            if (money == null)
            {
                return NotFound();
            }

            db.Money.Remove(money);
            await db.SaveChangesAsync();

            return Ok(money);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool MoneyExists(int id)
        {
            return db.Money.Count(e => e.Id == id) > 0;
        }
    }
}