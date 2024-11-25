using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace Biblioteca.Models.DTO
{
    public class UserDTO
    {
        [Column("apellidos")]
        [StringLength(50)]
        [Unicode(false)]
        public string Apellidos { get; set; } = null!;

        [Column("edad")]
        public int Edad { get; set; }

        [Column("generoId")]
        public int GeneroId { get; set; }

        [Column("imagen")]
        [StringLength(120)]
        public string? Imagen { get; set; }
    }
}
