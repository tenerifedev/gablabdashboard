using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using GAB.LabDashboard.Web.Data;
using GAB.LabDashboard.Web.Models.domain;
using Microsoft.Extensions.Caching.Memory;
using Microsoft.Extensions.Configuration;

namespace GAB.LabDashboard.Web.Controllers
{
    public class ResultsController : Controller
    {
        private readonly AppDataContext context;
        private readonly IMemoryCache _cache;
        private readonly IConfiguration _configuration;

        public ResultsController(AppDataContext context, IMemoryCache memoryCache, IConfiguration configuration)
        {
            this.context = context;
            _cache = memoryCache;
            _configuration = configuration;
        }

        // GET: Results
        [ResponseCache(Duration = 60, Location = ResponseCacheLocation.Any)]
        public async Task<IActionResult> Attendees()
        {
            List<ResultsByAttendee> result;

            if (!_cache.TryGetValue("GAB:Attendees", out result))
            {
                result = await context.ResultsByAttendee.OrderByDescending(i => i.Score).Take(_configuration.GetValue<int>("Caching:ShowTopAttendees")).ToListAsync();
                _cache.Set("GAB:Attendees", result, TimeSpan.FromSeconds(_configuration.GetValue<int>("Caching:ServerTimeoutInSeconds")));
            }
            return View(result);
        }

        [ResponseCache(Duration = 60, Location = ResponseCacheLocation.Any)]
        public async Task<IActionResult> Companies()
        {
            List<ResultsByCompany> result;

            if (!_cache.TryGetValue("GAB:Companies", out result))
            {
                result = await context.ResultsByCompany.OrderByDescending(i => i.Score).Take(_configuration.GetValue<int>("Caching:ShowTopCompanies")).ToListAsync();
                _cache.Set("GAB:Companies", result, TimeSpan.FromSeconds(_configuration.GetValue<int>("Caching:ServerTimeoutInSeconds")));
            }
            return View(result);
        }

        [ResponseCache(Duration = 60, Location = ResponseCacheLocation.Any)]
        public async Task<IActionResult> Countries()
        {
            List<ResultsByCountry> result;

            if (!_cache.TryGetValue("GAB:Countries", out result))
            {
                result = await context.ResultsByCountry.OrderByDescending(i => i.Score).Take(_configuration.GetValue<int>("Caching:ShowTopCountries")).ToListAsync();
                _cache.Set("GAB:Countries", result, TimeSpan.FromSeconds(_configuration.GetValue<int>("Caching:ServerTimeoutInSeconds")));
            }
            return View(result);
        }

        [ResponseCache(Duration = 60, Location = ResponseCacheLocation.Any)]
        public async Task<IActionResult> Locations()
        {
            List<ResultsByLocation> result;

            if (!_cache.TryGetValue("GAB:Locations", out result))
            {
                result = await context.ResultsByLocation.OrderByDescending(i => i.Score).Take(_configuration.GetValue<int>("Caching:ShowTopLocations")).ToListAsync();
                _cache.Set("GAB:Locations", result, TimeSpan.FromSeconds(_configuration.GetValue<int>("Caching:ServerTimeoutInSeconds")));
            }
            return View(result);
        }

        [ResponseCache(Duration = 60, Location = ResponseCacheLocation.Any)]
        public async Task<IActionResult> Teams(string orderField, string orderDirection, int page = 0)
        {
            List<ResultsByTeam> result;

            if (!_cache.TryGetValue("GAB:Teams", out result))
            {
                result = await context.ResultsByTeam.OrderByDescending(i => i.Score).Take(_configuration.GetValue<int>("Caching:ShowTopTeams")).ToListAsync();
                _cache.Set("GAB:Teams", result, TimeSpan.FromSeconds(_configuration.GetValue<int>("Caching:ServerTimeoutInSeconds")));
            }
            return View(result);
        }

        [ResponseCache(Duration = 300, Location = ResponseCacheLocation.Any)]
        public async Task<IActionResult> Candidates()
        {
            List<ResultsData> result;

            if (!_cache.TryGetValue("GAB:Candidates", out result))
            {
                DateTime minDate;
                if (!DateTime.TryParse(_configuration.GetValue<string>("Caching:ShowTopCandidatesMinDate"), out minDate)) {
                    minDate = new DateTime(2019, 4, 26);
                }
                double minIsPlanet;
                if (!double.TryParse(_configuration.GetValue<string>("Caching:ShowTopCandidatesMinIsPlanet"), out minIsPlanet))
                {
                    minIsPlanet = 0.9999999999999;
                }
                result = await context.ResultsData
                    .Where(x => x.IsPlanet > minIsPlanet && x.ModificationDate > minDate)
                    .OrderByDescending(i => i.ModificationDate)
                    .Take(_configuration
                    .GetValue<int>("Caching:ShowTopCandidates")).ToListAsync();
                _cache.Set("GAB:Candidates", result, TimeSpan.FromSeconds(_configuration.GetValue<int>("Caching:ServerTimeoutInSeconds")));
            }
            return View(result);
        }
    }
}
