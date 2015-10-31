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
using PropertyManager.Core.Domain;
using PropertyManager.Core.Infrastructure;
using AutoMapper;
using PropertyManager.Core.Models;

namespace PropertyManager.Controllers
{
    public class LeasesController : ApiController
    {
        private PropertyManagerDbContext db = new PropertyManagerDbContext();

        // GET: api/Leases || Controller Method[0]
        public IEnumerable<LeaseModel> GetLeases()
        {
            return Mapper.Map<IEnumerable<LeaseModel>>(db.Properties); 
        }

        // GET: api/Leases/5 || Controller Method [1]
        [ResponseType(typeof(LeaseModel))]
        public IHttpActionResult GetLease(int id)
        {
            Lease dbLease = db.Leases.Find(id);

            if (dbLease == null)
            {
                return NotFound();
            }

            LeaseModel lease = Mapper.Map<LeaseModel>(dbLease);

            return Ok(lease);
        }

        // PUT: api/Leases/5 || Controller Method[2]
        [ResponseType(typeof(void))]
        public IHttpActionResult PutLease(int id, LeaseModel lease)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != lease.LeaseId)
            {
                return BadRequest();
            }

            var dbLease = db.Leases.Find(id);

            dbLease.Update(lease);

           // db.Entry(lease).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!LeaseExists(id))
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

        // POST: api/Leases || Controller Method [3]
        [ResponseType(typeof(LeaseModel))]
        public IHttpActionResult PostLease(LeaseModel lease)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var dbLease = new Lease();

            dbLease.Update(lease);
            db.Leases.Add(dbLease);
            db.SaveChanges();

            lease.LeaseId = dbLease.LeaseId;

            return CreatedAtRoute("DefaultApi", new { id = lease.LeaseId }, lease);
        }

        // DELETE: api/Leases/5 || Controller Method [4]
        [ResponseType(typeof(LeaseModel))]
        public IHttpActionResult DeleteLease(int id)
        {
            Lease lease = db.Leases.Find(id);
            if (lease == null)
            {
                return NotFound();
            }

            db.Leases.Remove(lease);
            db.SaveChanges();

            return Ok(Mapper.Map<LeaseModel>(lease));
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool LeaseExists(int id)
        {
            return db.Leases.Count(e => e.LeaseId == id) > 0;
        }
    }
}