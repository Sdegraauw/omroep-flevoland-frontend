using Microsoft.AspNetCore.Mvc;
using MVC_omroep_flevoland_chat_frontend.Models;
using System.Diagnostics;
using System.Security.Cryptography;

namespace MVC_omroep_flevoland_chat_frontend.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        public IActionResult Index()
        {
            API model = new API(
                Environment.GetEnvironmentVariable("BASE_URL"),
                Environment.GetEnvironmentVariable("FLOW_ID"));
            return View("index",model);
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
