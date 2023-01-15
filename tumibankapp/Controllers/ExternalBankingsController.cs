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
    public class ExternalBankingsController : Controller
    {
        private readonly ApplicationDbContext _context;

        public ExternalBankingsController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: ExternalBankings
        public async Task<IActionResult> Index()
        {
            return View(await _context.ExternalBankings.ToListAsync());
        }

        // GET: ExternalBankings/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.ExternalBankings == null)
            {
                return NotFound();
            }

            var externalBanking = await _context.ExternalBankings
                .FirstOrDefaultAsync(m => m.ExternalTransferId == id);
            if (externalBanking == null)
            {
                return NotFound();
            }

            return View(externalBanking);
        }

        // GET: ExternalBankings/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: ExternalBankings/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("ExternalTransferId,BankName,BankAccountName,BankAddress,BankAccountNumber,BankSortCode")] ExternalBanking externalBanking)
        {
            if (ModelState.IsValid)
            {
                _context.Add(externalBanking);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(externalBanking);
        }

        // GET: ExternalBankings/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.ExternalBankings == null)
            {
                return NotFound();
            }

            var externalBanking = await _context.ExternalBankings.FindAsync(id);
            if (externalBanking == null)
            {
                return NotFound();
            }
            return View(externalBanking);
        }

        // POST: ExternalBankings/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("ExternalTransferId,BankName,BankAccountName,BankAddress,BankAccountNumber,BankSortCode")] ExternalBanking externalBanking)
        {
            if (id != externalBanking.ExternalTransferId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(externalBanking);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ExternalBankingExists(externalBanking.ExternalTransferId))
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
            return View(externalBanking);
        }

        // GET: ExternalBankings/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.ExternalBankings == null)
            {
                return NotFound();
            }

            var externalBanking = await _context.ExternalBankings
                .FirstOrDefaultAsync(m => m.ExternalTransferId == id);
            if (externalBanking == null)
            {
                return NotFound();
            }

            return View(externalBanking);
        }

        // POST: ExternalBankings/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.ExternalBankings == null)
            {
                return Problem("Entity set 'ApplicationDbContext.ExternalBankings'  is null.");
            }
            var externalBanking = await _context.ExternalBankings.FindAsync(id);
            if (externalBanking != null)
            {
                _context.ExternalBankings.Remove(externalBanking);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool ExternalBankingExists(int id)
        {
            return _context.ExternalBankings.Any(e => e.ExternalTransferId == id);
        }
    }
}
