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
    public class TreinoSabadoesController : Controller
    {
        private readonly MvcAAPCContext _context;

        public TreinoSabadoesController(MvcAAPCContext context)
        {
            _context = context;
        }

        // GET: TreinoSabadoes
        public async Task<IActionResult> Index(string treinoP, string searchString)
        {
            // Use LINQ to get list of genres.
            IQueryable<string> treinoQuery = from t in _context.ParticipanteTreinoSabado
                                             orderby t.Nome
                                             select t.Nome;

            var treinoSabadoParticipantes = from p in _context.ParticipanteTreinoSabado
                                select p;

            if (!string.IsNullOrEmpty(searchString))
            {
                treinoSabadoParticipantes = treinoSabadoParticipantes.Where(s => s.Nome.Contains(searchString));
            }

            /*   if (!string.IsNullOrEmpty(treinoP))
               {
                   participantes = participantes.Where(x => x.DiaDoTreino == treinoP);
               }*/

            var treinoVM = new TreinoViewModel
            {
                Treinos = new SelectList(await treinoQuery.Distinct().ToListAsync()),
                LPTSabado = await treinoSabadoParticipantes.ToListAsync()
            };

            return View(treinoVM);
        }

        // GET: TreinoSabadoes/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var participante = await _context.Participante
                .FirstOrDefaultAsync(m => m.Id == id);
            if (participante == null)
            {
                return NotFound();
            }

            return View(participante);
        }

        // GET: TreinoSabadoes/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: TreinoSabadoes/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Nome,Sobrenome,Nascimento")] TreinoSabado treinoSabado)
        {
            if (ModelState.IsValid)
            {
                _context.Add(treinoSabado);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(treinoSabado);
        }

        // GET: TreinoSabadoes/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var treinoSabado = await _context.ParticipanteTreinoSabado.FindAsync(id);
            if (treinoSabado == null)
            {
                return NotFound();
            }
            return View(treinoSabado);
        }

        // POST: TreinoSabadoes/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Nome,Sobrenome,Nascimento")] TreinoSabado treinoSabado)
        {
            if (id != treinoSabado.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(treinoSabado);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!TreinoSabadoExists(treinoSabado.Id))
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
            return View(treinoSabado);
        }

        // GET: TreinoSabadoes/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var treinoSabado = await _context.ParticipanteTreinoSabado
                .FirstOrDefaultAsync(m => m.Id == id);
            if (treinoSabado == null)
            {
                return NotFound();
            }

            return View(treinoSabado);
        }

        // POST: TreinoSabadoes/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var treinoSabado = await _context.ParticipanteTreinoSabado.FindAsync(id);
            _context.ParticipanteTreinoSabado.Remove(treinoSabado);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool TreinoSabadoExists(int id)
        {
            return _context.ParticipanteTreinoSabado.Any(e => e.Id == id);
        }
    }
}
