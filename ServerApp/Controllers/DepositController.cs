using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using ServerApp.DataAccess;
using ServerApp.Models;

namespace ServerApp.Controllers
{
    public class DepositController : Controller
    {
        private readonly SqlDbContext _context;

        public DepositController(SqlDbContext context)
        {
            _context = context;
        }

        // GET: Deposit
        [Route("deposits/{id}")]
        public async Task<IActionResult> Index(string id)
        {
            var sqlDbContext = _context.Deposit.Include(d => d.Currency).Include(d => d.User).Where(x => x.UserId == id);
            return View(await sqlDbContext.ToListAsync());
        }

        // GET: Deposit/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var deposit = await _context.Deposit
                .Include(d => d.Currency)
                .Include(d => d.User)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (deposit == null)
            {
                return NotFound();
            }

            return View(deposit);
        }

        // GET: Deposit/Create
        public IActionResult Create()
        {
            ViewData["CurrencyId"] = new SelectList(_context.Set<Currency>(), "Id", "Id");
            ViewData["UserId"] = new SelectList(_context.Employees, "Id", "Id");
            return View();
        }

        // POST: Deposit/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,ContractNumber,Type,CurrencyId,StartDate,EndDate,ContractTerm,Sum,Percent,UserId")] Deposit deposit)
        {
            if (ModelState.IsValid)
            {
                _context.Add(deposit);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["CurrencyId"] = new SelectList(_context.Set<Currency>(), "Id", "Id", deposit.CurrencyId);
            ViewData["UserId"] = new SelectList(_context.Employees, "Id", "Id", deposit.UserId);
            return View(deposit);
        }

        // GET: Deposit/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var deposit = await _context.Deposit.FindAsync(id);
            if (deposit == null)
            {
                return NotFound();
            }
            ViewData["CurrencyId"] = new SelectList(_context.Set<Currency>(), "Id", "Id", deposit.CurrencyId);
            ViewData["UserId"] = new SelectList(_context.Employees, "Id", "Id", deposit.UserId);
            return View(deposit);
        }

        // POST: Deposit/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,ContractNumber,Type,CurrencyId,StartDate,EndDate,ContractTerm,Sum,Percent,UserId")] Deposit deposit)
        {
            if (id != deposit.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(deposit);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!DepositExists(deposit.Id))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Index));
            }
            ViewData["CurrencyId"] = new SelectList(_context.Set<Currency>(), "Id", "Id", deposit.CurrencyId);
            ViewData["UserId"] = new SelectList(_context.Employees, "Id", "Id", deposit.UserId);
            return View(deposit);
        }

        // GET: Deposit/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var deposit = await _context.Deposit
                .Include(d => d.Currency)
                .Include(d => d.User)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (deposit == null)
            {
                return NotFound();
            }

            return View(deposit);
        }

        // POST: Deposit/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var deposit = await _context.Deposit.FindAsync(id);
            _context.Deposit.Remove(deposit);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool DepositExists(int id)
        {
            return _context.Deposit.Any(e => e.Id == id);
        }
    }
}
