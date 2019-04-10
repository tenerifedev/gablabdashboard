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

namespace GAB.LabDashboard.Web.Controllers
{
    public class HomeController : Controller
    {
        private readonly AppDataContext context;

        public HomeController(AppDataContext context)
        {
            this.context = context;
        }

        public async Task<IActionResult> Index()
        {
            Summary summary = new Summary();
            if(context.Summary.Count() > 0)
                summary = await context.Summary.FirstOrDefaultAsync();
            return View(summary);
        }

        public IActionResult Privacy()
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
