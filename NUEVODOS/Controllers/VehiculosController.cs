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
    public class VehiculosController : Controller
    {
        private readonly NETJACKET2Context _context;

        public VehiculosController(NETJACKET2Context context)
        {
            _context = context;
        }

        // GET: Vehiculos
        public async Task<IActionResult> Index(string Buscar)
        {
            if (!User.Identity.IsAuthenticated)
            {
                return Redirect("/");
            }
            else
            {
                var vehiculos = from vehiculo in _context.Vehiculos select vehiculo;

                if (!String.IsNullOrEmpty(Buscar))
                {
                    vehiculos = vehiculos.Where(d => d.Placa!.Contains(Buscar));
                }
                return View(await vehiculos.ToListAsync());
            }
        }

        // GET: Vehiculos/Details/5
        public async Task<IActionResult> Details(string id)
        {
            if (id == null || _context.Vehiculos == null)
            {
                return NotFound();
            }

            var vehiculo = await _context.Vehiculos
                .FirstOrDefaultAsync(m => m.Placa == id);
            if (vehiculo == null)
            {
                return NotFound();
            }

            return View(vehiculo);
        }

        // GET: Vehiculos/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Vehiculos/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Placa,Vehiculo1,Marca,Modelo,Capacidad,Tipo,Color,Servicio,Linea,Motor,Chasis,Serie,Empresa,Matricula,Kilometraje,Cilindraje,Combustible,Traccion,Soat,Tecnomecanica,Correadentada")] Vehiculo vehiculo)
        {
            if (ModelState.IsValid)
            {
                _context.Add(vehiculo);
                TempData["Mensaje"] = "Vehiculo Registrado correctamente";
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(vehiculo);
        }

        // GET: Vehiculos/Edit/5
        public async Task<IActionResult> Edit(string id)
        {
            if (id == null || _context.Vehiculos == null)
            {
                return NotFound();
            }

            var vehiculo = await _context.Vehiculos.FindAsync(id);
            if (vehiculo == null)
            {
                return NotFound();
            }
            return View(vehiculo);
        }

        // POST: Vehiculos/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(string id, [Bind("Placa,Vehiculo1,Marca,Modelo,Capacidad,Tipo,Color,Servicio,Linea,Motor,Chasis,Serie,Empresa,Matricula,Kilometraje,Cilindraje,Combustible,Traccion,Soat,Tecnomecanica,Correadentada")] Vehiculo vehiculo)
        {
            if (id != vehiculo.Placa)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(vehiculo);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!VehiculoExists(vehiculo.Placa))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                TempData["Mensaje"] = "Vehiculo Actualizar correctamente";
                return RedirectToAction(nameof(Index));
            }
            return View(vehiculo);
        }

        // GET: Vehiculos/Delete/5
        public async Task<IActionResult> Delete(string id)
        {
            if (id == null || _context.Vehiculos == null)
            {
                return NotFound();
            }

            var vehiculo = await _context.Vehiculos
                .FirstOrDefaultAsync(m => m.Placa == id);
            if (vehiculo == null)
            {
                return NotFound();
            }

            return View(vehiculo);
        }

        // POST: Vehiculos/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(string id)
        {
            if (_context.Vehiculos == null)
            {
                return Problem("Entity set 'NETJACKET2Context.Vehiculos'  is null.");
            }
            var vehiculo = await _context.Vehiculos.FindAsync(id);
            if (vehiculo != null)
            {
                _context.Vehiculos.Remove(vehiculo);
            }
            TempData["Mensaje"] = "Vehiculo Eliminado correctamente";
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool VehiculoExists(string id)
        {
          return (_context.Vehiculos?.Any(e => e.Placa == id)).GetValueOrDefault();
        }
    }
}
