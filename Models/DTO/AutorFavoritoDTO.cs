using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace Biblioteca.Models.DTO
{
    public class AutorFavoritoDTO
    {
        [Column("usuarioId")]
        public int UsuarioId { get; set; }

        [Column("autorId")]
        public int AutorId { get; set; }

        [Column("fecha", TypeName = "datetime")]
        public DateTime? Fecha { get; set; }
    }
}
