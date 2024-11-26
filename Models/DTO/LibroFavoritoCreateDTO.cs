using System.ComponentModel.DataAnnotations.Schema;

namespace Biblioteca.Models.DTO
{
    public class LibroFavoritoCreateDTO
    {
        [Column("usuarioId")]
        public int UsuarioId { get; set; }

        [Column("libroId")]
        public int LibroId { get; set; }

        [Column("fecha", TypeName = "datetime")]
        public DateTime? Fecha { get; set; }
    }
}
