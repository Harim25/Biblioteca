using System.ComponentModel.DataAnnotations.Schema;

namespace Biblioteca.Models.DTO
{
    public class PrestamoDTO
    {
        [Column("id")]
        public int Id { get; set; }

        [Column("inicioPrestamo", TypeName = "datetime")]
        public DateTime? InicioPrestamo { get; set; }

        [Column("finPrestamo", TypeName = "datetime")]
        public DateTime FinPrestamo { get; set; }

        [Column("usuarioId")]
        public int UsuarioId { get; set; }

        [Column("libroId")]
        public int LibroId { get; set; }

        [Column("prestado")]
        public bool? Prestado { get; set; }

        [Column("entregado")]
        public bool? Entregado { get; set; }
    }
}
