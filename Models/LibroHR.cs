using Biblioteca.Models.dbModels;
using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace Biblioteca.Models
{
    public class LibroHR
    {
        public int Id { get; set; }

        public string Titulo { get; set; } = null!;

        public int AutorId { get; set; }

        public int GeneroId { get; set; }

        public string Editorial { get; set; } = null!;

        public string Sinopsis { get; set; } = null!;

        public int Cantidad { get; set; }

        public DateTime? FechaCreacion { get; set; }

        public string Imagen { get; set; } = null!;

    }
}
