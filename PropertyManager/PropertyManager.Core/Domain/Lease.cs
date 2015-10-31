using PropertyManager.Core.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace PropertyManager.Core.Domain
{
    public class Lease
    {
        public int LeaseId { get; set; }

        public int PropertyId { get; set; }
        public int TenantId { get; set; }

        public DateTime StartDate { get; set; }
        public Nullable<DateTime> EndDate { get; set; }

        public decimal Rent { get; set; }

        public virtual Property Property { get; set; }
        public virtual Tenant Tenant { get; set; }



        public void Update(LeaseModel lease)
        {
           
            PropertyId = lease.PropertyId;
            TenantId = lease.TenantId;
            StartDate = lease.StartDate;
            EndDate = lease.EndDate;
            Rent = lease.Rent;
        
        }

    }
}
