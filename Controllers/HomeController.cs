using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using AgroControl.Models;
using Microsoft.AspNetCore.Authorization;

namespace AgroControl.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;

        }

        [AllowAnonymous]
        public IActionResult Index()
        {
            SetViewBagMessages();
            return View();
        }

        [AllowAnonymous]
        public IActionResult Privacy()
        {
            SetViewBagMessages();
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
        private void SetViewBagMessages()
        {
            ViewBag.Message += TempData["Message"];
            ViewBag.MessageType += TempData["MessageType"];
        }
    }
}
