using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using ServerApp.Models;
using ServerApp.Services;

namespace ServerApp.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly IEmployeeService employeeService;

        public HomeController(ILogger<HomeController> logger, IEmployeeService employeeService)
        {
            _logger = logger;
            this.employeeService = employeeService;
        }

        public async Task<IActionResult> Index()
        {
            var users = await employeeService.GetEmployees();
            return View(users);
        }

        [Route("add")]
        public IActionResult AddUser()
        {
            return View(employeeService.GetCreatioInfo());
        }

        [HttpPost]
        public IActionResult SaveUser(Employee user)
        {
            employeeService.CreateEmployee(user);
            return RedirectToAction("Index");
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
