using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PropertyManager.Core.Models
{
    public class PropertyModel
    {
        public int PropertyId { get; set; }

        public string Name { get; set; }
        public string Address1 { get; set; }
        public string Address2 { get; set; }
        public string City { get; set; }
        public string State { get; set; }
        public string Zip { get; set; }


        public TenantModel Tenant { get; set; }
        public LeaseModel Lease { get; set; }
    }
}
