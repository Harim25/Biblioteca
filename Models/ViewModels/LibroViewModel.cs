using Microsoft.AspNetCore.Mvc.Rendering;
using Biblioteca.Models.DTO;

namespace Biblioteca.Models.ViewModels
{
    public class LibroViewModel
    {
        public LibroCreateDTO ? LibroCreate { get; set; }

        public LibroUpdateDTO ? LibroUpdate { get; set; }

        public SelectList SelectListsAutores { get; set; } = null!;

        public SelectList SelectListsGeneros { get; set; } = null!;
    }
}
