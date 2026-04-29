using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using WebBodyPiercing.Data;
using WebBodyPiercing.Models;

namespace WebBodyPiercing.Controllers
{
    public class PiezaController : Controller
    {
        private readonly PiercingDbContext _context;

        public PiezaController(PiercingDbContext context)
        {
            _context = context;
        }

        // GET: Pieza
        public async Task<IActionResult> Index()
        {
            var piercingDbContext = _context.Piezas.Include(p => p.Categoria);
            return View(await piercingDbContext.ToListAsync());
        }

        // GET: Pieza/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var pieza = await _context.Piezas
                .Include(p => p.Categoria)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (pieza == null)
            {
                return NotFound();
            }

            return View(pieza);
        }

        // GET: Pieza/Create
        public IActionResult Create()
        {
            ViewData["CategoriaId"] = new SelectList(_context.Categorias, "Id", "Nombre");
            return View();
        }

        // POST: Pieza/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Nombre,Descripcion,Precio,ImagenUrl,Disponible,CategoriaId")] Pieza pieza)
        {
            if (ModelState.IsValid)
            {
                _context.Add(pieza);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["CategoriaId"] = new SelectList(_context.Categorias, "Id", "Nombre", pieza.CategoriaId);
            return View(pieza);
        }

        // GET: Pieza/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var pieza = await _context.Piezas.FindAsync(id);
            if (pieza == null)
            {
                return NotFound();
            }
            ViewData["CategoriaId"] = new SelectList(_context.Categorias, "Id", "Nombre", pieza.CategoriaId);
            return View(pieza);
        }

        // POST: Pieza/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Nombre,Descripcion,Precio,ImagenUrl,Disponible,CategoriaId")] Pieza pieza)
        {
            if (id != pieza.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(pieza);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!PiezaExists(pieza.Id))
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
            ViewData["CategoriaId"] = new SelectList(_context.Categorias, "Id", "Nombre", pieza.CategoriaId);
            return View(pieza);
        }

        // GET: Pieza/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var pieza = await _context.Piezas
                .Include(p => p.Categoria)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (pieza == null)
            {
                return NotFound();
            }

            return View(pieza);
        }

        // POST: Pieza/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var pieza = await _context.Piezas.FindAsync(id);
            if (pieza != null)
            {
                _context.Piezas.Remove(pieza);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool PiezaExists(int id)
        {
            return _context.Piezas.Any(e => e.Id == id);
        }
    }
}
