using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Threading.Tasks;

namespace GAB.LabDashboard.Web.Models.domain
{
    public class ResultsByTeam : AggregateBase
    {
        [DisplayName("Team")]
        public string TeamName { get; set; }
    }
}
