// Licensed to the .NET Foundation under one or more agreements.
// The .NET Foundation licenses this file to you under the MIT license.
#nullable disable

using System;
using System.ComponentModel.DataAnnotations;
using System.Text.Encodings.Web;
using System.Threading.Tasks;
using Biblioteca.Models.dbModels;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using SQLitePCL;

namespace Biblioteca.Areas.Identity.Pages.Account.Manage
{
    public class IndexModel : PageModel
    {
        private readonly UserManager<AplicationUser> _userManager;
        private readonly SignInManager<AplicationUser> _signInManager;
        private readonly BibliotecaContext _context;

        public IndexModel(
            UserManager<AplicationUser> userManager,
            SignInManager<AplicationUser> signInManager,
            BibliotecaContext context)
        {
            _userManager = userManager;
            _signInManager = signInManager;
            _context = context;
        }

        public string Username { get; set; }

        /// <summary>
        ///     This API supports the ASP.NET Core Identity default UI infrastructure and is not intended to be used
        ///     directly from your code. This API may change or be removed in future releases.
        /// </summary>
        [TempData]
        public string StatusMessage { get; set; }

        public List<SelectListItem> GenerosDisponibles { get; set; }
        /// <summary>
        ///     This API supports the ASP.NET Core Identity default UI infrastructure and is not intended to be used
        ///     directly from your code. This API may change or be removed in future releases.
        /// </summary>
        [BindProperty]
        public InputModel Input { get; set; }

        /// <summary>
        ///     This API supports the ASP.NET Core Identity default UI infrastructure and is not intended to be used
        ///     directly from your code. This API may change or be removed in future releases.
        /// </summary>
        public class InputModel
        {
            /// <summary>
            ///     This API supports the ASP.NET Core Identity default UI infrastructure and is not intended to be used
            ///     directly from your code. This API may change or be removed in future releases.
            /// </summary>
            [Phone]
            [Display(Name = "Numero de Telefono")]
            public string PhoneNumber { get; set; }

            [Display(Name = "Foto de Perfil")]
            public string Imagen { get; set; }

            [Display(Name = "Nombre")]
            public string Username { get; set; }

            [Display(Name = "Apellidos")]
            public string Apellidos { get; set; }

            [Display(Name = "Edad")]
            public int Edad { get; set; }

            [Display(Name = "Genero")]
            public int GeneroId { get; set; }

            [Display(Name = "Genero")]
            public string Genero { get; set; }

            [Display(Name = "Email")]
            public string Email { get; set; }
        }

        private async Task LoadAsync(AplicationUser user)
        {
            var userName = await _userManager.GetUserNameAsync(user);
            var phoneNumber = await _userManager.GetPhoneNumberAsync(user);

            // Cargar el género desde el contexto si es necesario
            var genero = await _context.GeneroUsuarios.FirstOrDefaultAsync(g => g.Id == user.GeneroId);

            Username = userName;
            // Asigna los valores adicionales del usuario
            var apellidos = user.Apellidos;
            var edad = user.Edad;
            var generoId = user.GeneroId;
            var email = user.Email;

            // Cargar la lista de géneros
            GenerosDisponibles = await _context.GeneroUsuarios
                .Select(g => new SelectListItem
                {
                    Value = g.Id.ToString(), // Id del género
                    Text = g.Genero // Descripción del género
                })
                .ToListAsync();

            Input = new InputModel
            {
                PhoneNumber = phoneNumber,
                Apellidos = user.Apellidos,
                Edad = user.Edad,
                GeneroId = user.GeneroId,
                Genero = genero?.Genero, // Descripción del género
                Email = user.Email,
                Username = userName
            };
        }

        public async Task<IActionResult> OnGetAsync()
        {
            var user = await _userManager.GetUserAsync(User);
            if (user == null)
            {
                return NotFound($"Unable to load user with ID '{_userManager.GetUserId(User)}'.");
            }

            await LoadAsync(user);
            return Page();
        }

        public async Task<IActionResult> OnPostAsync()
        {
            var user = await _userManager.GetUserAsync(User);
            if (user == null)
            {
                return NotFound($"Unable to load user with ID '{_userManager.GetUserId(User)}'.");
            }

            if (!ModelState.IsValid)
            {
                await LoadAsync(user);
                return Page();
            }

            var phoneNumber = await _userManager.GetPhoneNumberAsync(user);
            if (Input.PhoneNumber != phoneNumber)
            {
                var setPhoneResult = await _userManager.SetPhoneNumberAsync(user, Input.PhoneNumber);
                if (!setPhoneResult.Succeeded)
                {
                    StatusMessage = "Error inesperado al actualizar el número de teléfono.";
                    return RedirectToPage();
                }
            }

            user.UserName = Input.Username;
            user.Apellidos = Input.Apellidos;
            user.Edad = Input.Edad;
            user.Email = Input.Email;
            user.GeneroId = Input.GeneroId;
            user.Imagen = Input.Imagen;

            // Guardar cambios en el usuario
            var updateResult = await _userManager.UpdateAsync(user);
            if (!updateResult.Succeeded)
            {
                StatusMessage = "Error inesperado al actualizar el perfil.";
                return RedirectToPage();
            }

            await _signInManager.RefreshSignInAsync(user);
            StatusMessage = "Tu perfil ha sido actualizado.";
            return RedirectToPage();
        }
    }
}
