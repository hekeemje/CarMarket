using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using CarMarket.Models;
using System.Diagnostics;
using System.Threading.Tasks;
using CarMarket.DAL.Interfaces;

namespace CarMarket.Controllers
{
    [Route("/")]
    [Route("Home")]
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        public object Car { get; private set; }

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        [HttpGet("")]
        public IActionResult Index()
        {



            return View(viewName: "Index");
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View("тiпа кастомний error");
        }
    }
}
