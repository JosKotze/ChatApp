using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using ChatApp.Models;

namespace ChatApp.Controllers
{
    // Define the HomeController class which inherits from Controller.
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        // Constructor that injects an instance of ILogger<HomeController>.
        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        // Action method for the "Index" view.
        public IActionResult Index()
        {
            return View();
        }

        // Action method for the "Privacy" view.
        public IActionResult Privacy()
        {
            return View();
        }

        // Action method for handling errors and displaying the "Error" view.
        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            // Create an ErrorViewModel with a RequestId.
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}