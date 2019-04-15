using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GAB.LabDashboard.Web.Models.domain
{
    public class Summary
    {
        public int Id { get; set; }
        public int Attendees {get; set; }
        public int Companies {get; set; }
        public int Locations {get; set; }
        public int Countries {get; set; }
        public int Inputs   {get; set; }
        public int Runs    {get; set; }
        public double Hours    {get; set; }
        public int Cores    {get; set; }
    }
}
