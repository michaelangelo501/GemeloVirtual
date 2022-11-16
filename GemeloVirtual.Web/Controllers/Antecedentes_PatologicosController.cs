using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using GemeloVirtual.Web.Data;
using GemeloVirtual.Web.Data.Entities;

namespace GemeloVirtual.Web.Controllers
{
    public class Antecedentes_PatologicosController : Controller
    {
        private readonly DataContext _context;

        public Antecedentes_PatologicosController(DataContext context)
        {
            _context = context;
        }

        // GET: Antecedentes_Patologicos
        public async Task<IActionResult> Index()
        {
            return View(await _context.Antecedentes_Patologicos.ToListAsync());
        }

        // GET: Antecedentes_Patologicos/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var antecedentes_Patologicos = await _context.Antecedentes_Patologicos
                .FirstOrDefaultAsync(m => m.Id == id);
            if (antecedentes_Patologicos == null)
            {
                return NotFound();
            }

            return View(antecedentes_Patologicos);
        }

        // GET: Antecedentes_Patologicos/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Antecedentes_Patologicos/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Alergias,Cirugias_Previas,Accidentes_Previos,Enfermedad_Diagnosticada,Infecciones,Uso_Medicamentos,Transfucion_Sangre,Tabaco,Alcohol")] Antecedentes_Patologicos antecedentes_Patologicos)
        {
            if (ModelState.IsValid)
            {
                _context.Add(antecedentes_Patologicos);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(antecedentes_Patologicos);
        }

        // GET: Antecedentes_Patologicos/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var antecedentes_Patologicos = await _context.Antecedentes_Patologicos.FindAsync(id);
            if (antecedentes_Patologicos == null)
            {
                return NotFound();
            }
            return View(antecedentes_Patologicos);
        }

        // POST: Antecedentes_Patologicos/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Alergias,Cirugias_Previas,Accidentes_Previos,Enfermedad_Diagnosticada,Infecciones,Uso_Medicamentos,Transfucion_Sangre,Tabaco,Alcohol")] Antecedentes_Patologicos antecedentes_Patologicos)
        {
            if (id != antecedentes_Patologicos.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(antecedentes_Patologicos);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!Antecedentes_PatologicosExists(antecedentes_Patologicos.Id))
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
            return View(antecedentes_Patologicos);
        }

        // GET: Antecedentes_Patologicos/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var antecedentes_Patologicos = await _context.Antecedentes_Patologicos
                .FirstOrDefaultAsync(m => m.Id == id);
            if (antecedentes_Patologicos == null)
            {
                return NotFound();
            }

            return View(antecedentes_Patologicos);
        }

        // POST: Antecedentes_Patologicos/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var antecedentes_Patologicos = await _context.Antecedentes_Patologicos.FindAsync(id);
            _context.Antecedentes_Patologicos.Remove(antecedentes_Patologicos);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool Antecedentes_PatologicosExists(int id)
        {
            return _context.Antecedentes_Patologicos.Any(e => e.Id == id);
        }
    }
}
