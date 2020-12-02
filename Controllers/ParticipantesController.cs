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
    public class ParticipantesController : Controller
    {
        private readonly MvcAAPCContext _context;

        public ParticipantesController(MvcAAPCContext context)
        {
            _context = context;
        }

        // GET: Movies
        public async Task<IActionResult> Index(string treinoP, string searchString)
        {
            // Use LINQ to get list of genres.
            IQueryable<string> treinoQuery = from t in _context.Participante
                                            orderby t.DiaDoTreino
                                            select t.DiaDoTreino;

            var participantes = from p in _context.Participante
                         select p;

            if (!string.IsNullOrEmpty(searchString))
            {
                participantes = participantes.Where(s => s.Nome.Contains(searchString));
            }
            
                     /*   if (!string.IsNullOrEmpty(treinoP))
                        {
                            participantes = participantes.Where(x => x.DiaDoTreino == treinoP);
                        }*/
            
            var treinoVM = new TreinoViewModel
            {
                Treinos = new SelectList(await treinoQuery.Distinct().ToListAsync()),
                LParticipantes = await participantes.ToListAsync()
            };

            return View(treinoVM);
        }

        // GET: Participantes/Details/5
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

        // GET: Participantes/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Participantes/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Nome,Sobrenome,Nascimento,DiaDoTreino")] Participante participante)
        {
            if (ModelState.IsValid) //,GeneroParticipante,Telefone,Endereco,Bairro,Cidade,CEP
            {
                _context.Add(participante);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(participante);
        }

        // GET: Participantes/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var participante = await _context.Participante.FindAsync(id);
            if (participante == null)
            {
                return NotFound();
            }
            return View(participante);
        }

        // POST: Participantes/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Nome,Sobrenome,Nascimento,DiaDoTreino")] Participante participante)
        {
            if (id != participante.Id) //,GeneroParticipante,Telefone,Endereco,Bairro,Cidade,CEP
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(participante);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ParticipanteExists(participante.Id))
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
            return View(participante);
        }

        // GET: Participantes/Delete/5
        public async Task<IActionResult> Delete(int? id)
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

        // POST: Participantes/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var participante = await _context.Participante.FindAsync(id);
            _context.Participante.Remove(participante);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool ParticipanteExists(int id)
        {
            return _context.Participante.Any(e => e.Id == id);
        }
    }
}
