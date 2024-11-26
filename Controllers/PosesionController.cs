using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Biblioteca.Models.dbModels;
using System.Security.Claims;
using Microsoft.AspNetCore.Authorization;

namespace Biblioteca.Controllers
{
    [Authorize]
    public class PosesionController : Controller
    {
        private readonly BibliotecaContext _context;

        public PosesionController(BibliotecaContext context)
        {
            _context = context;
        }

        // GET: Posesion
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
            var bibliotecaContext = _context.Prestamos
                .Include(p => p.Libro)
                .Include(p => p.Usuario)
                .Where(p => p.UsuarioId == userId);

            var prestamos = await bibliotecaContext.ToListAsync();

            // Si no hay préstamos, define un mensaje
            if (!prestamos.Any())
            {
                ViewBag.Mensaje = "De momento no se te han prestado libros.";
            }

            return View(prestamos);
        }

        // GET: Posesion/Details/5
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
    }
}
