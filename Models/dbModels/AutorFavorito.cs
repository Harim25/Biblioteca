using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace Biblioteca.Models.dbModels;

[PrimaryKey("UsuarioId", "AutorId")]
[Table("autorFavorito")]
public partial class AutorFavorito
{
    [Key]
    [Column("usuarioId")]
    public int UsuarioId { get; set; }

    [Key]
    [Column("autorId")]
    public int AutorId { get; set; }

    [Column("fecha", TypeName = "datetime")]
    public DateTime? Fecha { get; set; }

    [ForeignKey("AutorId")]
    [InverseProperty("AutorFavoritos")]
    public virtual Autor Autor { get; set; } = null!;

    [ForeignKey("UsuarioId")]
    [InverseProperty("AutorFavoritos")]
    public virtual Usuario Usuario { get; set; } = null!;
}
