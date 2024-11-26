using Biblioteca.Models.DTO;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace Biblioteca.Models.ViewModels
{
    public class LibroFavoritoViewModel
    {
        public LibroFavoritoCreateDTO? LibroFavoritoCreate { get; set; }

        public SelectList SelectListsLibros { get; set; } = null!;
    }
}
