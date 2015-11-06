using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PropertyManager.Core.Domain;

namespace PropertyManager.Core.Models
{
    public class DashboardModel
    {
        public int PropertyCount { get; set; }
        public int LeaseCount { get; set; } 
        public int TenantCount { get; set; }
        public decimal TotalMonthlyIncome { get; set; }
        public IEnumerable<LeaseModel> ExpiringLeases { get; set; }
    }
     
}
