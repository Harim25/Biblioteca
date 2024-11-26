using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace Biblioteca.Models.DTO
{
    public class LibroFavoritoDTO
    {
        [Column("usuarioId")]
        public int UsuarioId { get; set; }

        [Column("libroId")]
        public int LibroId { get; set; }

        [Column("fecha", TypeName = "datetime")]
        public DateTime? Fecha { get; set; }
    }
}
