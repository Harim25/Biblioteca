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
    [Authorize(Roles = "Admin")]
    public class UsersController : Controller
    {
        private readonly BibliotecaContext _context;

        public UsersController(BibliotecaContext context)
        {
            _context = context;
        }

        // GET: Users
        public async Task<IActionResult> Index()
        {
            var bibliotecaContext = _context.Users.Include(a => a.Genero);
            return View(await bibliotecaContext.ToListAsync());
        }

        // GET: Users/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var aplicationUser = await _context.Users
                .Include(a => a.Genero)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (aplicationUser == null)
            {
                return NotFound();
            }

            return View(aplicationUser);
        }

        // GET: Users/Create
        public IActionResult Create()
        {
            ViewData["GeneroId"] = new SelectList(_context.GeneroUsuarios, "Id", "Id");
            return View();
        }

        // POST: Users/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Apellidos,Edad,GeneroId,Imagen,Id,UserName,NormalizedUserName,Email,NormalizedEmail,EmailConfirmed,PasswordHash,SecurityStamp,ConcurrencyStamp,PhoneNumber,PhoneNumberConfirmed,TwoFactorEnabled,LockoutEnd,LockoutEnabled,AccessFailedCount")] AplicationUser aplicationUser)
        {
            if (ModelState.IsValid)
            {
                _context.Add(aplicationUser);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["GeneroId"] = new SelectList(_context.GeneroUsuarios, "Id", "Id", aplicationUser.GeneroId);
            return View(aplicationUser);
        }

        // GET: Users/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var aplicationUser = await _context.Users.FindAsync(id);
            if (aplicationUser == null)
            {
                return NotFound();
            }
            ViewData["GeneroId"] = new SelectList(_context.GeneroUsuarios, "Id", "Genero", aplicationUser.GeneroId);
            return View(aplicationUser);
        }

        // POST: Users/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Apellidos,Edad,GeneroId,Imagen,Id,UserName,NormalizedUserName,Email,NormalizedEmail,EmailConfirmed,PasswordHash,SecurityStamp,ConcurrencyStamp,PhoneNumber,PhoneNumberConfirmed,TwoFactorEnabled,LockoutEnd,LockoutEnabled,AccessFailedCount")] AplicationUser aplicationUser)
        {
            if (id != aplicationUser.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(aplicationUser);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!AplicationUserExists(aplicationUser.Id))
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
            ViewData["GeneroId"] = new SelectList(_context.GeneroUsuarios, "Id", "Id", aplicationUser.GeneroId);
            return View(aplicationUser);
        }

        // GET: Users/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var aplicationUser = await _context.Users
                .Include(a => a.Genero)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (aplicationUser == null)
            {
                return NotFound();
            }

            return View(aplicationUser);
        }

        // POST: Users/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var aplicationUser = await _context.Users.FindAsync(id);
            if (aplicationUser != null)
            {
                _context.Users.Remove(aplicationUser);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool AplicationUserExists(int id)
        {
            return _context.Users.Any(e => e.Id == id);
        }
    }
}
