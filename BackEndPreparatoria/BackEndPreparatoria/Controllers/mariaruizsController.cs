using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Description;
using BackEndPreparatoria.Models;

namespace BackEndPreparatoria.Controllers
{
    public class mariaruizsController : ApiController
    {
        private DataContext db = new DataContext();

        // GET: api/mariaruizs
        public IQueryable<ruiz> Getruizs()
        {
            return db.ruizs;
        }

        // GET: api/mariaruizs/5
        [ResponseType(typeof(ruiz))]
        public IHttpActionResult Getruiz(int id)
        {
            ruiz ruiz = db.ruizs.Find(id);
            if (ruiz == null)
            {
                return NotFound();
            }

            return Ok(ruiz);
        }

        // PUT: api/mariaruizs/5
        [ResponseType(typeof(void))]
        public IHttpActionResult Putruiz(int id, ruiz ruiz)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != ruiz.ruizID)
            {
                return BadRequest();
            }

            db.Entry(ruiz).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ruizExists(id))
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

        // POST: api/mariaruizs
        [ResponseType(typeof(ruiz))]
        public IHttpActionResult Postruiz(ruiz ruiz)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.ruizs.Add(ruiz);
            db.SaveChanges();

            return CreatedAtRoute("DefaultApi", new { id = ruiz.ruizID }, ruiz);
        }

        // DELETE: api/mariaruizs/5
        [ResponseType(typeof(ruiz))]
        public IHttpActionResult Deleteruiz(int id)
        {
            ruiz ruiz = db.ruizs.Find(id);
            if (ruiz == null)
            {
                return NotFound();
            }

            db.ruizs.Remove(ruiz);
            db.SaveChanges();

            return Ok(ruiz);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool ruizExists(int id)
        {
            return db.ruizs.Count(e => e.ruizID == id) > 0;
        }
    }
}