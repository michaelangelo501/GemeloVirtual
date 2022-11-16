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
    public class Antecedentes_No_PatologicosController : Controller
    {
        private readonly DataContext _context;

        public Antecedentes_No_PatologicosController(DataContext context)
        {
            _context = context;
        }

        // GET: Antecedentes_No_Patologicos
        public async Task<IActionResult> Index()
        {
            return View(await _context.Antecedentes_No_Patologicos.ToListAsync());
        }

        // GET: Antecedentes_No_Patologicos/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var antecedentes_No_Patologicos = await _context.Antecedentes_No_Patologicos
                .FirstOrDefaultAsync(m => m.Id == id);
            if (antecedentes_No_Patologicos == null)
            {
                return NotFound();
            }

            return View(antecedentes_No_Patologicos);
        }

        // GET: Antecedentes_No_Patologicos/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Antecedentes_No_Patologicos/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Vivienda,Servicios,Higiene,Alimentacion,Habitos,Mascotas")] Antecedentes_No_Patologicos antecedentes_No_Patologicos)
        {
            if (ModelState.IsValid)
            {
                _context.Add(antecedentes_No_Patologicos);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(antecedentes_No_Patologicos);
        }

        // GET: Antecedentes_No_Patologicos/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var antecedentes_No_Patologicos = await _context.Antecedentes_No_Patologicos.FindAsync(id);
            if (antecedentes_No_Patologicos == null)
            {
                return NotFound();
            }
            return View(antecedentes_No_Patologicos);
        }

        // POST: Antecedentes_No_Patologicos/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Vivienda,Servicios,Higiene,Alimentacion,Habitos,Mascotas")] Antecedentes_No_Patologicos antecedentes_No_Patologicos)
        {
            if (id != antecedentes_No_Patologicos.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(antecedentes_No_Patologicos);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!Antecedentes_No_PatologicosExists(antecedentes_No_Patologicos.Id))
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
            return View(antecedentes_No_Patologicos);
        }

        // GET: Antecedentes_No_Patologicos/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var antecedentes_No_Patologicos = await _context.Antecedentes_No_Patologicos
                .FirstOrDefaultAsync(m => m.Id == id);
            if (antecedentes_No_Patologicos == null)
            {
                return NotFound();
            }

            return View(antecedentes_No_Patologicos);
        }

        // POST: Antecedentes_No_Patologicos/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var antecedentes_No_Patologicos = await _context.Antecedentes_No_Patologicos.FindAsync(id);
            _context.Antecedentes_No_Patologicos.Remove(antecedentes_No_Patologicos);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool Antecedentes_No_PatologicosExists(int id)
        {
            return _context.Antecedentes_No_Patologicos.Any(e => e.Id == id);
        }
    }
}
