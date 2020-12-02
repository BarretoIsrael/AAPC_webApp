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
    public class TreinoQuintasController : Controller
    {
        private readonly MvcAAPCContext _context;

        public TreinoQuintasController(MvcAAPCContext context)
        {
            _context = context;
        }

        // GET: TreinoQuintas
        public async Task<IActionResult> Index(string treinoP, string searchString)
        {
            // Use LINQ to get list of genres.
            IQueryable<string> treinoQuery = from t in _context.ParticipanteTreinoQuinta
                                             orderby t.Nome
                                             select t.Nome;

            var treinoQuintaParticipantes = from p in _context.ParticipanteTreinoQuinta
                                            select p;

            if (!string.IsNullOrEmpty(searchString))
            {
                treinoQuintaParticipantes = treinoQuintaParticipantes.Where(s => s.Nome.Contains(searchString));
            }

            /*   if (!string.IsNullOrEmpty(treinoP))
               {
                   participantes = participantes.Where(x => x.DiaDoTreino == treinoP);
               }*/

            var treinoVM = new TreinoViewModel
            {
                Treinos = new SelectList(await treinoQuery.Distinct().ToListAsync()),
                LPTQuinta = await treinoQuintaParticipantes.ToListAsync()
            };

            return View(treinoVM);
        }

        // GET: TreinoQuintas/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: TreinoQuintas/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Nome,Sobrenome,Nascimento")] TreinoQuinta treinoQuinta)
        {
            if (ModelState.IsValid)
            {
                _context.Add(treinoQuinta);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(treinoQuinta);
        }

        // GET: TreinoQuintas/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var treinoQuinta = await _context.ParticipanteTreinoQuinta.FindAsync(id);
            if (treinoQuinta == null)
            {
                return NotFound();
            }
            return View(treinoQuinta);
        }

        // POST: TreinoQuintas/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Nome,Sobrenome,Nascimento")] TreinoQuinta treinoQuinta)
        {
            if (id != treinoQuinta.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(treinoQuinta);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!TreinoQuintaExists(treinoQuinta.Id))
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
            return View(treinoQuinta);
        }

        // GET: TreinoQuintas/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var treinoQuinta = await _context.ParticipanteTreinoQuinta
                .FirstOrDefaultAsync(m => m.Id == id);
            if (treinoQuinta == null)
            {
                return NotFound();
            }

            return View(treinoQuinta);
        }

        // POST: TreinoQuintas/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var treinoQuinta = await _context.ParticipanteTreinoQuinta.FindAsync(id);
            _context.ParticipanteTreinoQuinta.Remove(treinoQuinta);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool TreinoQuintaExists(int id)
        {
            return _context.ParticipanteTreinoQuinta.Any(e => e.Id == id);
        }
    }
}
