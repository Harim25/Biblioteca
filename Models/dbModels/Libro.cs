using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace Biblioteca.Models.dbModels;

[Table("libro")]
[Index("Titulo", Name = "UQ__libro__38FA640F1022E99D", IsUnique = true)]
public partial class Libro
{
    [Key]
    [Column("id")]
    public int Id { get; set; }

    [Column("titulo")]
    [StringLength(50)]
    [Unicode(false)]
    public string Titulo { get; set; } = null!;

    [Column("autorId")]
    public int AutorId { get; set; }

    [Column("generoId")]
    public int GeneroId { get; set; }

    [Column("editorial")]
    [StringLength(50)]
    [Unicode(false)]
    public string Editorial { get; set; } = null!;

    [Column("sinopsis")]
    [Unicode(false)]
    public string Sinopsis { get; set; } = null!;

    [Column("cantidad")]
    public int Cantidad { get; set; }

    [Column("fechaCreacion", TypeName = "datetime")]
    public DateTime? FechaCreacion { get; set; }

    [Column("imagen")]
    [StringLength(120)]
    [Unicode(false)]
    public string Imagen { get; set; } = null!;

    [ForeignKey("AutorId")]
    [InverseProperty("Libros")]
    public virtual Autor Autor { get; set; } = null!;

    [ForeignKey("GeneroId")]
    [InverseProperty("Libros")]
    public virtual GeneroLibro Genero { get; set; } = null!;

    [InverseProperty("Libro")]
    public virtual ICollection<LibroFavorito> LibroFavoritos { get; set; } = new List<LibroFavorito>();

    [InverseProperty("Libro")]
    public virtual ICollection<Prestamo> Prestamos { get; set; } = new List<Prestamo>();
}
