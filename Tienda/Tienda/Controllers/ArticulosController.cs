using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Tienda.Models.Context;
using Tienda.Models.Entidades;

namespace Tienda.Controllers
{
    public class ArticulosController : Controller
    {
        private readonly ArticuloContext _context;

        public ArticulosController(ArticuloContext context)
        {
            _context = context;
        }

        // GET: Articulos
        public async Task<IActionResult> Index()
        {
              return _context.Articulos != null ? 
                          View(await _context.Articulos.ToListAsync()) :
                          Problem("Entity set 'ArticuloContext.Articulos'  is null.");
        }

        // GET: Articulos/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.Articulos == null)
            {
                return NotFound();
            }

            var articulos = await _context.Articulos
                .FirstOrDefaultAsync(m => m.Id == id);
            if (articulos == null)
            {
                return NotFound();
            }

            return View(articulos);
        }

        // GET: Articulos/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Articulos/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Codigo,Nombre,Descripcion,Existencia")] Articulos articulos)
        {
            if (ModelState.IsValid)
            {
                _context.Add(articulos);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(articulos);
        }

        // GET: Articulos/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.Articulos == null)
            {
                return NotFound();
            }

            var articulos = await _context.Articulos.FindAsync(id);
            if (articulos == null)
            {
                return NotFound();
            }
            return View(articulos);
        }

        // POST: Articulos/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Codigo,Nombre,Descripcion,Existencia")] Articulos articulos)
        {
            if (id != articulos.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(articulos);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ArticulosExists(articulos.Id))
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
            return View(articulos);
        }

        // GET: Articulos/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.Articulos == null)
            {
                return NotFound();
            }

            var articulos = await _context.Articulos
                .FirstOrDefaultAsync(m => m.Id == id);
            if (articulos == null)
            {
                return NotFound();
            }

            return View(articulos);
        }

        // POST: Articulos/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.Articulos == null)
            {
                return Problem("Entity set 'ArticuloContext.Articulos'  is null.");
            }
            var articulos = await _context.Articulos.FindAsync(id);
            if (articulos != null)
            {
                _context.Articulos.Remove(articulos);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool ArticulosExists(int id)
        {
          return (_context.Articulos?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}
