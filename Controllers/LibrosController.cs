using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Biblioteca.Models.dbModels;
using Biblioteca.Models;
using Microsoft.AspNetCore.Authorization;
using Biblioteca.Models.DTO;
using Biblioteca.Models.ViewModels;

namespace Biblioteca.Controllers
{
    [Authorize(Roles = "Admin")]
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
            LibroViewModel model = new LibroViewModel
            {
                LibroCreate = new LibroCreateDTO(),
                SelectListsAutores = new SelectList(_context.Autors, "Id", "Nombre"),
                SelectListsGeneros = new SelectList(_context.GeneroLibros, "Id", "Nombre")
            };
            return View(model);
        }

        // POST: Libros/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(LibroCreateDTO libroCreate)
        {
            if (ModelState.IsValid)
            {
                Libro libro = new Libro
                {
                    Titulo = libroCreate.Titulo,
                    AutorId = libroCreate.AutorId,
                    GeneroId = libroCreate.GeneroId,
                    Editorial = libroCreate.Editorial,
                    Sinopsis = libroCreate.Sinopsis,
                    Cantidad = libroCreate.Cantidad,
                    FechaCreacion = libroCreate.FechaCreacion,
                    Imagen = libroCreate.Imagen,
                };
                _context.Libros.Add(libro);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            LibroViewModel model = new()
            {
                LibroCreate = libroCreate,
                SelectListsAutores = new SelectList(_context.Autors, "Id", "Nombre"),
                SelectListsGeneros = new SelectList(_context.GeneroLibros, "Id", "Nombre")
            };
            ViewData["AutorId"] = new SelectList(_context.Autors, "Id", "Id", libroCreate.AutorId);
            ViewData["GeneroId"] = new SelectList(_context.GeneroLibros, "Id", "Id", libroCreate.GeneroId);
            return View(model);
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
            LibroViewModel model = new LibroViewModel
            {
                LibroUpdate = new LibroUpdateDTO
                {
                    Id = libro.Id,
                    Titulo = libro.Titulo,
                    AutorId = libro.AutorId,
                    GeneroId = libro.GeneroId,
                    Editorial = libro.Editorial,
                    Sinopsis = libro.Sinopsis,
                    Cantidad = libro.Cantidad,
                    FechaCreacion = libro.FechaCreacion,
                    Imagen = libro.Imagen,
                },
                SelectListsAutores = new SelectList(_context.Autors, "Id", "Nombre", libro.AutorId),
                SelectListsGeneros = new SelectList(_context.GeneroLibros, "Id", "Nombre", libro.GeneroId)
            };
            return View(model);
        }

        // POST: Libros/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, LibroUpdateDTO libroUpdate)
        {
            if (id != libroUpdate.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    var libro = await _context.Libros.FindAsync(id);
                    if (libro == null)
                    {
                        return NotFound();
                    }

                    // Actualiza las propiedades necesarias
                    libro.Titulo = libroUpdate.Titulo;
                    libro.AutorId = libroUpdate.AutorId;
                    libro.GeneroId = libroUpdate.GeneroId;
                    libro.Editorial = libroUpdate.Editorial;
                    libro.Sinopsis = libroUpdate.Sinopsis;
                    libro.Cantidad = libroUpdate.Cantidad;
                    libro.FechaCreacion = libroUpdate.FechaCreacion;
                    libro.Imagen = libroUpdate.Imagen;

                    _context.Update(libro);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!LibroExists(libroUpdate.Id))
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
            LibroViewModel model = new LibroViewModel
            {
                LibroUpdate = libroUpdate,
                SelectListsAutores = new SelectList(_context.Autors, "Id", "Nombre", libroUpdate.AutorId),
                SelectListsGeneros = new SelectList(_context.GeneroLibros, "Id", "Nombre", libroUpdate.GeneroId)
            };
            return View(libroUpdate);
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
