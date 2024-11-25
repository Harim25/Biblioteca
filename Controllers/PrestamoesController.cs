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

namespace Biblioteca.Controllers
{
    [Authorize(Roles ="Admin")]
    public class PrestamoesController : Controller
    {
        private readonly BibliotecaContext _context;

        public PrestamoesController(BibliotecaContext context)
        {
            _context = context;
        }

        // GET: Prestamoes
        public async Task<IActionResult> Index()
        {
            var bibliotecaContext = _context.Prestamos.Include(p => p.Libro).Include(p => p.Usuario);
            return View(await bibliotecaContext.ToListAsync());
        }

        // GET: Prestamoes/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var prestamo = await _context.Prestamos
                .Include(p => p.Libro)
                .Include(p => p.Usuario)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (prestamo == null)
            {
                return NotFound();
            }

            return View(prestamo);
        }

        // GET: Prestamoes/Create
        public IActionResult Create()
        {
            PrestamoViewModel model = new PrestamoViewModel
            {
                PrestamoCreate = new PrestamoCreateDTO(),
                SelectListsUsuarios = new SelectList(_context.Users, "Id", "UserName"),
                SelectListsLibros = new SelectList(_context.Libros, "Id", "Titulo")
            };
            return View(model);
        }

        // POST: Prestamoes/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(PrestamoCreateDTO prestamoCreate)
        {
            if (ModelState.IsValid)
            {
                Prestamo prestamo = new Prestamo
                {
                    InicioPrestamo = prestamoCreate.InicioPrestamo,
                    FinPrestamo = prestamoCreate.FinPrestamo,
                    UsuarioId = prestamoCreate.UsuarioId,
                    LibroId = prestamoCreate.LibroId,
                    Prestado = prestamoCreate.Prestado,
                    Entregado = prestamoCreate.Entregado,
                };
                _context.Prestamos.Add(prestamo);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            PrestamoViewModel model = new()
            {
                PrestamoCreate = prestamoCreate,
                SelectListsUsuarios = new SelectList(_context.Users, "Id", "UserName"),
                SelectListsLibros = new SelectList(_context.Libros, "Id", "Titulo")
            };
            ViewData["LibroId"] = new SelectList(_context.Libros, "Id", "Id", prestamoCreate.LibroId);
            ViewData["UsuarioId"] = new SelectList(_context.Users, "Id", "Id", prestamoCreate.UsuarioId);
            return View(model);
        }

        // GET: Prestamoes/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var prestamo = await _context.Prestamos.FindAsync(id);
            if (prestamo == null)
            {
                return NotFound();
            }
            PrestamoViewModel model = new PrestamoViewModel
            {
                PrestamoUpdate = new PrestamoUpdateDTO
                {
                    Id = prestamo.Id,
                    InicioPrestamo = prestamo.InicioPrestamo,
                    FinPrestamo = prestamo.FinPrestamo,
                    UsuarioId = prestamo.UsuarioId,
                    LibroId = prestamo.LibroId,
                    Prestado = prestamo.Prestado,
                    Entregado = prestamo.Entregado,
                },
                SelectListsUsuarios = new SelectList(_context.Users, "Id", "UserName", prestamo.UsuarioId),
                SelectListsLibros = new SelectList(_context.Libros, "Id", "Titulo", prestamo.LibroId)
            };
            return View(model);
        }

        // POST: Prestamoes/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, PrestamoUpdateDTO prestamoUpdate)
        {
            if (id != prestamoUpdate.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    var prestamo = await _context.Prestamos.FindAsync(id);
                    if (prestamo == null)
                    {
                        return NotFound();
                    }

                    // Actualiza las propiedades necesarias
                    prestamo.InicioPrestamo = prestamoUpdate.InicioPrestamo;
                    prestamo.FinPrestamo = prestamoUpdate.FinPrestamo;
                    prestamo.UsuarioId = prestamoUpdate.UsuarioId;
                    prestamo.LibroId = prestamoUpdate.LibroId;
                    prestamo.Prestado = prestamoUpdate.Prestado;
                    prestamo.Entregado = prestamoUpdate.Entregado;

                    _context.Update(prestamo);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!PrestamoExists(prestamoUpdate.Id))
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
            PrestamoViewModel model = new PrestamoViewModel
            {
                PrestamoUpdate = prestamoUpdate,
                SelectListsUsuarios = new SelectList(_context.Users, "Id", "UserName", prestamoUpdate.UsuarioId),
                SelectListsLibros = new SelectList(_context.Libros, "Id", "Titulo", prestamoUpdate.LibroId)
            };
            return View(prestamoUpdate);
        }

        // GET: Prestamoes/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var prestamo = await _context.Prestamos
                .Include(p => p.Libro)
                .Include(p => p.Usuario)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (prestamo == null)
            {
                return NotFound();
            }

            return View(prestamo);
        }

        // POST: Prestamoes/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var prestamo = await _context.Prestamos.FindAsync(id);
            if (prestamo != null)
            {
                _context.Prestamos.Remove(prestamo);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool PrestamoExists(int id)
        {
            return _context.Prestamos.Any(e => e.Id == id);
        }
    }
}
