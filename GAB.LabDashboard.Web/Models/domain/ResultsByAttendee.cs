using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Threading.Tasks;

namespace GAB.LabDashboard.Web.Models.domain
{
    public class ResultsByAttendee : AggregateBase
    {
        [DisplayName("Attendee")]
        public string AttendeeName { get; set; }
        [DisplayName("Email")]
        public string Email { get; set; }
    }
}
