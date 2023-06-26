using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using NUEVODOS.Models;

namespace NUEVODOS.Controllers
{
    public class ComprasController : Controller
    {
        private readonly NETJACKET2Context _context;

        public ComprasController(NETJACKET2Context context)
        {
            _context = context;
        }

        // GET: Compras
        public async Task<IActionResult> Index()
        {
            if (!User.Identity.IsAuthenticated)
            {
                return Redirect("/");
            }
            else
            {
                var nETJACKET2Context = _context.Compras.Include(c => c.PlacaC);
                return View(await nETJACKET2Context.ToListAsync());
            }
        }

        // GET: Compras/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.Compras == null)
            {
                return NotFound();
            }

            var compra = await _context.Compras
                .Include(c => c.PlacaC)
                .FirstOrDefaultAsync(m => m.Idcompra == id);
            if (compra == null)
            {
                return NotFound();
            }

            return View(compra);
        }

        // GET: Compras/Create
        public IActionResult Create()
        {
            ViewData["Placacompra"] = new SelectList(_context.Vehiculos, "Placa", "Placa");
            return View();
        }

        // POST: Compras/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Idcompra,Fechacompra,Preciocompra,Mpcompra,Limitacionescompra,Ciudadcompra,Spcompra,Placacompra")] Compra compra)
        {
            if (ModelState.IsValid)
            {
                _context.Add(compra);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["Placacompra"] = new SelectList(_context.Vehiculos, "Placa", "Placa", compra.Placacompra);
            return View(compra);
        }

        // GET: Compras/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.Compras == null)
            {
                return NotFound();
            }

            var compra = await _context.Compras.FindAsync(id);
            if (compra == null)
            {
                return NotFound();
            }
            ViewData["Placacompra"] = new SelectList(_context.Vehiculos, "Placa", "Placa", compra.Placacompra);
            return View(compra);
        }

        // POST: Compras/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Idcompra,Fechacompra,Preciocompra,Mpcompra,Limitacionescompra,Ciudadcompra,Spcompra,Placacompra")] Compra compra)
        {
            if (id != compra.Idcompra)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(compra);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!CompraExists(compra.Idcompra))
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
            ViewData["Placacompra"] = new SelectList(_context.Vehiculos, "Placa", "Placa", compra.Placacompra);
            return View(compra);
        }

        // GET: Compras/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.Compras == null)
            {
                return NotFound();
            }

            var compra = await _context.Compras
                .Include(c => c.PlacaC)
                .FirstOrDefaultAsync(m => m.Idcompra == id);
            if (compra == null)
            {
                return NotFound();
            }

            return View(compra);
        }

        // POST: Compras/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.Compras == null)
            {
                return Problem("Entity set 'NETJACKET2Context.Compras'  is null.");
            }
            var compra = await _context.Compras.FindAsync(id);
            if (compra != null)
            {
                _context.Compras.Remove(compra);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool CompraExists(int id)
        {
          return (_context.Compras?.Any(e => e.Idcompra == id)).GetValueOrDefault();
        }
    }
}
