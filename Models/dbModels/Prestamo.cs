using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace Biblioteca.Models.dbModels;

[Table("prestamo")]
public partial class Prestamo
{
    [Key]
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

    [ForeignKey("LibroId")]
    [InverseProperty("Prestamos")]
    public virtual Libro Libro { get; set; } = null!;

    [ForeignKey("UsuarioId")]
    [InverseProperty("Prestamos")]
    public virtual Usuario Usuario { get; set; } = null!;
}
