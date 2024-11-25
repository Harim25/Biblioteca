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
    public class AutorLectoresController : Controller
    {
        private readonly BibliotecaContext _context;

        public AutorLectoresController(BibliotecaContext context)
        {
            _context = context;
        }

        // GET: AutorLectores
        public async Task<IActionResult> Index()
        {
            return View(await _context.Autors.ToListAsync());
        }

        // GET: AutorLectores/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var autor = await _context.Autors
                .FirstOrDefaultAsync(m => m.Id == id);
            if (autor == null)
            {
                return NotFound();
            }

            return View(autor);
        }

    }
}
