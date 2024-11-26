using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Biblioteca.Models.dbModels;
using Microsoft.AspNetCore.Authorization;
using Biblioteca.Models.DTO;
using Biblioteca.Models.ViewModels;
using System.Security.Claims;

namespace Biblioteca.Controllers
{
    [Authorize]
    public class AutorFavoritoesController : Controller
    {
        private readonly BibliotecaContext _context;

        public AutorFavoritoesController(BibliotecaContext context)
        {
            _context = context;
        }

        // GET: AutorFavoritoes
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
            var bibliotecaContext = _context.AutorFavoritos
                .Include(a => a.Autor)
                .Include(a => a.Usuario)
                .Where(a => a.UsuarioId == userId);

            var autorFavorito = await bibliotecaContext.ToListAsync();

            // Si no hay favoritos, define un mensaje
            if (!autorFavorito.Any())
            {
                ViewBag.Mensaje = "De momento no tienes autores favoritos";
            }

            return View(autorFavorito);
        }

        // GET: AutorFavoritoes/Details/5
        public async Task<IActionResult> Details(int? autorId, int? usuarioId)
        {
            if (autorId == null || usuarioId == null)
            {
                return NotFound();
            }

            var autorFavorito = await _context.AutorFavoritos
                .Include(a => a.Autor)
                .Include(a => a.Usuario)
                .FirstOrDefaultAsync(m => m.AutorId == autorId && m.UsuarioId == usuarioId);
            if (autorFavorito == null)
            {
                return NotFound();
            }

            return View(autorFavorito);
        }

        // GET: AutorFavoritoes/Create
        public IActionResult Create()
        {
            AutorFavoritoViewModel model = new AutorFavoritoViewModel
            {
                AutorFavoritoCreate = new AutorFavoritoCreateDTO(),
                SelectListsAutores = new SelectList(_context.Autors, "Id", "Nombre"),
            };
            return View(model);
        }

        // POST: AutorFavoritoes/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(AutorFavoritoCreateDTO autorFavoritoCreate)
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
                AutorFavorito autorFavorito = new AutorFavorito
                {
                    AutorId = autorFavoritoCreate.AutorId,
                    Fecha = DateTime.Now,
                    UsuarioId = userId // Asigna el ID del usuario logueado
                };

                // Guardar en la base de datos
                _context.AutorFavoritos.Add(autorFavorito);
                await _context.SaveChangesAsync();

                return RedirectToAction(nameof(Index));
            }

            // En caso de error, retornar la vista con los datos iniciales
            AutorFavoritoViewModel model = new()
            {
                AutorFavoritoCreate = autorFavoritoCreate,
                SelectListsAutores = new SelectList(_context.Autors, "Id", "Nombre"),
            };
            return View(model);
        }

        // GET: AutorFavoritoes/Delete/5
        public async Task<IActionResult> Delete(int? autorId, int? usuarioId)
        {
            if (autorId == null || usuarioId == null)
            {
                return NotFound();
            }

            var autorFavorito = await _context.AutorFavoritos
                .Include(a => a.Autor)
                .Include(a => a.Usuario)
                .FirstOrDefaultAsync(m => m.AutorId == autorId && m.UsuarioId == usuarioId);
            if (autorFavorito == null)
            {
                return NotFound();
            }

            return View(autorFavorito);
        }

        // POST: AutorFavoritoes/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int autorId, int usuarioId)
        {
            var autorFavorito = await _context.AutorFavoritos
             .FirstOrDefaultAsync(lf => lf.AutorId == autorId && lf.UsuarioId == usuarioId);
            if (autorFavorito != null)
            {
                _context.AutorFavoritos.Remove(autorFavorito);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool AutorFavoritoExists(int autorId, int usuarioId)
        {
            return _context.AutorFavoritos.Any(e => e.AutorId == autorId && e.UsuarioId == usuarioId);
        }
    }
}
