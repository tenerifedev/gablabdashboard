using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Threading.Tasks;

namespace GAB.LabDashboard.Web.Models.domain
{
    public class AggregateBase
    {
        public int Id { get; set; }
        [DisplayName("Creation Date")]
        public DateTime CreationDate { get; set; }
        [DisplayName("Modification Date")]
        public DateTime ModificationDate { get; set; }
        [DisplayName("Score")]
        public int Score { get; set; }
        [DisplayName("Items")]
        public int TotalItems { get; set; }
    }
}
