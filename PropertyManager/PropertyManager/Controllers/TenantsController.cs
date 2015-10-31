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
    public class TenantsController : ApiController
    {
        private PropertyManagerDbContext db = new PropertyManagerDbContext();

        // GET: api/Tenants || Controller Method [0]
        public IEnumerable<TenantModel> GetTenants()
        {
            return Mapper.Map<IEnumerable<TenantModel>>(db.Properties);
        }

        // GET: api/Tenants/5 || Controller Method [1]
        [ResponseType(typeof(TenantModel))]
        public IHttpActionResult GetTenant(int id)
        {
            Tenant dbtenant = db.Tenants.Find(id);

            if (dbtenant == null)
            {
                return NotFound();
            }

            TenantModel tenant = Mapper.Map<TenantModel>(dbtenant);

            return Ok(tenant);
        }

        // PUT: api/Tenants/5 || Controller Method [2]
        [ResponseType(typeof(void))]
        public IHttpActionResult PutTenant(int id, TenantModel tenant)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != tenant.TenantId)
            {
                return BadRequest();
            }

            var dbTentant = db.Tenants.Find(id);

            dbTentant.Update(tenant);
            
           // db.Entry(tenant).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!TenantExists(id))
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

        // POST: api/Tenants || Controller Method [3]
        [ResponseType(typeof(TenantModel))]
        public IHttpActionResult PostTenant(TenantModel tenant)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var dbTenant = new Tenant();

            db.Tenants.Add(dbTenant);
            db.SaveChanges();

            tenant.TenantId = dbTenant.TenantId;

            return CreatedAtRoute("DefaultApi", new { id = tenant.TenantId }, tenant);
        }

        // DELETE: api/Tenants/5 || Controller Method [4]
        [ResponseType(typeof(TenantModel))]
        public IHttpActionResult DeleteTenant(int id)
        {
            Tenant tenant = db.Tenants.Find(id);
            if (tenant == null)
            {
                return NotFound();
            }

            db.Tenants.Remove(tenant);
            db.SaveChanges();

            return Ok(Mapper.Map<TenantModel>(tenant));
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool TenantExists(int id)
        {
            return db.Tenants.Count(e => e.TenantId == id) > 0;
        }
    }
}