using Biblioteca.Models;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace Biblioteca.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        public IActionResult Index()
        {
            return View();
        }
        public IActionResult AccesoDenegado()
        {
            return View();
        }
        public IActionResult ResultadoBusqueda()
        {
            return View();
        }
        public IActionResult VistaLibro()
        {
            return View();
        }
        public IActionResult Privacy()
        {
            return View();
        }
        public ActionResult Acerca()
        {
            return View();
        }
        public ActionResult Advertencia()
        {
            return View();
        }
        public ActionResult EncontrarLibro()
        {
            return View();
        }
        public ActionResult Folio()
        {
            return View();
        }
        public ActionResult FormularioLibro()
        {
            return View();
        }
        public ActionResult PedirLibro()
        {
            return View();
        }
        public ActionResult VistaAutor()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
