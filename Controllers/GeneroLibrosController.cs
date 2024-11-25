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
    public class GeneroLibrosController : Controller
    {
        private readonly BibliotecaContext _context;

        public GeneroLibrosController(BibliotecaContext context)
        {
            _context = context;
        }

        // GET: GeneroLibros
        public async Task<IActionResult> Index()
        {
            return View(await _context.GeneroLibros.ToListAsync());
        }

        // GET: GeneroLibros/Details/5
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

        // GET: GeneroLibros/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: GeneroLibros/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Nombre")] GeneroLibro generoLibro)
        {
            if (ModelState.IsValid)
            {
                _context.Add(generoLibro);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(generoLibro);
        }

        // GET: GeneroLibros/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var generoLibro = await _context.GeneroLibros.FindAsync(id);
            if (generoLibro == null)
            {
                return NotFound();
            }
            return View(generoLibro);
        }

        // POST: GeneroLibros/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Nombre")] GeneroLibro generoLibro)
        {
            if (id != generoLibro.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(generoLibro);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!GeneroLibroExists(generoLibro.Id))
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
            return View(generoLibro);
        }

        // GET: GeneroLibros/Delete/5
        public async Task<IActionResult> Delete(int? id)
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

        // POST: GeneroLibros/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var generoLibro = await _context.GeneroLibros.FindAsync(id);
            if (generoLibro != null)
            {
                _context.GeneroLibros.Remove(generoLibro);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool GeneroLibroExists(int id)
        {
            return _context.GeneroLibros.Any(e => e.Id == id);
        }
    }
}
