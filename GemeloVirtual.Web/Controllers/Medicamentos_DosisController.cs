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
    public class Medicamentos_DosisController : Controller
    {
        private readonly DataContext _context;

        public Medicamentos_DosisController(DataContext context)
        {
            _context = context;
        }

        // GET: Medicamentos_Dosis
        public async Task<IActionResult> Index()
        {
            return View(await _context.Medicamentos_Dosis.ToListAsync());
        }

        // GET: Medicamentos_Dosis/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var medicamentos_Dosis = await _context.Medicamentos_Dosis
                .FirstOrDefaultAsync(m => m.Id == id);
            if (medicamentos_Dosis == null)
            {
                return NotFound();
            }

            return View(medicamentos_Dosis);
        }

        // GET: Medicamentos_Dosis/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Medicamentos_Dosis/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Id_Dosis,Id_Unidad_Medida")] Medicamentos_Dosis medicamentos_Dosis)
        {
            if (ModelState.IsValid)
            {
                _context.Add(medicamentos_Dosis);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(medicamentos_Dosis);
        }

        // GET: Medicamentos_Dosis/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var medicamentos_Dosis = await _context.Medicamentos_Dosis.FindAsync(id);
            if (medicamentos_Dosis == null)
            {
                return NotFound();
            }
            return View(medicamentos_Dosis);
        }

        // POST: Medicamentos_Dosis/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Id_Dosis,Id_Unidad_Medida")] Medicamentos_Dosis medicamentos_Dosis)
        {
            if (id != medicamentos_Dosis.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(medicamentos_Dosis);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!Medicamentos_DosisExists(medicamentos_Dosis.Id))
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
            return View(medicamentos_Dosis);
        }

        // GET: Medicamentos_Dosis/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var medicamentos_Dosis = await _context.Medicamentos_Dosis
                .FirstOrDefaultAsync(m => m.Id == id);
            if (medicamentos_Dosis == null)
            {
                return NotFound();
            }

            return View(medicamentos_Dosis);
        }

        // POST: Medicamentos_Dosis/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var medicamentos_Dosis = await _context.Medicamentos_Dosis.FindAsync(id);
            _context.Medicamentos_Dosis.Remove(medicamentos_Dosis);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool Medicamentos_DosisExists(int id)
        {
            return _context.Medicamentos_Dosis.Any(e => e.Id == id);
        }
    }
}
