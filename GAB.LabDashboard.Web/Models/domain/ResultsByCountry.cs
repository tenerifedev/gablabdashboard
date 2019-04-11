using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Threading.Tasks;

namespace GAB.LabDashboard.Web.Models.domain
{
    public class ResultsByCountry : AggregateBase
    {
        [DisplayName("Code")]
        public string CountryCode { get; set; }
        [DisplayName("Country")]
        public string CountryName { get; set; }

    }
}
