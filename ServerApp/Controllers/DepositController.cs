using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using ServerApp.DataAccess;
using ServerApp.Models;
using ServerApp.Services;

namespace ServerApp.Controllers
{
    public class DepositController : Controller
    {
        private readonly SqlDbContext _context;
        private readonly IEmployeeService _employeeService;

        public DepositController(SqlDbContext context, IEmployeeService employeeService)
        {
            _context = context;
            _employeeService = employeeService;
        }

        [Route("deposits/calculate/{id}")]
        public IActionResult Calculate(string id)
        {
            foreach (var deposit in _context.Deposit.ToList())
            {
                var percent = deposit.Type == DepositType.Monthly
                    ? deposit.Percent / 100
                    : deposit.Percent / deposit.ContractTerm / 100;
                deposit.Sum += deposit.Sum * percent;
                _context.Update(deposit);
            }
            _context.SaveChanges();
            return RedirectToAction(nameof(Index), new {id});
        }

        [HttpPost]
        [Route("deposits/take/{id}")]
        public IActionResult TakeMoney(int id)
        {
            if (!DepositExists(id)) return BadRequest();
            var deposit = _context.Deposit.FirstOrDefault(x => x.Id == id);
            if (deposit?.Type == DepositType.Monthly)
            {
                deposit.Sum = deposit.StartSum;
                _context.Update(deposit);
            }

            if (deposit?.Type == DepositType.Urgent)
            {
                _context.Deposit.Remove(deposit);
            }

            _context.SaveChanges();
            return Ok();
        }

        // GET: Deposit
        [Route("deposits/{id}")]
        public async Task<IActionResult> Index(string id)
        {
            var sqlDbContext = _context.Deposit.Include(d => d.Currency).Include(d => d.User).Where(x => x.UserId == id);
            ViewBag.UserId = id;
            return View(await sqlDbContext.ToListAsync());
        }

        // GET: Deposit/Create
        [Route("deposits/create/{id}")]
        public IActionResult Create(string id)
        {
            ViewBag.UserId = id;
            return View((new Deposit(), _employeeService.GetCreationInfo()));
        }

        // POST: Deposit/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        [Route("deposits/create/{id}")]
        public async Task<IActionResult> Create(Deposit item1)
        {
            if (ModelState.IsValid)
            {
                item1.Sum = item1.StartSum;
                _context.Add(item1);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index), new { id = item1.UserId });
            }
            ViewData["CurrencyId"] = new SelectList(_context.Set<Currency>(), "Id", "Id", item1.CurrencyId);
            ViewData["UserId"] = new SelectList(_context.Employees, "Id", "Id", item1.UserId);
            return View();
        }

        private bool DepositExists(int id)
        {
            return _context.Deposit.Any(e => e.Id == id);
        }
    }
}
