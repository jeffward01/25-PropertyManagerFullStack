using AutoMapper;
using PropertyManager.Core.Infrastructure;
using PropertyManager.Core.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace PropertyManager.Controllers
{
    public class DashboardController : ApiController
    {
        private PropertyManagerDbContext db = new PropertyManagerDbContext();

        // GET: api/DashBoard || Controller Method[0]
        public DashboardModel GetDashboard()
        {
            var sixMonthsFromNow = DateTime.Now.AddMonths(6);

            return new DashboardModel
            {
                LeaseCount = db.Leases.Count(),
                PropertyCount = db.Properties.Count(),
                TenantCount = db.Tenants.Count(),
                TotalMonthlyIncome = db.Leases.Sum(l => l.Rent),
                ExpiringLeases = Mapper.Map<IEnumerable<LeaseModel>>(
                    db.Leases.Where(
                                    l => l.EndDate.HasValue && 
                                         l.EndDate >= DateTime.Now &&
                                         l.EndDate <= sixMonthsFromNow
                                   )
                             .OrderBy(l => l.EndDate)
                             .Take(3)
                )
            };
        }


        protected override void Dispose(bool disposing)
        {
            if(disposing)
            {
                db.Dispose();
            }
        }
    }
}
