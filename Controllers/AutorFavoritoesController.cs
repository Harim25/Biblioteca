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
            var bibliotecaContext = _context.AutorFavoritos.Include(a => a.Autor).Include(a => a.Usuario);
            return View(await bibliotecaContext.ToListAsync());
        }

        // GET: AutorFavoritoes/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var autorFavorito = await _context.AutorFavoritos
                .Include(a => a.Autor)
                .Include(a => a.Usuario)
                .FirstOrDefaultAsync(m => m.UsuarioId == id);
            if (autorFavorito == null)
            {
                return NotFound();
            }

            return View(autorFavorito);
        }

        // GET: AutorFavoritoes/Create
        public IActionResult Create()
        {
            ViewData["AutorId"] = new SelectList(_context.Autors, "Id", "Id");
            ViewData["UsuarioId"] = new SelectList(_context.Users, "Id", "Id");
            return View();
        }

        // POST: AutorFavoritoes/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("UsuarioId,AutorId,Fecha")] AutorFavorito autorFavorito)
        {
            if (ModelState.IsValid)
            {
                _context.Add(autorFavorito);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["AutorId"] = new SelectList(_context.Autors, "Id", "Id", autorFavorito.AutorId);
            ViewData["UsuarioId"] = new SelectList(_context.Users, "Id", "Id", autorFavorito.UsuarioId);
            return View(autorFavorito);
        }

        // GET: AutorFavoritoes/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var autorFavorito = await _context.AutorFavoritos.FindAsync(id);
            if (autorFavorito == null)
            {
                return NotFound();
            }
            ViewData["AutorId"] = new SelectList(_context.Autors, "Id", "Id", autorFavorito.AutorId);
            ViewData["UsuarioId"] = new SelectList(_context.Users, "Id", "Id", autorFavorito.UsuarioId);
            return View(autorFavorito);
        }

        // POST: AutorFavoritoes/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("UsuarioId,AutorId,Fecha")] AutorFavorito autorFavorito)
        {
            if (id != autorFavorito.UsuarioId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(autorFavorito);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!AutorFavoritoExists(autorFavorito.UsuarioId))
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
            ViewData["AutorId"] = new SelectList(_context.Autors, "Id", "Id", autorFavorito.AutorId);
            ViewData["UsuarioId"] = new SelectList(_context.Users, "Id", "Id", autorFavorito.UsuarioId);
            return View(autorFavorito);
        }

        // GET: AutorFavoritoes/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var autorFavorito = await _context.AutorFavoritos
                .Include(a => a.Autor)
                .Include(a => a.Usuario)
                .FirstOrDefaultAsync(m => m.UsuarioId == id);
            if (autorFavorito == null)
            {
                return NotFound();
            }

            return View(autorFavorito);
        }

        // POST: AutorFavoritoes/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var autorFavorito = await _context.AutorFavoritos.FindAsync(id);
            if (autorFavorito != null)
            {
                _context.AutorFavoritos.Remove(autorFavorito);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool AutorFavoritoExists(int id)
        {
            return _context.AutorFavoritos.Any(e => e.UsuarioId == id);
        }
    }
}
