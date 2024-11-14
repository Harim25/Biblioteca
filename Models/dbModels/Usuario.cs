using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace Biblioteca.Models.dbModels;

[Table("usuario")]
[Index("Correo", Name = "UQ__usuario__2A586E0BC6D62A43", IsUnique = true)]
public partial class Usuario
{
    [Key]
    [Column("id")]
    public int Id { get; set; }

    [Column("nombres")]
    [StringLength(50)]
    [Unicode(false)]
    public string Nombres { get; set; } = null!;

    [Column("apellidos")]
    [StringLength(50)]
    [Unicode(false)]
    public string Apellidos { get; set; } = null!;

    [Column("correo")]
    [StringLength(50)]
    [Unicode(false)]
    public string Correo { get; set; } = null!;

    [Column("contrasena")]
    [StringLength(120)]
    [Unicode(false)]
    public string Contrasena { get; set; } = null!;

    [Column("edad")]
    public byte Edad { get; set; }

    [Column("generoId")]
    public byte GeneroId { get; set; }

    [Column("rolId")]
    public byte RolId { get; set; }

    [Column("imagen")]
    [StringLength(120)]
    [Unicode(false)]
    public string Imagen { get; set; } = null!;

    [InverseProperty("Usuario")]
    public virtual ICollection<AutorFavorito> AutorFavoritos { get; set; } = new List<AutorFavorito>();

    [ForeignKey("GeneroId")]
    [InverseProperty("Usuarios")]
    public virtual GeneroUsuario Genero { get; set; } = null!;

    [InverseProperty("Usuario")]
    public virtual ICollection<LibroFavorito> LibroFavoritos { get; set; } = new List<LibroFavorito>();

    [InverseProperty("Usuario")]
    public virtual ICollection<Prestamo> Prestamos { get; set; } = new List<Prestamo>();

    [ForeignKey("RolId")]
    [InverseProperty("Usuarios")]
    public virtual Rol Rol { get; set; } = null!;
}
