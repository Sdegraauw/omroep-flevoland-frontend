using Microsoft.AspNetCore.Mvc;
using MVC_omroep_flevoland_chat_frontend.Models;
using NuGet.Protocol;
using System.Diagnostics;
using System.Net.Http;

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
            if (file == null) { return View(); }

            //setting up Request objects
            HttpClient client = new HttpClient();
            MultipartFormDataContent formContent = new MultipartFormDataContent("NKdKd9Yk");

            //Adding content
            formContent.Headers.ContentType.MediaType = "multipart/form-data";
            StringContent content = new StringContent(file.ToJson());
            formContent.Add(content, "files", file.FileName);
            Console.WriteLine(formContent.ToArray());

            //API call
            HttpResponseMessage response = await client.PostAsync("http://localhost:3000/api/v1/vector/upsert/fe443d55-fdde-4c6d-88f6-1c40d14c49e3", formContent);
            string responseString = await response.Content.ReadAsStringAsync();
            Console.WriteLine(responseString);

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
