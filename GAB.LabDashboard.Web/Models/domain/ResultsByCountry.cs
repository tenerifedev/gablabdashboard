using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GAB.LabDashboard.Web.Models.domain
{
    public class ResultsByCountry : AggregateBase
    {
        public string CountryCode { get; set; }
        public string CountryName { get; set; }

    }
}
