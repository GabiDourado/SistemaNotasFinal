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
    public class ProfessorController : Controller
    {
        private readonly Contexto _context;

        public ProfessorController(Contexto context)
        {
            _context = context;
        }

        // GET: Professor
        public async Task<IActionResult> Index(string pesquisa)
        {
            if (string.IsNullOrWhiteSpace(pesquisa))
            {
                return _context.Professor
                          .Include(n => n.Materia) != null ?
                          View(await _context.Professor.Include(n => n.Materia).ToListAsync()) :
                          Problem("Entity set 'Contexto.Professor'  is null.");
            }
            else
            {
           
                var professors =
                    _context.Professor
                    .Include(n => n.Materia)
                    .Where(x => x.NomeProfessor.Contains(pesquisa))
                    .OrderBy(x => x.NomeProfessor);
                return View(professors);
            }
            
        }

        // GET: Professor/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.Professor == null)
            {
                return NotFound();
            }

            var professor = await _context.Professor
                .Include(p => p.Materia)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (professor == null)
            {
                return NotFound();
            }

            return View(professor);
        }

        // GET: Professor/Create
        public IActionResult Create()
        {
            ViewData["MateriaNome"] = new SelectList(_context.Materia, "Id", "MateriaNome");
            return View();
        }

        // POST: Professor/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,NomeProfessor,ProfessorFormacao,TempoTrabalho,MateriaId")] Professor professor)
        {
            if (ModelState.IsValid)
            {
                _context.Add(professor);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["MateriaNome"] = new SelectList(_context.Materia, "Id", "MateriaNome", professor.MateriaId);
            return View(professor);
        }

        // GET: Professor/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.Professor == null)
            {
                return NotFound();
            }

            var professor = await _context.Professor.FindAsync(id);
            if (professor == null)
            {
                return NotFound();
            }
            ViewData["MateriaNome"] = new SelectList(_context.Materia, "Id", "MateriaNome", professor.MateriaId);
            return View(professor);
        }

        // POST: Professor/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,NomeProfessor,ProfessorFormacao,TempoTrabalho,MateriaId")] Professor professor)
        {
            if (id != professor.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(professor);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ProfessorExists(professor.Id))
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
            ViewData["MateriaNome"] = new SelectList(_context.Materia, "Id", "MateriaNome", professor.MateriaId);
            return View(professor);
        }

        // GET: Professor/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.Professor == null)
            {
                return NotFound();
            }

            var professor = await _context.Professor
                .Include(p => p.Materia)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (professor == null)
            {
                return NotFound();
            }

            return View(professor);
        }

        // POST: Professor/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.Professor == null)
            {
                return Problem("Entity set 'Contexto.Professor'  is null.");
            }
            var professor = await _context.Professor.FindAsync(id);
            if (professor != null)
            {
                _context.Professor.Remove(professor);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool ProfessorExists(int id)
        {
          return (_context.Professor?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}
