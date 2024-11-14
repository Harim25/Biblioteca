using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace Biblioteca.Models.dbModels;

[Table("rol")]
[Index("Rol1", Name = "UQ__rol__C2B79D265D91A362", IsUnique = true)]
public partial class Rol
{
    [Key]
    [Column("id")]
    public byte Id { get; set; }

    [Column("rol")]
    [StringLength(50)]
    [Unicode(false)]
    public string Rol1 { get; set; } = null!;

    [InverseProperty("Rol")]
    public virtual ICollection<Usuario> Usuarios { get; set; } = new List<Usuario>();
}
