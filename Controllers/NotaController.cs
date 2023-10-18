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
    public class NotaController : Controller
    {
        private readonly Contexto _context;

        public NotaController(Contexto context)
        {
            _context = context;
        }

        // GET: Nota

        public async Task<IActionResult> Index(string pesquisa)
        {
            if (pesquisa == null)
            {
                return _context.Nota
                            .Include(n => n.Aluno)
                            .Include(n => n.Bimestre)
                            .Include(n => n.Materia) != null ?
                          View(await _context.Nota.Include(n => n.Aluno)
                            .Include(n => n.Bimestre)
                            .Include(n => n.Materia).ToListAsync()) :
                          Problem("Entity set 'Contexto.Nota'  is null.");
            }
            else
            {
                var Aluno =
                    _context.Nota
                    .Include(x=> x.Aluno)
                    .Include(n => n.Bimestre)
                    .Include(n => n.Materia)
                    .Where(x => x.Aluno.NomeAluno.Contains(pesquisa))
                    .OrderBy(x => x.AlunoId);

                return View(Aluno);
            }
        }
        // GET: Nota/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.Nota == null)
            {
                return NotFound();
            }

            var nota = await _context.Nota
                .Include(n => n.Aluno)
                .Include(n => n.Bimestre)
                .Include(n => n.Materia)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (nota == null)
            {
                return NotFound();
            }

            return View(nota);
        }

        // GET: Nota/Create
        public IActionResult Create()
        {
            ViewData["AlunoId"] = new SelectList(_context.Aluno, "Id", "NomeAluno");
            ViewData["BimestreId"] = new SelectList(_context.Bimestre, "Id", "BimestreDescricao");
            ViewData["MateriaId"] = new SelectList(_context.Materia, "Id", "MateriaNome");
            return View();
        }

        // POST: Nota/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,AlunoId,MateriaId,BimestreId,Notas1,Notas2")] Nota nota)
        {
            if (ModelState.IsValid)
            {
                _context.Add(nota);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["AlunoId"] = new SelectList(_context.Aluno, "Id", "NomeAluno", nota.AlunoId);
            ViewData["BimestreId"] = new SelectList(_context.Bimestre, "Id", "BimestreDescricao", nota.BimestreId);
            ViewData["MateriaId"] = new SelectList(_context.Materia, "Id", "MateriaNome", nota.MateriaId);
            return View(nota);
        }

        // GET: Nota/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.Nota == null)
            {
                return NotFound();
            }

            var nota = await _context.Nota.FindAsync(id);
            if (nota == null)
            {
                return NotFound();
            }
            ViewData["AlunoId"] = new SelectList(_context.Aluno, "Id", "NomeAluno", nota.AlunoId);
            ViewData["BimestreId"] = new SelectList(_context.Bimestre, "Id", "BimestreDescricao", nota.BimestreId);
            ViewData["MateriaId"] = new SelectList(_context.Materia, "Id", "MateriaNome", nota.MateriaId);
            return View(nota);
        }

        // POST: Nota/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,AlunoId,MateriaId,BimestreId,Notas1,Notas2")] Nota nota)
        {
            if (id != nota.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(nota);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!NotaExists(nota.Id))
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
            ViewData["AlunoId"] = new SelectList(_context.Aluno, "Id", "NomeAluno", nota.AlunoId);
            ViewData["BimestreId"] = new SelectList(_context.Bimestre, "Id", "BimestreDescricao", nota.BimestreId);
            ViewData["MateriaId"] = new SelectList(_context.Materia, "Id", "MateriaNome", nota.MateriaId);
            return View(nota);
        }

        // GET: Nota/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.Nota == null)
            {
                return NotFound();
            }

            var nota = await _context.Nota
                .Include(n => n.Aluno)
                .Include(n => n.Bimestre)
                .Include(n => n.Materia)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (nota == null)
            {
                return NotFound();
            }

            return View(nota);
        }

        // POST: Nota/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.Nota == null)
            {
                return Problem("Entity set 'Contexto.Nota'  is null.");
            }
            var nota = await _context.Nota.FindAsync(id);
            if (nota != null)
            {
                _context.Nota.Remove(nota);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool NotaExists(int id)
        {
          return (_context.Nota?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}
