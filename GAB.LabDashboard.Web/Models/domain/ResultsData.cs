using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Threading.Tasks;

namespace GAB.LabDashboard.Web.Models.domain
{
    public class ResultsData
    {
        public int Id { get; set; }
        public int InputId { get; set; }
        public Guid BatchId { get; set; }
        public int OutputId { get; set; }
        public string DeploymentId { get; set; }
        public string Email { get; set; }

        [DisplayName("Attendee")]
        public string Fullname { get; set; }
        public string Location { get; set; }
        [DisplayName("Team")]
        public string TeamName { get; set; }
        [DisplayName("Company")]
        public string CompanyName { get; set; }
        [DisplayName("Country")]
        public string CountryCode { get; set; }
        [DisplayName("Client")]
        public string ClientVersion { get; set; }

        [DisplayName("Target ID")]
        public int TICId { get; set; }

        public int Sector { get; set; }
        public int Camera { get; set; }
        public int CCD { get; set; }
        public double RA { get; set; }
        public double Dec { get; set; }
        public double TMag { get; set; }

        [DisplayName("% P")]
        public double IsPlanet { get; set; }

        [DisplayName("% !P")]
        public double IsNotPlanet { get; set; }

        [DisplayName("Period")]
        public string Per { get; set; }

        [DisplayName("TPF")]
        public string Tpf { get; set; }

        [DisplayName("Light Curve")]
        public string Lc { get; set; }

        public int TotalScore { get; set; }
        public DateTime CreationDate { get; set; }
        [DisplayName("Date")]
        public DateTime ModificationDate { get; set; }
    }
}
