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
    public class Reportes_MedicosController : Controller
    {
        private readonly DataContext _context;

        public Reportes_MedicosController(DataContext context)
        {
            _context = context;
        }

        // GET: Reportes_Medicos
        public async Task<IActionResult> Index()
        {
            return View(await _context.Reportes_Medicos.ToListAsync());
        }

        // GET: Reportes_Medicos/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var reportes_Medicos = await _context.Reportes_Medicos
                .FirstOrDefaultAsync(m => m.Id == id);
            if (reportes_Medicos == null)
            {
                return NotFound();
            }

            return View(reportes_Medicos);
        }

        // GET: Reportes_Medicos/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Reportes_Medicos/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Id_Paciente,Fecha")] Reportes_Medicos reportes_Medicos)
        {
            if (ModelState.IsValid)
            {
                _context.Add(reportes_Medicos);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(reportes_Medicos);
        }

        // GET: Reportes_Medicos/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var reportes_Medicos = await _context.Reportes_Medicos.FindAsync(id);
            if (reportes_Medicos == null)
            {
                return NotFound();
            }
            return View(reportes_Medicos);
        }

        // POST: Reportes_Medicos/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Id_Paciente,Fecha")] Reportes_Medicos reportes_Medicos)
        {
            if (id != reportes_Medicos.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(reportes_Medicos);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!Reportes_MedicosExists(reportes_Medicos.Id))
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
            return View(reportes_Medicos);
        }

        // GET: Reportes_Medicos/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var reportes_Medicos = await _context.Reportes_Medicos
                .FirstOrDefaultAsync(m => m.Id == id);
            if (reportes_Medicos == null)
            {
                return NotFound();
            }

            return View(reportes_Medicos);
        }

        // POST: Reportes_Medicos/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var reportes_Medicos = await _context.Reportes_Medicos.FindAsync(id);
            _context.Reportes_Medicos.Remove(reportes_Medicos);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool Reportes_MedicosExists(int id)
        {
            return _context.Reportes_Medicos.Any(e => e.Id == id);
        }
    }
}
