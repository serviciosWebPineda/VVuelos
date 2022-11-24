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
    public class ConsecutivosController : Controller
    {
        private readonly VuelosContext _context;

        public ConsecutivosController(VuelosContext context)
        {
            _context = context;
        }

        // GET: Consecutivos
        public async Task<IActionResult> Index()
        {
            return View(await _context.Consecutivos.ToListAsync());
        }

        // GET: Consecutivos/Details/5
        public async Task<IActionResult> Details(string id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var consecutivos = await _context.Consecutivos
                .FirstOrDefaultAsync(m => m.Consecutivo_Id == id);
            if (consecutivos == null)
            {
                return NotFound();
            }

            return View(consecutivos);
        }

        // GET: Consecutivos/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Consecutivos/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Consecutivo_Id,Consecutivo,Descripcion,Disponibilidad_prefijo,Prefijo,Rango,Rango_inicial,Rango_final")] Consecutivos consecutivos)
        {
            if (ModelState.IsValid)
            {
                _context.Add(consecutivos);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(consecutivos);
        }

        // GET: Consecutivos/Edit/5
        public async Task<IActionResult> Edit(string id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var consecutivos = await _context.Consecutivos.FindAsync(id);
            if (consecutivos == null)
            {
                return NotFound();
            }
            return View(consecutivos);
        }

        // POST: Consecutivos/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(string id, [Bind("Consecutivo_Id,Consecutivo,Descripcion,Disponibilidad_prefijo,Prefijo,Rango,Rango_inicial,Rango_final")] Consecutivos consecutivos)
        {
            if (id != consecutivos.Consecutivo_Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(consecutivos);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ConsecutivosExists(consecutivos.Consecutivo_Id))
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
            return View(consecutivos);
        }

        // GET: Consecutivos/Delete/5
        public async Task<IActionResult> Delete(string id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var consecutivos = await _context.Consecutivos
                .FirstOrDefaultAsync(m => m.Consecutivo_Id == id);
            if (consecutivos == null)
            {
                return NotFound();
            }

            return View(consecutivos);
        }

        // POST: Consecutivos/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(string id)
        {
            var consecutivos = await _context.Consecutivos.FindAsync(id);
            _context.Consecutivos.Remove(consecutivos);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool ConsecutivosExists(string id)
        {
            return _context.Consecutivos.Any(e => e.Consecutivo_Id == id);
        }
    }
}
