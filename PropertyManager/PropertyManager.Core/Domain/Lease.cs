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


        //Calculate % of time left on Lease
        public double PercentageOfLeaseCompleted
        {
            get
            {
                DateTime StartTime = StartDate;
                DateTime EndTime = (DateTime)EndDate;
                TimeSpan duration = EndTime - StartTime;

                DateTime NowTime = DateTime.Now;

                TimeSpan elapsedTime = NowTime - StartTime;

                double elapsedSeconds = elapsedTime.TotalSeconds;
                double durationSeconds = duration.TotalSeconds;

                double percentage = elapsedSeconds / durationSeconds * 100;

                return percentage;

            }
        }

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
