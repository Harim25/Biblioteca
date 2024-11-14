using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace Biblioteca.Models.dbModels;

public partial class BibliotecaContext : DbContext
{
    public BibliotecaContext()
    {
    }

    public BibliotecaContext(DbContextOptions<BibliotecaContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Autor> Autors { get; set; }

    public virtual DbSet<AutorFavorito> AutorFavoritos { get; set; }

    public virtual DbSet<GeneroLibro> GeneroLibros { get; set; }

    public virtual DbSet<GeneroUsuario> GeneroUsuarios { get; set; }

    public virtual DbSet<Libro> Libros { get; set; }

    public virtual DbSet<LibroFavorito> LibroFavoritos { get; set; }

    public virtual DbSet<Prestamo> Prestamos { get; set; }

    public virtual DbSet<Rol> Rols { get; set; }

    public virtual DbSet<Usuario> Usuarios { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see https://go.microsoft.com/fwlink/?LinkId=723263.
        => optionsBuilder.UseSqlServer("Server=.\\SQLEXPRESS;Database=Biblioteca;Trusted_Connection=True;TrustServerCertificate=True;");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Autor>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__autor__3213E83FC7B26D30");
        });

        modelBuilder.Entity<AutorFavorito>(entity =>
        {
            entity.HasKey(e => new { e.UsuarioId, e.AutorId }).HasName("PK__autorFav__FFB66D2ABEDCD41A");

            entity.Property(e => e.Fecha).HasDefaultValueSql("(getdate())");

            entity.HasOne(d => d.Autor).WithMany(p => p.AutorFavoritos)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__autorFavo__autor__3F466844");

            entity.HasOne(d => d.Usuario).WithMany(p => p.AutorFavoritos)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__autorFavo__usuar__403A8C7D");
        });

        modelBuilder.Entity<GeneroLibro>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__generoLi__3213E83F1963001A");
        });

        modelBuilder.Entity<GeneroUsuario>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__generoUs__3213E83F1F4240B1");

            entity.Property(e => e.Id).ValueGeneratedOnAdd();
        });

        modelBuilder.Entity<Libro>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__libro__3213E83FA800740F");

            entity.Property(e => e.FechaCreacion).HasDefaultValueSql("(getdate())");

            entity.HasOne(d => d.Autor).WithMany(p => p.Libros)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__libro__autorId__412EB0B6");

            entity.HasOne(d => d.Genero).WithMany(p => p.Libros)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__libro__generoId__4222D4EF");
        });

        modelBuilder.Entity<LibroFavorito>(entity =>
        {
            entity.HasKey(e => new { e.UsuarioId, e.LibroId }).HasName("PK__libroFav__043DCE446D075979");

            entity.Property(e => e.Fecha).HasDefaultValueSql("(getdate())");

            entity.HasOne(d => d.Libro).WithMany(p => p.LibroFavoritos)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__libroFavo__libro__4316F928");

            entity.HasOne(d => d.Usuario).WithMany(p => p.LibroFavoritos)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__libroFavo__usuar__440B1D61");
        });

        modelBuilder.Entity<Prestamo>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__prestamo__3213E83FBB2980C7");

            entity.Property(e => e.Entregado).HasDefaultValue(false);
            entity.Property(e => e.InicioPrestamo).HasDefaultValueSql("(getdate())");
            entity.Property(e => e.Prestado).HasDefaultValue(false);

            entity.HasOne(d => d.Libro).WithMany(p => p.Prestamos)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__prestamo__libroI__44FF419A");

            entity.HasOne(d => d.Usuario).WithMany(p => p.Prestamos)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__prestamo__usuari__45F365D3");
        });

        modelBuilder.Entity<Rol>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__rol__3213E83F381E914D");

            entity.Property(e => e.Id).ValueGeneratedOnAdd();
        });

        modelBuilder.Entity<Usuario>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__usuario__3213E83F76DF6378");

            entity.HasOne(d => d.Genero).WithMany(p => p.Usuarios)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__usuario__generoI__46E78A0C");

            entity.HasOne(d => d.Rol).WithMany(p => p.Usuarios)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__usuario__rolId__47DBAE45");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
