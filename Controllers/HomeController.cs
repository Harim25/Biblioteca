using Biblioteca.Models;
using Biblioteca.Models.dbModels;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Diagnostics;

namespace Biblioteca.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly BibliotecaContext _context;

        public HomeController(ILogger<HomeController> logger, BibliotecaContext context)
        {
            _logger = logger;
            _context = context;
        }

        public async Task<IActionResult> Index()
        {
            var bibliotecaContext = _context.Libros.Include(l => l.Autor).Include(l => l.Genero);
            return View(await bibliotecaContext.ToListAsync());
        }

        public ActionResult AccesoDenegado()
        {
            return View();
        }
        public ActionResult ResultadoBusqueda()
        {
            return View();
        }
        public ActionResult VistaLibro()
        {
            return View();
        }
        public ActionResult Privacy()
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
