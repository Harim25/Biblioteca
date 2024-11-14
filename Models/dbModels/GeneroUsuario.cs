using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace Biblioteca.Models.dbModels;

[Table("generoUsuario")]
[Index("Genero", Name = "UQ__generoUs__8C6B39E7009431EF", IsUnique = true)]
public partial class GeneroUsuario
{
    [Key]
    [Column("id")]
    public byte Id { get; set; }

    [Column("genero")]
    [StringLength(50)]
    [Unicode(false)]
    public string Genero { get; set; } = null!;

    [InverseProperty("Genero")]
    public virtual ICollection<AplicationUser> Usuarios { get; set; } = new List<AplicationUser>();
}
