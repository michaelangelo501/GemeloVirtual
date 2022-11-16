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
    public class SintomasController : Controller
    {
        private readonly DataContext _context;

        public SintomasController(DataContext context)
        {
            _context = context;
        }

        // GET: Sintomas
        public async Task<IActionResult> Index()
        {
            return View(await _context.Sintomas.ToListAsync());
        }

        // GET: Sintomas/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var sintomas = await _context.Sintomas
                .FirstOrDefaultAsync(m => m.Id == id);
            if (sintomas == null)
            {
                return NotFound();
            }

            return View(sintomas);
        }

        // GET: Sintomas/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Sintomas/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Descripcion")] Sintomas sintomas)
        {
            if (ModelState.IsValid)
            {
                _context.Add(sintomas);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(sintomas);
        }

        // GET: Sintomas/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var sintomas = await _context.Sintomas.FindAsync(id);
            if (sintomas == null)
            {
                return NotFound();
            }
            return View(sintomas);
        }

        // POST: Sintomas/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Descripcion")] Sintomas sintomas)
        {
            if (id != sintomas.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(sintomas);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!SintomasExists(sintomas.Id))
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
            return View(sintomas);
        }

        // GET: Sintomas/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var sintomas = await _context.Sintomas
                .FirstOrDefaultAsync(m => m.Id == id);
            if (sintomas == null)
            {
                return NotFound();
            }

            return View(sintomas);
        }

        // POST: Sintomas/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var sintomas = await _context.Sintomas.FindAsync(id);
            _context.Sintomas.Remove(sintomas);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool SintomasExists(int id)
        {
            return _context.Sintomas.Any(e => e.Id == id);
        }
    }
}
