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
    public class Unidad_MedidaController : Controller
    {
        private readonly DataContext _context;

        public Unidad_MedidaController(DataContext context)
        {
            _context = context;
        }

        // GET: Unidad_Medida
        public async Task<IActionResult> Index()
        {
            return View(await _context.unidad_Medidas.ToListAsync());
        }

        // GET: Unidad_Medida/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var unidad_Medida = await _context.unidad_Medidas
                .FirstOrDefaultAsync(m => m.Id == id);
            if (unidad_Medida == null)
            {
                return NotFound();
            }

            return View(unidad_Medida);
        }

        // GET: Unidad_Medida/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Unidad_Medida/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Unidad_Medidas,Unidades_Medida")] Unidad_Medida unidad_Medida)
        {
            if (ModelState.IsValid)
            {
                _context.Add(unidad_Medida);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(unidad_Medida);
        }

        // GET: Unidad_Medida/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var unidad_Medida = await _context.unidad_Medidas.FindAsync(id);
            if (unidad_Medida == null)
            {
                return NotFound();
            }
            return View(unidad_Medida);
        }

        // POST: Unidad_Medida/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Unidad_Medidas,Unidades_Medida")] Unidad_Medida unidad_Medida)
        {
            if (id != unidad_Medida.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(unidad_Medida);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!Unidad_MedidaExists(unidad_Medida.Id))
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
            return View(unidad_Medida);
        }

        // GET: Unidad_Medida/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var unidad_Medida = await _context.unidad_Medidas
                .FirstOrDefaultAsync(m => m.Id == id);
            if (unidad_Medida == null)
            {
                return NotFound();
            }

            return View(unidad_Medida);
        }

        // POST: Unidad_Medida/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var unidad_Medida = await _context.unidad_Medidas.FindAsync(id);
            _context.unidad_Medidas.Remove(unidad_Medida);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool Unidad_MedidaExists(int id)
        {
            return _context.unidad_Medidas.Any(e => e.Id == id);
        }
    }
}
