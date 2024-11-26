using Biblioteca.Models.DTO;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace Biblioteca.Models.ViewModels
{
    public class AutorFavoritoViewModel
    {
        public AutorFavoritoCreateDTO? AutorFavoritoCreate { get; set; }

        public SelectList SelectListsAutores { get; set; } = null!;
    }
}
