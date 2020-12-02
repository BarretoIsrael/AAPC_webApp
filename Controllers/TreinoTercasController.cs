using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using AAPC.Data;
using AAPC.Models;

namespace AAPC.Controllers
{
    public class TreinoTercasController : Controller
    {
        private readonly MvcAAPCContext _context;

        public TreinoTercasController(MvcAAPCContext context)
        {
            _context = context;
        }

        // GET: TreinoTercas
        public async Task<IActionResult> Index(string treinoP, string searchString)
        {
            // Use LINQ to get list of genres.
            IQueryable<string> treinoQuery = from t in _context.ParticipanteTreinoTerca
                                             orderby t.Nome
                                             select t.Nome;

            var treinoTercaParticipantes = from p in _context.ParticipanteTreinoTerca
                                            select p;

            if (!string.IsNullOrEmpty(searchString))
            {
                treinoTercaParticipantes = treinoTercaParticipantes.Where(s => s.Nome.Contains(searchString));
            }

            /*   if (!string.IsNullOrEmpty(treinoP))
               {
                   participantes = participantes.Where(x => x.DiaDoTreino == treinoP);
               }*/

            var treinoVM = new TreinoViewModel
            {
                Treinos = new SelectList(await treinoQuery.Distinct().ToListAsync()),
                LPTTerca = await treinoTercaParticipantes.ToListAsync()
            };

            return View(treinoVM);
        }

        // GET: TreinoTercas/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: TreinoTercas/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Nome,Sobrenome,Nascimento")] TreinoTerca treinoTerca)
        {
            if (ModelState.IsValid)
            {
                _context.Add(treinoTerca);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(treinoTerca);
        }

        // GET: TreinoTercas/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var treinoTerca = await _context.ParticipanteTreinoTerca.FindAsync(id);
            if (treinoTerca == null)
            {
                return NotFound();
            }
            return View(treinoTerca);
        }

        // POST: TreinoTercas/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Nome,Sobrenome,Nascimento")] TreinoTerca treinoTerca)
        {
            if (id != treinoTerca.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(treinoTerca);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!TreinoTercaExists(treinoTerca.Id))
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
            return View(treinoTerca);
        }

        // GET: TreinoTercas/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var treinoTerca = await _context.ParticipanteTreinoTerca
                .FirstOrDefaultAsync(m => m.Id == id);
            if (treinoTerca == null)
            {
                return NotFound();
            }

            return View(treinoTerca);
        }

        // POST: TreinoTercas/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var treinoTerca = await _context.ParticipanteTreinoTerca.FindAsync(id);
            _context.ParticipanteTreinoTerca.Remove(treinoTerca);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool TreinoTercaExists(int id)
        {
            return _context.ParticipanteTreinoTerca.Any(e => e.Id == id);
        }
    }
}
