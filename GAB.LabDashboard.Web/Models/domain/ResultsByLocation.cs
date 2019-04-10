using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GAB.LabDashboard.Web.Models.domain
{
    public class ResultsByLocation : AggregateBase
    {
        public string LocationName { get; set; }
    }
}
