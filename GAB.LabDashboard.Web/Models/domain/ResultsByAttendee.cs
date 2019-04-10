using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GAB.LabDashboard.Web.Models.domain
{
    public class ResultsByAttendee : AggregateBase
    {
        public string AttendeeName { get; set; }
        public string Email { get; set; }
    }
}
