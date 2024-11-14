using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace Biblioteca.Models.dbModels;

[Table("autor")]
[Index("Nombre", Name = "UQ__autor__72AFBCC66DCCF882", IsUnique = true)]
public partial class Autor
{
    [Key]
    [Column("id")]
    public int Id { get; set; }

    [Column("nombre")]
    [StringLength(50)]
    [Unicode(false)]
    public string Nombre { get; set; } = null!;

    [Column("imagen")]
    [StringLength(120)]
    [Unicode(false)]
    public string Imagen { get; set; } = null!;

    [InverseProperty("Autor")]
    public virtual ICollection<AutorFavorito> AutorFavoritos { get; set; } = new List<AutorFavorito>();

    [InverseProperty("Autor")]
    public virtual ICollection<Libro> Libros { get; set; } = new List<Libro>();
}
