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
    public class PuertasController : Controller
    {
        private readonly VuelosContext _context;

        public PuertasController(VuelosContext context)
        {
            _context = context;
        }

        // GET: Puertas
        public async Task<IActionResult> Index()
        {
            return View(await _context.Puertas.ToListAsync());
        }

        // GET: Puertas/Details/5
        public async Task<IActionResult> Details(string id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var puerta = await _context.Puertas
                .FirstOrDefaultAsync(m => m.Puerta_id == id);
            if (puerta == null)
            {
                return NotFound();
            }

            return View(puerta);
        }

        // GET: Puertas/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Puertas/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Puerta_id,Detalle,Estado_puerta")] Puerta puerta)
        {
            if (ModelState.IsValid)
            {
                _context.Add(puerta);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(puerta);
        }

        // GET: Puertas/Edit/5
        public async Task<IActionResult> Edit(string id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var puerta = await _context.Puertas.FindAsync(id);
            if (puerta == null)
            {
                return NotFound();
            }
            return View(puerta);
        }

        // POST: Puertas/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(string id, [Bind("Puerta_id,Detalle,Estado_puerta")] Puerta puerta)
        {
            if (id != puerta.Puerta_id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(puerta);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!PuertaExists(puerta.Puerta_id))
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
            return View(puerta);
        }

        // GET: Puertas/Delete/5
        public async Task<IActionResult> Delete(string id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var puerta = await _context.Puertas
                .FirstOrDefaultAsync(m => m.Puerta_id == id);
            if (puerta == null)
            {
                return NotFound();
            }

            return View(puerta);
        }

        // POST: Puertas/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(string id)
        {
            var puerta = await _context.Puertas.FindAsync(id);
            _context.Puertas.Remove(puerta);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool PuertaExists(string id)
        {
            return _context.Puertas.Any(e => e.Puerta_id == id);
        }
    }
}
