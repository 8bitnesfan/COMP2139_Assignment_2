using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using Assignment_1.Models;
using Microsoft.Extensions.Logging;
using Microsoft.AspNetCore.Authorization;

namespace Assignment_1.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        // Index is accessible to everyone—no forced redirect loops!
        public IActionResult Index()
        {
            _logger.LogInformation("User accessed Home/Index.");
            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }

        // GET: /Home/Create (Requires Authentication)
        [Authorize]
        public IActionResult Create()
        {
            _logger.LogInformation("Authenticated user accessed Home/Create.");
            return View();
        }

        // POST: /Home/Create
        [HttpPost]
        [Authorize]
        [ValidateAntiForgeryToken]
        public IActionResult Create(Products products)
        {
            if (ModelState.IsValid)
            {
                _logger.LogInformation("Product created successfully.");
                return RedirectToAction("Index");
            }

            return View(products);
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            _logger.LogError("An error occurred.");
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}