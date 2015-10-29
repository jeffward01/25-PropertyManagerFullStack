using PropertyManager.Core.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PropertyManager.Core.Domain
{
    public class Tenant
    {
        public int TenantId { get; set; }

        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Telephone { get; set; }
        public string EmailAddress { get; set; }

        public virtual ICollection<Lease> Leases { get; set; }

        public void Update(TenantModel tenant)
        {
            FirstName = tenant.FirstName;
            LastName = tenant.LastName;
            TenantId = tenant.TenantId;
            Telephone = tenant.Telephone;
            EmailAddress = tenant.EmailAddress;
          

        }

    }
}
