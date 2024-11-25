using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace Biblioteca.Models.DTO
{
    public class AutorDTO
    {
        [Column("id")]
        public int Id { get; set; }

        [Column("nombre")]
        [StringLength(50)]
        [Unicode(false)]
        public string Nombre { get; set; } = null!;

        [Column("imagen")]
        [StringLength(120)]
        [Unicode(false)]
        public string Imagen { get; set; } = null!;
    }
}
