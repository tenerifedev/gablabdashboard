using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using GAB.LabDashboard.Web.Models;
using GAB.LabDashboard.Web.Data;
using Microsoft.EntityFrameworkCore;
using GAB.LabDashboard.Web.Models.domain;
using Microsoft.Extensions.Caching.Memory;
using Microsoft.Extensions.Configuration;

namespace GAB.LabDashboard.Web.Controllers
{
    public class HomeController : Controller
    {
        private readonly AppDataContext context;
        private readonly IMemoryCache _cache;
        private readonly IConfiguration _configuration;

        public HomeController(AppDataContext context, IMemoryCache memoryCache, IConfiguration configuration)
        {
            this.context = context;
            _cache = memoryCache;
            _configuration = configuration;
        }

        [ResponseCache(Duration = 60, Location = ResponseCacheLocation.Any)]
        public async Task<IActionResult> Index()
        {            
            Summary result;
            if (!_cache.TryGetValue("GAB:Summary", out result))
            {
                result = await context.Summary.FirstOrDefaultAsync();
                _cache.Set("GAB:Summary", result, TimeSpan.FromSeconds(_configuration.GetValue<int>("Caching:ServerTimeoutInSeconds")));
            }
            return View(result);
        }

        public IActionResult Privacy()
        {
            return View();
        }

        public IActionResult About()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
