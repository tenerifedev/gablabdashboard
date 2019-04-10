using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using GAB.LabDashboard.Web.Data;

namespace GAB.LabDashboard.Web.Controllers
{
    public class ResultsController : Controller
    {
        private readonly AppDataContext context;

        public ResultsController(AppDataContext context)
        {
            this.context = context;
        }

        // GET: Results
        public async Task<IActionResult> Attendees()
        {
            return View(await context.ResultsByAttendee.OrderByDescending(i => i.Score).ToListAsync());
        }

        public async Task<IActionResult> Companies()
        {
            return View(await context.ResultsByCompany.OrderByDescending(i => i.Score).ToListAsync());
        }

        public async Task<IActionResult> Countries()
        {
            return View(await context.ResultsByCountry.OrderByDescending(i => i.Score).ToListAsync());
        }

        public async Task<IActionResult> Locations()
        {
            return View(await context.ResultsByLocation.OrderByDescending(i => i.Score).ToListAsync());
        }

    }
}
