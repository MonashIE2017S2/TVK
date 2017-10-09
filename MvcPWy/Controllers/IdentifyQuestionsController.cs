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
    public class IdentifyQuestionsController : ApiController
    {
        private Entities db = new Entities();

        // GET: api/IdentifyQuestions
        public IQueryable<IdentifyQuestion> GetIdentifyQuestions()
        {
            return db.IdentifyQuestions;
        }

        // GET: api/IdentifyQuestions/5
        [ResponseType(typeof(IdentifyQuestion))]
        public async Task<IHttpActionResult> GetIdentifyQuestion(int id)
        {
            IdentifyQuestion identifyQuestion = await db.IdentifyQuestions.FindAsync(id);
            if (identifyQuestion == null)
            {
                return NotFound();
            }

            return Ok(identifyQuestion);
        }

        // PUT: api/IdentifyQuestions/5
        [ResponseType(typeof(void))]
        public async Task<IHttpActionResult> PutIdentifyQuestion(int id, IdentifyQuestion identifyQuestion)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != identifyQuestion.QuestionID)
            {
                return BadRequest();
            }

            db.Entry(identifyQuestion).State = EntityState.Modified;

            try
            {
                await db.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!IdentifyQuestionExists(id))
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

        // POST: api/IdentifyQuestions
        [ResponseType(typeof(IdentifyQuestion))]
        public async Task<IHttpActionResult> PostIdentifyQuestion(IdentifyQuestion identifyQuestion)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.IdentifyQuestions.Add(identifyQuestion);
            await db.SaveChangesAsync();

            return CreatedAtRoute("DefaultApi", new { id = identifyQuestion.QuestionID }, identifyQuestion);
        }

        // DELETE: api/IdentifyQuestions/5
        [ResponseType(typeof(IdentifyQuestion))]
        public async Task<IHttpActionResult> DeleteIdentifyQuestion(int id)
        {
            IdentifyQuestion identifyQuestion = await db.IdentifyQuestions.FindAsync(id);
            if (identifyQuestion == null)
            {
                return NotFound();
            }

            db.IdentifyQuestions.Remove(identifyQuestion);
            await db.SaveChangesAsync();

            return Ok(identifyQuestion);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool IdentifyQuestionExists(int id)
        {
            return db.IdentifyQuestions.Count(e => e.QuestionID == id) > 0;
        }
    }
}