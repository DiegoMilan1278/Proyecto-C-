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
    public class VentasController : Controller
    {
        private readonly NETJACKET2Context _context;

        public VentasController(NETJACKET2Context context)
        {
            _context = context;
        }

        // GET: Ventas
        public async Task<IActionResult> Index()
        {
            if (!User.Identity.IsAuthenticated)
            {
                return Redirect("/");
            }
            else
            {
                var nETJACKET2Context = _context.Ventas.Include(v => v.PlacaV);
                return View(await nETJACKET2Context.ToListAsync());
            }
        }

        // GET: Ventas/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.Ventas == null)
            {
                return NotFound();
            }

            var venta = await _context.Ventas
                .Include(v => v.PlacaV)
                .FirstOrDefaultAsync(m => m.Idventa == id);
            if (venta == null)
            {
                return NotFound();
            }

            return View(venta);
        }

        // GET: Ventas/Create
        public IActionResult Create()
        {
            ViewData["Placaventa"] = new SelectList(_context.Vehiculos, "Placa", "Placa");
            return View();
        }

        // POST: Ventas/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Idventa,Fechaventa,Precioventa,Mpventa,Limitacionesventa,Ciudadventa,Spventa,Placaventa")] Venta venta)
        {
            if (ModelState.IsValid)
            {
                _context.Add(venta);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["Placaventa"] = new SelectList(_context.Vehiculos, "Placa", "Placa", venta.Placaventa);
            return View(venta);
        }

        // GET: Ventas/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.Ventas == null)
            {
                return NotFound();
            }

            var venta = await _context.Ventas.FindAsync(id);
            if (venta == null)
            {
                return NotFound();
            }
            ViewData["Placaventa"] = new SelectList(_context.Vehiculos, "Placa", "Placa", venta.Placaventa);
            return View(venta);
        }

        // POST: Ventas/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Idventa,Fechaventa,Precioventa,Mpventa,Limitacionesventa,Ciudadventa,Spventa,Placaventa")] Venta venta)
        {
            if (id != venta.Idventa)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(venta);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!VentaExists(venta.Idventa))
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
            ViewData["Placaventa"] = new SelectList(_context.Vehiculos, "Placa", "Placa", venta.Placaventa);
            return View(venta);
        }

        // GET: Ventas/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.Ventas == null)
            {
                return NotFound();
            }

            var venta = await _context.Ventas
                .Include(v => v.PlacaV)
                .FirstOrDefaultAsync(m => m.Idventa == id);
            if (venta == null)
            {
                return NotFound();
            }

            return View(venta);
        }

        // POST: Ventas/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.Ventas == null)
            {
                return Problem("Entity set 'NETJACKET2Context.Ventas'  is null.");
            }
            var venta = await _context.Ventas.FindAsync(id);
            if (venta != null)
            {
                _context.Ventas.Remove(venta);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool VentaExists(int id)
        {
          return (_context.Ventas?.Any(e => e.Idventa == id)).GetValueOrDefault();
        }
    }
}
