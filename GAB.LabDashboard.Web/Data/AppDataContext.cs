using GAB.LabDashboard.Web.Models.domain;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GAB.LabDashboard.Web.Data
{
    public class AppDataContext : DbContext
    {
        public DbSet<Country> Countries { get; set; }
        public DbSet<ResultsByAttendee> ResultsByAttendee { get; set; }
        public DbSet<ResultsByCompany> ResultsByCompany { get; set; }
        public DbSet<ResultsByCountry> ResultsByCountry { get; set; }
        public DbSet<ResultsByLocation> ResultsByLocation { get; set; }
        public DbSet<ResultsData> ResultsData { get; set; }
        public DbSet<Summary> Summary { get; set; }

        public AppDataContext(DbContextOptions<AppDataContext> options) : base(options)
        {
        }
    }
}
