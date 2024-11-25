using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Biblioteca.Models.dbModels;
using Microsoft.AspNetCore.Authorization;

namespace Biblioteca.Controllers
{
    [Authorize]
    public class LibroLectoresController : Controller
    {
        private readonly BibliotecaContext _context;

        public LibroLectoresController(BibliotecaContext context)
        {
            _context = context;
        }

        // GET: LibroLectores
        public async Task<IActionResult> Index()
        {
            var bibliotecaContext = _context.Libros.Include(l => l.Autor).Include(l => l.Genero);
            return View(await bibliotecaContext.ToListAsync());
        }

        // GET: LibroLectores/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var libro = await _context.Libros
                .Include(l => l.Autor)
                .Include(l => l.Genero)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (libro == null)
            {
                return NotFound();
            }

            return View(libro);
        }
    }
}
