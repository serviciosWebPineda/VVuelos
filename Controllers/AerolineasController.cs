using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using V_Vuelo.Data;
using V_Vuelo.Models;

namespace Controllers
{
    public class AerolineasController : Controller
    {
        private readonly VuelosContext _context;

        public AerolineasController(VuelosContext context)
        {
            _context = context;
        }

        // GET: Aerolineas
        public async Task<IActionResult> Index()
        {
            return View(await _context.Aerolineas.ToListAsync());
        }

        // GET: Aerolineas/Details/5
        public async Task<IActionResult> Details(string id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var aerolinea = await _context.Aerolineas
                .FirstOrDefaultAsync(m => m.Aerolinea_id == id);
            if (aerolinea == null)
            {
                return NotFound();
            }

            return View(aerolinea);
        }

        // GET: Aerolineas/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Aerolineas/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Aerolinea_id,Nombre_aerolinea")] Aerolinea aerolinea)
        {
            if (ModelState.IsValid)
            {
                _context.Add(aerolinea);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(aerolinea);
        }

        // GET: Aerolineas/Edit/5
        public async Task<IActionResult> Edit(string id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var aerolinea = await _context.Aerolineas.FindAsync(id);
            if (aerolinea == null)
            {
                return NotFound();
            }
            return View(aerolinea);
        }

        // POST: Aerolineas/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(string id, [Bind("Aerolinea_id,Nombre_aerolinea")] Aerolinea aerolinea)
        {
            if (id != aerolinea.Aerolinea_id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(aerolinea);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!AerolineaExists(aerolinea.Aerolinea_id))
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
            return View(aerolinea);
        }

        // GET: Aerolineas/Delete/5
        public async Task<IActionResult> Delete(string id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var aerolinea = await _context.Aerolineas
                .FirstOrDefaultAsync(m => m.Aerolinea_id == id);
            if (aerolinea == null)
            {
                return NotFound();
            }

            return View(aerolinea);
        }

        // POST: Aerolineas/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(string id)
        {
            var aerolinea = await _context.Aerolineas.FindAsync(id);
            _context.Aerolineas.Remove(aerolinea);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool AerolineaExists(string id)
        {
            return _context.Aerolineas.Any(e => e.Aerolinea_id == id);
        }
    }
}
