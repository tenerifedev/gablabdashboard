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
        [ResponseCache(Duration = 30, Location = ResponseCacheLocation.Any)]
        public async Task<IActionResult> Attendees()
        {
            List<ResultsByAttendee> result;
            if (!_cache.TryGetValue("GAB:Attendees", out result))
            {
                result = await context.ResultsByAttendee.OrderByDescending(i => i.Score).ToListAsync();
                _cache.Set("GAB:Attendees", result, TimeSpan.FromSeconds(_configuration.GetValue<int>("Caching:ServerTimeoutInSeconds")));
            }
            return View(result);
        }

        [ResponseCache(Duration = 30, Location = ResponseCacheLocation.Any)]
        public async Task<IActionResult> Companies()
        {
            List<ResultsByCompany> result;
            if (!_cache.TryGetValue("GAB:Companies", out result))
            {
                result = await context.ResultsByCompany.OrderByDescending(i => i.Score).ToListAsync();
                _cache.Set("GAB:Companies", result, TimeSpan.FromSeconds(_configuration.GetValue<int>("Caching:ServerTimeoutInSeconds")));
            }
            return View(result);
        }

        [ResponseCache(Duration = 30, Location = ResponseCacheLocation.Any)]
        public async Task<IActionResult> Countries()
        {
            List<ResultsByCountry> result;
            if (!_cache.TryGetValue("GAB:Countries", out result))
            {
                result = await context.ResultsByCountry.OrderByDescending(i => i.Score).ToListAsync();
                _cache.Set("GAB:Countries", result, TimeSpan.FromSeconds(_configuration.GetValue<int>("Caching:ServerTimeoutInSeconds")));
            }
            return View(result);
        }

        [ResponseCache(Duration = 30, Location = ResponseCacheLocation.Any)]
        public async Task<IActionResult> Locations()
        {
            List<ResultsByLocation> result;
            if (!_cache.TryGetValue("GAB:Locations", out result))
            {
                result = await context.ResultsByLocation.OrderByDescending(i => i.Score).ToListAsync();
                _cache.Set("GAB:Locations", result, TimeSpan.FromSeconds(_configuration.GetValue<int>("Caching:ServerTimeoutInSeconds")));
            }
            return View(result);
        }

        [ResponseCache(Duration = 30, Location = ResponseCacheLocation.Any)]
        public async Task<IActionResult> Teams()
        {
            List<ResultsByTeam> result;
            if (!_cache.TryGetValue("GAB:Teams", out result))
            {
                result = await context.ResultsByTeam.OrderByDescending(i => i.Score).ToListAsync();
                _cache.Set("GAB:Teams", result, TimeSpan.FromSeconds(_configuration.GetValue<int>("Caching:ServerTimeoutInSeconds")));
            }
            return View(result);
        }
    }
}
