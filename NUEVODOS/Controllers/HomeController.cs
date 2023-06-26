using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using NUEVODOS.Models;
using NUEVODOS.Models.ViewModels;
using System.Diagnostics;

namespace NUEVODOS.Controllers
{
    public class HomeController : Controller
    {
        private readonly NETJACKET2Context _dbcontext;

        public HomeController(NETJACKET2Context context)
        {
            _dbcontext = context;
        }

        public IActionResult resumenVenta()
        {
            DateTime FechaInicio = DateTime.Now;
            FechaInicio = FechaInicio.AddDays(-5);
            var Lista = (from data in _dbcontext.Ventas.ToList()
                         group data by data.Fechaventa into gr
                         select new VMVenta
                         {
                             fecha = gr.Key?.ToString("dd/MM/yyyy"), // Convertir la fecha a string
                             cantidad = gr.Count(),

                         });

            return Ok(Lista);

        }

        public IActionResult Index()
        {
            if (!User.Identity.IsAuthenticated)
            {
                return Redirect("/Identity/Account/Login");
            }
            else
            {
                return View();
            }
        }


        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}