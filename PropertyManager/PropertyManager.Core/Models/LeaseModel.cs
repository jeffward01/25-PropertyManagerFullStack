using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PropertyManager.Core.Models
{
    public class LeaseModel
    {
        public int LeaseId { get; set; }

        public int PropertyId { get; set; }
        public int TenantId { get; set; }

        public DateTime StartDate { get; set; }
        public Nullable<DateTime> EndDate { get; set; }


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

                percentage = Math.Floor(percentage);

                return percentage;

            }
        }

        public decimal Rent { get; set; }

        public TenantModel Tenant { get; set; }
        public PropertyModel Property { get; set; }


    }


}
