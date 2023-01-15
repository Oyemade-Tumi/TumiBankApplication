using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using tumibankapp.Data;

namespace tumibankapp.Controllers
{
    public class BankAccountController : Controller
    {
        private readonly ApplicationDbContext _context;

        public BankAccountController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: BankAccount
        public async Task<IActionResult> Index()
        {
            return View(await _context.BankAccounts.ToListAsync());
        }

        // GET: BankAccount/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.BankAccounts == null)
            {
                return NotFound();
            }

            var bankAccountTbl = await _context.BankAccounts
                .FirstOrDefaultAsync(m => m.AccountId == id);
            if (bankAccountTbl == null)
            {
                return NotFound();
            }

            return View(bankAccountTbl);
        }

        // GET: BankAccount/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: BankAccount/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("AccountId,AccountNumber,FirstName,LastName,EmailAddress,PhoneNumber,IsCorporate,AccountType,OpeningDate,ClosedDate")] BankAccountTbl bankAccountTbl)
        {
            if (ModelState.IsValid)
            {
                _context.Add(bankAccountTbl);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(bankAccountTbl);
        }

        // GET: BankAccount/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.BankAccounts == null)
            {
                return NotFound();
            }

            var bankAccountTbl = await _context.BankAccounts.FindAsync(id);
            if (bankAccountTbl == null)
            {
                return NotFound();
            }
            return View(bankAccountTbl);
        }

        // POST: BankAccount/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("AccountId,AccountNumber,FirstName,LastName,EmailAddress,PhoneNumber,IsCorporate,AccountType,OpeningDate,ClosedDate")] BankAccountTbl bankAccountTbl)
        {
            if (id != bankAccountTbl.AccountId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(bankAccountTbl);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!BankAccountTblExists(bankAccountTbl.AccountId))
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
            return View(bankAccountTbl);
        }

        // GET: BankAccount/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.BankAccounts == null)
            {
                return NotFound();
            }

            var bankAccountTbl = await _context.BankAccounts
                .FirstOrDefaultAsync(m => m.AccountId == id);
            if (bankAccountTbl == null)
            {
                return NotFound();
            }

            return View(bankAccountTbl);
        }

        // POST: BankAccount/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.BankAccounts == null)
            {
                return Problem("Entity set 'ApplicationDbContext.BankAccounts'  is null.");
            }
            var bankAccountTbl = await _context.BankAccounts.FindAsync(id);
            if (bankAccountTbl != null)
            {
                _context.BankAccounts.Remove(bankAccountTbl);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool BankAccountTblExists(int id)
        {
            return _context.BankAccounts.Any(e => e.AccountId == id);
        }
    }
}
