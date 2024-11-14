using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace Biblioteca.Models.dbModels;

[Table("generoLibro")]
[Index("Nombre", Name = "UQ__generoLi__72AFBCC6BA0FEC0F", IsUnique = true)]
public partial class GeneroLibro
{
    [Key]
    [Column("id")]
    public int Id { get; set; }

    [Column("nombre")]
    [StringLength(50)]
    [Unicode(false)]
    public string Nombre { get; set; } = null!;

    [InverseProperty("Genero")]
    public virtual ICollection<Libro> Libros { get; set; } = new List<Libro>();
}
