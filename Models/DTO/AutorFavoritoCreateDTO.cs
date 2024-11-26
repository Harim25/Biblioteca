using System.ComponentModel.DataAnnotations.Schema;

namespace Biblioteca.Models.DTO
{
    public class AutorFavoritoCreateDTO
    {
        [Column("autorId")]
        public int AutorId { get; set; }

        [Column("fecha", TypeName = "datetime")]
        public DateTime? Fecha { get; set; }
    }
}
