using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace Parcial01Back.Models;

public partial class Parcial01Context : DbContext
{
    public Parcial01Context()
    {
    }

    public Parcial01Context(DbContextOptions<Parcial01Context> options)
        : base(options)
    {
    }

    public virtual DbSet<Comidum> Comida { get; set; }

    public virtual DbSet<Duenio> Duenios { get; set; }

    public virtual DbSet<Mascota> Mascotas { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
        => optionsBuilder.UseSqlServer("Server=DESKTOP-T253PKQ\\SQLEXPRESS; Database=Parcial01; Trusted_Connection=True; TrustServerCertificate=True;");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Comidum>(entity =>
        {
            entity.HasKey(e => e.IdComida).HasName("PK__Comida__C67C2837C8A9F41B");

            entity.Property(e => e.IdComida)
                .ValueGeneratedNever()
                .HasColumnName("id_comida");
            entity.Property(e => e.Cantidad).HasColumnName("cantidad");
            entity.Property(e => e.IdMascota).HasColumnName("id_mascota");
            entity.Property(e => e.Nombre)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("nombre");
            entity.Property(e => e.Tipo)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("tipo");
        });

        modelBuilder.Entity<Duenio>(entity =>
        {
            entity.HasKey(e => e.IdDuenio).HasName("PK__Duenios__737D0896E6299F35");

            entity.Property(e => e.IdDuenio)
                .ValueGeneratedNever()
                .HasColumnName("id_duenio");
            entity.Property(e => e.Direccion)
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasColumnName("direccion");
            entity.Property(e => e.Nombre)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("nombre");
            entity.Property(e => e.Telefono)
                .HasMaxLength(15)
                .IsUnicode(false)
                .HasColumnName("telefono");
        });

        modelBuilder.Entity<Mascota>(entity =>
        {
            entity.HasKey(e => e.IdMascota).HasName("PK__Mascotas__6F037352F036B828");

            entity.Property(e => e.IdMascota)
                .ValueGeneratedNever()
                .HasColumnName("id_mascota");
            entity.Property(e => e.Especie)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("especie");
            entity.Property(e => e.FechaNacimiento)
                .HasColumnType("date")
                .HasColumnName("fecha_nacimiento");
            entity.Property(e => e.IdDuenio).HasColumnName("id_duenio");
            entity.Property(e => e.Nombre)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("nombre");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
