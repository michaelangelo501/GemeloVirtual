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
    public class Admision_HospitalController : Controller
    {
        private readonly DataContext _context;

        public Admision_HospitalController(DataContext context)
        {
            _context = context;
        }

        // GET: Admision_Hospital
        public async Task<IActionResult> Index()
        {
            return View(await _context.Admisiones_Hospital.ToListAsync());
        }

        // GET: Admision_Hospital/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var admision_Hospital = await _context.Admisiones_Hospital
                .FirstOrDefaultAsync(m => m.Id == id);
            if (admision_Hospital == null)
            {
                return NotFound();
            }

            return View(admision_Hospital);
        }

        // GET: Admision_Hospital/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Admision_Hospital/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Fecha,Id_Hospital,Id_Paciente")] Admision_Hospital admision_Hospital)
        {
            if (ModelState.IsValid)
            {
                _context.Add(admision_Hospital);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(admision_Hospital);
        }

        // GET: Admision_Hospital/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var admision_Hospital = await _context.Admisiones_Hospital.FindAsync(id);
            if (admision_Hospital == null)
            {
                return NotFound();
            }
            return View(admision_Hospital);
        }

        // POST: Admision_Hospital/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Fecha,Id_Hospital,Id_Paciente")] Admision_Hospital admision_Hospital)
        {
            if (id != admision_Hospital.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(admision_Hospital);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!Admision_HospitalExists(admision_Hospital.Id))
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
            return View(admision_Hospital);
        }

        // GET: Admision_Hospital/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var admision_Hospital = await _context.Admisiones_Hospital
                .FirstOrDefaultAsync(m => m.Id == id);
            if (admision_Hospital == null)
            {
                return NotFound();
            }

            return View(admision_Hospital);
        }

        // POST: Admision_Hospital/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var admision_Hospital = await _context.Admisiones_Hospital.FindAsync(id);
            _context.Admisiones_Hospital.Remove(admision_Hospital);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool Admision_HospitalExists(int id)
        {
            return _context.Admisiones_Hospital.Any(e => e.Id == id);
        }
    }
}
