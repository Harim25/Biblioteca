using Biblioteca.Models.DTO;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace Biblioteca.Models.ViewModels
{
    public class PrestamoViewModel
    {
        public PrestamoCreateDTO? PrestamoCreate { get; set; }

        public PrestamoUpdateDTO? PrestamoUpdate { get; set; }

        public SelectList SelectListsUsuarios { get; set; } = null!;

        public SelectList SelectListsLibros { get; set; } = null!;
    }
}
