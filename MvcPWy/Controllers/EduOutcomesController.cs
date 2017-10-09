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
using MvcPWy.Models;

namespace MvcPWy.Controllers
{
    public class EduOutcomesController : ApiController
    {
        private EntitiesEduOutcome db = new EntitiesEduOutcome();

        // GET: api/EduOutcomes
        public IQueryable<EduOutcome> GetEduOutcomes()
        {
            return db.EduOutcomes;
        }

        // GET: api/EduOutcomes/5
        [ResponseType(typeof(EduOutcome))]
        public async Task<IHttpActionResult> GetEduOutcome(string id)
        {
            EduOutcome eduOutcome = await db.EduOutcomes.FindAsync(id);
            if (eduOutcome == null)
            {
                return NotFound();
            }

            return Ok(eduOutcome);
        }

        // PUT: api/EduOutcomes/5
        [ResponseType(typeof(void))]
        public async Task<IHttpActionResult> PutEduOutcome(string id, EduOutcome eduOutcome)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != eduOutcome.Id)
            {
                return BadRequest();
            }

            db.Entry(eduOutcome).State = EntityState.Modified;

            try
            {
                await db.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!EduOutcomeExists(id))
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

        // POST: api/EduOutcomes
        [ResponseType(typeof(EduOutcome))]
        public async Task<IHttpActionResult> PostEduOutcome(EduOutcome eduOutcome)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.EduOutcomes.Add(eduOutcome);

            try
            {
                await db.SaveChangesAsync();
            }
            catch (DbUpdateException)
            {
                if (EduOutcomeExists(eduOutcome.Id))
                {
                    return Conflict();
                }
                else
                {
                    throw;
                }
            }

            return CreatedAtRoute("DefaultApi", new { id = eduOutcome.Id }, eduOutcome);
        }

        // DELETE: api/EduOutcomes/5
        [ResponseType(typeof(EduOutcome))]
        public async Task<IHttpActionResult> DeleteEduOutcome(string id)
        {
            EduOutcome eduOutcome = await db.EduOutcomes.FindAsync(id);
            if (eduOutcome == null)
            {
                return NotFound();
            }

            db.EduOutcomes.Remove(eduOutcome);
            await db.SaveChangesAsync();

            return Ok(eduOutcome);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool EduOutcomeExists(string id)
        {
            return db.EduOutcomes.Count(e => e.Id == id) > 0;
        }
    }
}