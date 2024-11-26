using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Biblioteca.Models.dbModels;
using System.Security.Claims;
using Biblioteca.Models.DTO;
using Biblioteca.Models.ViewModels;

namespace Biblioteca.Controllers
{
    public class LibroFavoritoesController : Controller
    {
        private readonly BibliotecaContext _context;

        public LibroFavoritoesController(BibliotecaContext context)
        {
            _context = context;
        }

        // GET: LibroFavoritoes
        public async Task<IActionResult> Index()
        {
            // Obtén el ID del usuario logueado como string
            var userIdString = User.FindFirstValue(ClaimTypes.NameIdentifier);

            // Convierte el ID del usuario a entero
            if (!int.TryParse(userIdString, out int userId))
            {
                // Manejo de error si la conversión falla (opcional)
                return Unauthorized();
            }

            // Filtra los préstamos por el usuario logueado
            var bibliotecaContext = _context.LibroFavoritos
                .Include(l => l.Libro)
                .Include(l => l.Usuario)
                .Where(l => l.UsuarioId == userId);

            var libroFavorito = await bibliotecaContext.ToListAsync();

            // Si no hay favoritos, define un mensaje
            if (!libroFavorito.Any())
            {
                ViewBag.Mensaje = "De momento no tienes libros favoritos";
            }

            return View(libroFavorito);
        }

        // GET: LibroFavoritoes/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var libroFavorito = await _context.LibroFavoritos
                .Include(l => l.Libro)
                .Include(l => l.Usuario)
                .FirstOrDefaultAsync(m => m.UsuarioId == id);
            if (libroFavorito == null)
            {
                return NotFound();
            }

            return View(libroFavorito);
        }

        // GET: LibroFavoritoes/Create
        public IActionResult Create()
        {
            LibroFavoritoViewModel model = new LibroFavoritoViewModel
            {
                LibroFavoritoCreate = new LibroFavoritoCreateDTO(),
                SelectListsLibros = new SelectList(_context.Libros, "Id", "Titulo"),
            };
            return View(model);
        }

        // POST: LibroFavoritoes/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(LibroFavoritoCreateDTO libroFavoritoCreate)
        {
            if (ModelState.IsValid)
            {
                // Obtener el ID del usuario logueado
                var userIdString = User.FindFirstValue(ClaimTypes.NameIdentifier);

                // Verificar y convertir el ID a entero
                if (!int.TryParse(userIdString, out int userId))
                {
                    // Manejo de error si el ID no es válido
                    return Unauthorized();
                }

                // Crear el objeto AutorFavorito con el usuario actual
                LibroFavorito libroFavorito = new LibroFavorito
                {
                    LibroId = libroFavoritoCreate.LibroId,
                    Fecha = DateTime.Now,
                    UsuarioId = userId // Asigna el ID del usuario logueado
                };

                // Guardar en la base de datos
                _context.LibroFavoritos.Add(libroFavorito);
                await _context.SaveChangesAsync();

                return RedirectToAction(nameof(Index));
            }
            // En caso de error, retornar la vista con los datos iniciales
            LibroFavoritoViewModel model = new()
            {
                LibroFavoritoCreate = libroFavoritoCreate,
                SelectListsLibros = new SelectList(_context.Libros, "Id", "Titulo"),
            };
            return View(model);
        }

        
        // GET: LibroFavoritoes/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var libroFavorito = await _context.LibroFavoritos
                .Include(l => l.Libro)
                .Include(l => l.Usuario)
                .FirstOrDefaultAsync(m => m.UsuarioId == id);
            if (libroFavorito == null)
            {
                return NotFound();
            }

            return View(libroFavorito);
        }

        // POST: LibroFavoritoes/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var libroFavorito = await _context.LibroFavoritos.FindAsync(id);
            if (libroFavorito != null)
            {
                _context.LibroFavoritos.Remove(libroFavorito);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool LibroFavoritoExists(int id)
        {
            return _context.LibroFavoritos.Any(e => e.UsuarioId == id);
        }
    }
}
