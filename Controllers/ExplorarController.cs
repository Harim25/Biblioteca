using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Biblioteca.Models.dbModels;

namespace Biblioteca.Controllers
{
    public class ExplorarController : Controller
    {
        private readonly BibliotecaContext _context;

        public ExplorarController(BibliotecaContext context)
        {
            _context = context;
        }

        // GET: Inicio
        public async Task<IActionResult> Index()
        {
            var bibliotecaContext = _context.Libros.Include(l => l.Autor).Include(l => l.Genero);
            return View(await bibliotecaContext.ToListAsync());
        }
    }
}
