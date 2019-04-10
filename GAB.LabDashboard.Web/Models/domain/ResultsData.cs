using System;
using System.Collections.Generic;
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
        public string Fullname { get; set; }
        public string Location { get; set; }
        public string TeamName { get; set; }
        public string CompanyName { get; set; }
        public string CountryCode { get; set; }
        public bool IsPlanet { get; set; }
        public float Probability { get; set; }
        public int TotalScore { get; set; }
        public DateTime CreationDate { get; set; }
        public DateTime ModificationDate { get; set; }
    }
}
