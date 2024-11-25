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
    public class GeneroLibroLectoresController : Controller
    {
        private readonly BibliotecaContext _context;

        public GeneroLibroLectoresController(BibliotecaContext context)
        {
            _context = context;
        }

        // GET: GeneroLibroLectores
        public async Task<IActionResult> Index()
        {
            return View(await _context.GeneroLibros.ToListAsync());
        }

        // GET: GeneroLibroLectores/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var generoLibro = await _context.GeneroLibros
                .FirstOrDefaultAsync(m => m.Id == id);
            if (generoLibro == null)
            {
                return NotFound();
            }

            return View(generoLibro);
        }
    }
}
