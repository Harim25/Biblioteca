using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace Biblioteca.Models.dbModels
{
    public class AplicationUser : IdentityUser<int>
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

        [InverseProperty("Usuario")]
        public virtual ICollection<AutorFavorito> AutorFavoritos { get; set; } = new List<AutorFavorito>();

        [ForeignKey("GeneroId")]
        [InverseProperty("Usuarios")]
        public virtual GeneroUsuario Genero { get; set; } = null!;

        [InverseProperty("Usuario")]
        public virtual ICollection<LibroFavorito> LibroFavoritos { get; set; } = new List<LibroFavorito>();

        [InverseProperty("Usuario")]
        public virtual ICollection<Prestamo> Prestamos { get; set; } = new List<Prestamo>();
    }
}
