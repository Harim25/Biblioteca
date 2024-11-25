using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Biblioteca.Models.dbModels;
using Biblioteca.Models;

namespace Biblioteca.Controllers
{
    public class LibrosController : Controller
    {
        private readonly BibliotecaContext _context;

        public LibrosController(BibliotecaContext context)
        {
            _context = context;
        }

        // GET: Libros
        public async Task<IActionResult> Index()
        {
            var bibliotecaContext = _context.Libros.Include(l => l.Autor).Include(l => l.Genero);
            return View(await bibliotecaContext.ToListAsync());
        }

        // GET: Libros/Details/5
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

        // GET: Libros/Create
        public IActionResult Create()
        {
            ViewData["AutorId"] = new SelectList(_context.Autors, "Id", "Id");
            ViewData["AutorNombre"] = new SelectList(_context.Autors, "Id", "Nombre");
            ViewData["GeneroId"] = new SelectList(_context.GeneroLibros, "Id", "Id");
            ViewData["GeneroNombre"] = new SelectList(_context.GeneroLibros, "Id", "Nombre");
            return View();
        }

        // POST: Libros/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Titulo,AutorId,GeneroId,Editorial,Sinopsis,Cantidad,FechaCreacion,Imagen")] LibroHR libro)
        {
            if (ModelState.IsValid)
            {
                Libro libro1 = new Libro()
                {
                    Titulo = libro.Titulo,
                    AutorId = libro.AutorId,
                    GeneroId = libro.GeneroId,
                    Editorial = libro.Editorial,
                    Sinopsis = libro.Sinopsis,
                    Cantidad = libro.Cantidad,
                    FechaCreacion = libro.FechaCreacion,
                    Imagen = libro.Imagen,
                };
                _context.Libros.Add(libro1);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["AutorId"] = new SelectList(_context.Autors, "Id", "Id", libro.AutorId);
            ViewData["GeneroId"] = new SelectList(_context.GeneroLibros, "Id", "Id", libro.GeneroId);
            return View(libro);
        }

        // GET: Libros/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var libro = await _context.Libros.FindAsync(id);
            if (libro == null)
            {
                return NotFound();
            }
            ViewData["AutorId"] = new SelectList(_context.Autors, "Id", "Id", libro.AutorId);
            ViewData["GeneroId"] = new SelectList(_context.GeneroLibros, "Id", "Id", libro.GeneroId);
            return View(libro);
        }

        // POST: Libros/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Titulo,AutorId,GeneroId,Editorial,Sinopsis,Cantidad,FechaCreacion,Imagen")] LibroHR libro)
        {
            if (id != libro.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    Libro libro1 = new Libro()
                    {
                        Titulo = libro.Titulo,
                        AutorId = libro.AutorId,
                        GeneroId = libro.GeneroId,
                        Editorial = libro.Editorial,
                        Sinopsis = libro.Sinopsis,
                        Cantidad = libro.Cantidad,
                        FechaCreacion = libro.FechaCreacion,
                        Imagen = libro.Imagen,
                    };
                    _context.Update(libro1);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!LibroExists(libro.Id))
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
            ViewData["AutorId"] = new SelectList(_context.Autors, "Id", "Id", libro.AutorId);
            ViewData["GeneroId"] = new SelectList(_context.GeneroLibros, "Id", "Id", libro.GeneroId);
            return View(libro);
        }

        // GET: Libros/Delete/5
        public async Task<IActionResult> Delete(int? id)
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

        // POST: Libros/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var libro = await _context.Libros.FindAsync(id);
            if (libro != null)
            {
                _context.Libros.Remove(libro);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool LibroExists(int id)
        {
            return _context.Libros.Any(e => e.Id == id);
        }
    }
}
