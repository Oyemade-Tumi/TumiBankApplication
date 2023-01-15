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
    public class OverDraftsController : Controller
    {
        private readonly ApplicationDbContext _context;

        public OverDraftsController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: OverDrafts
        public async Task<IActionResult> Index()
        {
            return View(await _context.OverDrafts.ToListAsync());
        }

        // GET: OverDrafts/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.OverDrafts == null)
            {
                return NotFound();
            }

            var overDraft = await _context.OverDrafts
                .FirstOrDefaultAsync(m => m.OverDraftId == id);
            if (overDraft == null)
            {
                return NotFound();
            }

            return View(overDraft);
        }

        // GET: OverDrafts/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: OverDrafts/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("OverDraftId,Overdraftfee,DeductOverdraftFee")] OverDraft overDraft)
        {
            if (ModelState.IsValid)
            {
                _context.Add(overDraft);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(overDraft);
        }

        // GET: OverDrafts/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.OverDrafts == null)
            {
                return NotFound();
            }

            var overDraft = await _context.OverDrafts.FindAsync(id);
            if (overDraft == null)
            {
                return NotFound();
            }
            return View(overDraft);
        }

        // POST: OverDrafts/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("OverDraftId,Overdraftfee,DeductOverdraftFee")] OverDraft overDraft)
        {
            if (id != overDraft.OverDraftId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(overDraft);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!OverDraftExists(overDraft.OverDraftId))
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
            return View(overDraft);
        }

        // GET: OverDrafts/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.OverDrafts == null)
            {
                return NotFound();
            }

            var overDraft = await _context.OverDrafts
                .FirstOrDefaultAsync(m => m.OverDraftId == id);
            if (overDraft == null)
            {
                return NotFound();
            }

            return View(overDraft);
        }

        // POST: OverDrafts/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.OverDrafts == null)
            {
                return Problem("Entity set 'ApplicationDbContext.OverDrafts'  is null.");
            }
            var overDraft = await _context.OverDrafts.FindAsync(id);
            if (overDraft != null)
            {
                _context.OverDrafts.Remove(overDraft);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool OverDraftExists(int id)
        {
            return _context.OverDrafts.Any(e => e.OverDraftId == id);
        }
    }
}
