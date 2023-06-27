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

        public IActionResult ResumenVenta()
        {
            DateTime fechainicio = DateTime.Now;
            fechainicio = fechainicio.AddDays(-30);
            List<VMVenta> Lista = (from tbventa in _dbcontext.Ventas
                                   where tbventa.Fechaventa.Value.Date >= fechainicio.Date
                                   group tbventa by tbventa.Fechaventa.Value.Date into grupo
                                   select new VMVenta
                                   {
                                       fecha = grupo.Key.ToString("dd/MM/yyyy"),
                                       cantidad = grupo.Count(),
                                   }).ToList();

            return StatusCode(StatusCodes.Status200OK, Lista);
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