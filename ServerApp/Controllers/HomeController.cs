using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Extensions.Logging;
using ServerApp.Models;
using ServerApp.Services;

namespace ServerApp.Controllers
{
    public class HomeController : Controller
    {
        private readonly IEmployeeService employeeService;

        public HomeController(ILogger<HomeController> logger, IEmployeeService employeeService)
        {
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
            return View((new Employee(), employeeService.GetCreationInfo()));
        }

        [HttpPost]
        public async Task<IActionResult> SaveUser(Employee item1)
        {
            if (!ModelState.IsValid)
            {
                return View("AddUser", (item1, employeeService.GetCreationInfo()));
            }

            if (employeeService.CheckIfPassportExist(item1))
            {
                ViewBag.Errors = "Пользователь с такими паспортными данными уже существует.";
                return View("AddUser", (item1, employeeService.GetCreationInfo()));
            }

            await employeeService.CreateEmployee(item1);
            return RedirectToAction("Index");
        }

        [Route("delete/{id}")]
        public async Task<IActionResult> DeleteUser(string id)
        {
            await employeeService.DeleteEmployee(id);
            return RedirectToAction("Index");
        }


        [Route("edit/{id}")]
        public async Task<IActionResult> Edit(string id)
        {
            return View("EditUser", (await employeeService.SingleEmployee(id), employeeService.GetCreationInfo()));
        }      
        
        [HttpPost]
        public async Task<IActionResult> EditUser(Employee item1)
        {
            if (!ModelState.IsValid)    
            {
                return View("EditUser", (item1, employeeService.GetCreationInfo()));
            }

            if (employeeService.CheckIfPassportExist(item1))
            {
                ViewBag.Errors = "Пользователь с такими паспортными данными уже существует.";
                return View("EditUser", (item1, employeeService.GetCreationInfo()));
            }

            await employeeService.EditEmployee(item1.Id, item1);
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
