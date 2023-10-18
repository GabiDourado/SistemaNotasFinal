using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using SistemaNotasFinal.Models;

namespace SistemaNotasFinal.Controllers
{
    public class BimestreController : Controller
    {
        private readonly Contexto _context;

        public BimestreController(Contexto context)
        {
            _context = context;
        }

        // GET: Bimestre
        public async Task<IActionResult> Index(string pesquisa)
        {
            if (string.IsNullOrWhiteSpace(pesquisa))
            {
                return _context.Bimestre != null ?
                          View(await _context.Bimestre.ToListAsync()) :
                          Problem("Entity set 'Contexto.Bimestre'  is null.");
            }
            else
            {
                var Bimestre =
                    _context.Bimestre
                    .Where(x => x.BimestreDescricao.Contains(pesquisa))
                    .OrderBy(x => x.BimestreDescricao);
                return View(Bimestre);
            }

        }

        // GET: Bimestre/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.Bimestre == null)
            {
                return NotFound();
            }

            var bimestre = await _context.Bimestre
                .FirstOrDefaultAsync(m => m.Id == id);
            if (bimestre == null)
            {
                return NotFound();
            }

            return View(bimestre);
        }

        // GET: Bimestre/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Bimestre/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,BimestreAno,BimestreDescricao")] Bimestre bimestre)
        {
            if (ModelState.IsValid)
            {
                _context.Add(bimestre);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(bimestre);
        }

        // GET: Bimestre/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.Bimestre == null)
            {
                return NotFound();
            }

            var bimestre = await _context.Bimestre.FindAsync(id);
            if (bimestre == null)
            {
                return NotFound();
            }
            return View(bimestre);
        }

        // POST: Bimestre/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,BimestreAno,BimestreDescricao")] Bimestre bimestre)
        {
            if (id != bimestre.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(bimestre);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!BimestreExists(bimestre.Id))
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
            return View(bimestre);
        }

        // GET: Bimestre/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.Bimestre == null)
            {
                return NotFound();
            }

            var bimestre = await _context.Bimestre
                .FirstOrDefaultAsync(m => m.Id == id);
            if (bimestre == null)
            {
                return NotFound();
            }

            return View(bimestre);
        }

        // POST: Bimestre/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.Bimestre == null)
            {
                return Problem("Entity set 'Contexto.Bimestre'  is null.");
            }
            var bimestre = await _context.Bimestre.FindAsync(id);
            if (bimestre != null)
            {
                _context.Bimestre.Remove(bimestre);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool BimestreExists(int id)
        {
          return (_context.Bimestre?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}
