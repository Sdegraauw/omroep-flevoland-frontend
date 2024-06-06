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
        public async Task<IActionResult> Index(IFormFile file)
        {

            HttpClient client = new HttpClient();
            using (var content = new MultipartFormDataContent())
            {
                byte[] fileBytes = new byte[file.OpenReadStream().Length];
                await file.OpenReadStream().ReadAsync(fileBytes, 0, (int)file.OpenReadStream().Length);
                ByteArrayContent bytes = new ByteArrayContent(fileBytes);

                content.Add(bytes, "files", file.FileName);
                Console.WriteLine(await content.ReadAsStringAsync());

                var response = await client.PostAsync("http://localhost:3000/api/v1/vector/upsert/fe443d55-fdde-4c6d-88f6-1c40d14c49e3", content);
                var responseString = await response.Content.ReadAsStringAsync();

                Console.WriteLine(responseString);
            }

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
