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
    public class CreditController : Controller
    {
        private readonly SqlDbContext _context;
        private readonly IEmployeeService _employeeService;

        public CreditController(SqlDbContext context, IEmployeeService employeeService)
        {
            _context = context;
            _employeeService = employeeService;
        }

        [Route("credits/calculate/{id}")]
        public IActionResult Calculate(string id)
        {
            float takenValue = 0;
            foreach (var credit in _context.Credit.ToList())
            {
                float sum;
                if (credit.Type == CreditType.Different)
                {
                    var random = new Random();
                    sum = credit.StartSum / (credit.ContractTerm * 12) + (float)(credit.Sum * credit.Percent * 0.01 / 365 * random.Next(29, 31));
                    credit.Sum -= credit.StartSum / (credit.ContractTerm * 12);
                }
                else
                {
                    var percent = credit.Percent * 0.01 / 12;
                    var koef = percent * Math.Pow(1 + percent, credit.ContractTerm * 12) / (Math.Pow(1 + percent, credit.ContractTerm * 12) - 1);
                    sum = (float)koef * credit.StartSum;
                    credit.Sum -= sum;
                }

                if (id == credit.UserId)
                {
                    takenValue += sum;
                }

                if (credit.Sum == 0)
                {
                    _context.Credit.Remove(credit);
                }
                else
                {
                    _context.Credit.Update(credit);
                }
            }
            _context.SaveChanges();
            return RedirectToAction(nameof(Index), new {id, takenValue });
        }

        [HttpPost]
        [Route("credits/take/{id}")]
        public IActionResult TakeMoney(int id)
        {
            if (!DepositExists(id)) return BadRequest();
            var credit = _context.Credit.FirstOrDefault(x => x.Id == id);
            if (credit?.Type == CreditType.Monthly)
            {
                credit.Sum = credit.StartSum;
                _context.Update(credit);
            }

            _context.SaveChanges();
            return Ok();
        }

        // GET: Deposit
        [Route("credits/{id}")]
        public async Task<IActionResult> Index(string id)
        {
            var sqlDbContext = _context.Credit.Include(d => d.Currency).Include(d => d.User).Where(x => x.UserId == id);
            ViewBag.UserId = id;
            return View(await sqlDbContext.ToListAsync());
        }

        // GET: Deposit/Create
        [Route("credits/create/{id}")]
        public IActionResult Create(string id)
        {
            ViewBag.UserId = id;
            return View((new Credit(), _employeeService.GetCreationInfo()));
        }

        // POST: Deposit/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        [Route("credits/create/{id}")]
        public async Task<IActionResult> Create(Credit item1)
        {
            if (ModelState.IsValid)
            {
                if (item1.Type == CreditType.Monthly)
                {
                    var percent = item1.Percent * 0.01 / 12;
                    var koef = (percent * Math.Pow(1 + percent, item1.ContractTerm * 12)) / (Math.Pow(1 + percent, item1.ContractTerm * 12) - 1);
                    item1.Sum = item1.StartSum * item1.ContractTerm * 12 * (float) koef;
                }
                else
                {
                    item1.Sum = item1.StartSum;
                }

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
