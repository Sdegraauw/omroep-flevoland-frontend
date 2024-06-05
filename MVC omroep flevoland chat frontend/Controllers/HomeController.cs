using Microsoft.AspNetCore.Mvc;
using MVC_omroep_flevoland_chat_frontend.Models;
using NuGet.Protocol;
using System.ComponentModel.DataAnnotations;
using System.Diagnostics;
using System.Net.Http.Json;
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

        [HttpGet]
        public IActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Index(IFormFile file)
        {
            HttpClient client = new HttpClient();
            StreamContent stream = new StreamContent(file.OpenReadStream());
            Console.WriteLine(stream.ReadAsStringAsync().Result);
            string Json = "{ file:" + stream.ReadAsStringAsync().Result + "}";
            client.PostAsJsonAsync($"http://localhost:3000/api/v1/vector/upsert/fe443d55-fdde-4c6d-88f6-1c40d14c49e3",Json);

            return View();
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
