using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace Biblioteca.Models.DTO
{
    public class LibroCreateDTO
    {
        [Column("id")]
        public int Id { get; set; }

        [Column("titulo")]
        [StringLength(50)]
        [Unicode(false)]
        public string Titulo { get; set; } = null!;

        [Column("autorId")]
        public int AutorId { get; set; }

        [Column("generoId")]
        public int GeneroId { get; set; }

        [Column("editorial")]
        [StringLength(50)]
        [Unicode(false)]
        public string Editorial { get; set; } = null!;

        [Column("sinopsis")]
        [Unicode(false)]
        public string Sinopsis { get; set; } = null!;

        [Column("cantidad")]
        public int Cantidad { get; set; }

        [Column("fechaCreacion", TypeName = "datetime")]
        public DateTime? FechaCreacion { get; set; }

        [Column("imagen")]
        [StringLength(120)]
        [Unicode(false)]
        public string Imagen { get; set; } = null!;
    }
}
