using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace Biblioteca.Models.dbModels;

[PrimaryKey("UsuarioId", "LibroId")]
[Table("libroFavorito")]
public partial class LibroFavorito
{
    [Key]
    [Column("usuarioId")]
    public int UsuarioId { get; set; }

    [Key]
    [Column("libroId")]
    public int LibroId { get; set; }

    [Column("fecha", TypeName = "datetime")]
    public DateTime? Fecha { get; set; }

    [ForeignKey("LibroId")]
    [InverseProperty("LibroFavoritos")]
    public virtual Libro Libro { get; set; } = null!;

    [ForeignKey("UsuarioId")]
    [InverseProperty("LibroFavoritos")]
    public virtual AplicationUser Usuario { get; set; } = null!;
}
