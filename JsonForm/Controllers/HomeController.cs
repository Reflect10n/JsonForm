using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System.Diagnostics;
using JsonForm.Models;

namespace JsonForm.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly IWebHostEnvironment webHostEnvironment;

        public HomeController(ILogger<HomeController> logger,
            IWebHostEnvironment webHostEnvironment)
        {
            _logger = logger;
            this.webHostEnvironment = webHostEnvironment;
        }

        public IActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public IActionResult SignUp(PersonData personData)
        {
            if (ModelState.IsValid)
            {
                var jSerializerSettings = new JsonSerializerSettings { DateFormatString = "yyyy/MM/dd" };
                var json = JsonConvert.SerializeObject(personData, jSerializerSettings);
                JObject obj = JObject.Parse(json);
                CreateFile(obj);
                return View("Successful");
            }
            else
                return View("Index");
        }

        private void CreateFile(JObject obj)
        {
            string currentDirectory = AppDomain.CurrentDomain.BaseDirectory + "Created Jsons\\";
            try
            {
                Directory.CreateDirectory(currentDirectory);
            }
            catch (Exception exception)
            {
                Console.WriteLine("Не удалось создать папку в указанной директории", exception);
                return;
            }
            var fileName = DateTime.Now.ToString("ddMMyy_HHmmss_ffff") + ".json";
            string filePath = Path.Combine(currentDirectory, fileName);
            System.IO.File.WriteAllText(filePath, obj.ToString());
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}