using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace BlazorCRUD.Server.Models;

public partial class EstadiaSqlContext : DbContext
{
    public EstadiaSqlContext()
    {
    }

    public EstadiaSqlContext(DbContextOptions<EstadiaSqlContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Desempeño> Desempeños { get; set; }

    public virtual DbSet<DocumentacionPersonal> DocumentacionPersonals { get; set; }

    public virtual DbSet<DocumentoPHasHerramientum> DocumentoPHasHerramienta { get; set; }

    public virtual DbSet<Estancium> Estancia { get; set; }

    public virtual DbSet<ExamenActitud> ExamenActituds { get; set; }

    public virtual DbSet<ExamenAptitud> ExamenAptituds { get; set; }

    public virtual DbSet<Herramienta> Herramientas { get; set; }

    public virtual DbSet<IndicadoresDesempeño> IndicadoresDesempeños { get; set; }

    public virtual DbSet<Modulo> Modulos { get; set; }

    public virtual DbSet<NivelIngle> NivelIngles { get; set; }

    public virtual DbSet<Persona> Personas { get; set; }

    public virtual DbSet<PersonaHasModuloHasDesempeño> PersonaHasModuloHasDesempeños { get; set; }

    public virtual DbSet<Proyecto> Proyectos { get; set; }

    public virtual DbSet<Role> Roles { get; set; }

    public virtual DbSet<Seguimiento> Seguimientos { get; set; }

    public virtual DbSet<Usuario> Usuarios { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder) { }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Desempeño>(entity =>
        {
            entity.HasKey(e => e.IdDesempeño).HasName("PK__Desempeñ__668B8C48340B41FA");

            entity.ToTable("Desempeño");

            entity.Property(e => e.IdDesempeño).HasColumnName("ID_Desempeño");
            entity.Property(e => e.IdIndicaciones)
                .HasMaxLength(500)
                .IsUnicode(false)
                .HasColumnName("ID_Indicaciones");
            entity.Property(e => e.Observaciones)
                .HasMaxLength(500)
                .IsUnicode(false);
        });

        modelBuilder.Entity<DocumentacionPersonal>(entity =>
        {
            entity.HasKey(e => e.IdDoc).HasName("PK__Document__2BBC7E80DC0828B9");

            entity.ToTable("Documentacion_Personal");

            entity.Property(e => e.IdDoc).HasColumnName("ID_Doc");
            entity.Property(e => e.Cv).HasColumnName("CV");
            entity.Property(e => e.IdExamenAp).HasColumnName("ID_ExamenAp");
            entity.Property(e => e.IdExaxmenAc).HasColumnName("ID_ExaxmenAc");
            entity.Property(e => e.IdIngles).HasColumnName("ID_Ingles");
            entity.Property(e => e.IdPersona).HasColumnName("ID_Persona");
            entity.Property(e => e.Infomarcion)
                .HasMaxLength(200)
                .IsUnicode(false);
            entity.Property(e => e.Nivel)
                .HasMaxLength(80)
                .IsUnicode(false);
        });

        modelBuilder.Entity<DocumentoPHasHerramientum>(entity =>
        {
            entity.HasKey(e => e.IdPersona).HasName("PK__Document__E9916EC1346CD44C");

            entity.ToTable("DocumentoP_has_Herramienta");

            entity.Property(e => e.IdPersona).HasColumnName("ID_Persona");
            entity.Property(e => e.IdHerramienta).HasColumnName("ID_Herramienta");
        });

        modelBuilder.Entity<Estancium>(entity =>
        {
            entity.HasKey(e => e.Descripcion).HasName("PK__Estancia__92C53B6D53C1B27A");

            entity.Property(e => e.Descripcion)
                .HasMaxLength(150)
                .IsUnicode(false);
            entity.Property(e => e.FechaDeInicio)
                .HasColumnType("date")
                .HasColumnName("Fecha_de_Inicio");
            entity.Property(e => e.FechaFinal)
                .HasColumnType("date")
                .HasColumnName("Fecha_Final");
            entity.Property(e => e.IdPersona).HasColumnName("ID_Persona");
        });

        modelBuilder.Entity<ExamenActitud>(entity =>
        {
            entity.HasKey(e => e.IdExamenAc).HasName("PK__Examen_A__C68B882364980574");

            entity.ToTable("Examen_Actitud");

            entity.Property(e => e.IdExamenAc).HasColumnName("ID_ExamenAc");
            entity.Property(e => e.Examen)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.FechaRegistro).HasColumnType("date");
        });

        modelBuilder.Entity<ExamenAptitud>(entity =>
        {
            entity.HasKey(e => e.IdExamenAp).HasName("PK__Examen_A__C68B88368AEBDD65");

            entity.ToTable("Examen_Aptitud");

            entity.Property(e => e.IdExamenAp).HasColumnName("ID_ExamenAp");
            entity.Property(e => e.Examen)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.FechaRegistro).HasColumnType("date");
        });

        modelBuilder.Entity<Herramienta>(entity =>
        {
            entity.HasKey(e => e.IdHerramienta).HasName("PK__Herramie__019BDC2FE59AF9A5");

            entity.Property(e => e.IdHerramienta).HasColumnName("ID_Herramienta");
            entity.Property(e => e.Nombre)
                .HasMaxLength(50)
                .IsUnicode(false);
        });

        modelBuilder.Entity<IndicadoresDesempeño>(entity =>
        {
            entity.HasKey(e => e.IdIndicaciones).HasName("PK__Indicado__236A9C3E023B1209");

            entity.ToTable("Indicadores_Desempeño");

            entity.Property(e => e.IdIndicaciones).HasColumnName("ID_Indicaciones");
            entity.Property(e => e.Descripcion)
                .HasMaxLength(500)
                .IsUnicode(false);
        });

        modelBuilder.Entity<Modulo>(entity =>
        {
            entity.HasKey(e => e.IdModulo).HasName("PK__Modulos__E498BA6B0D790B37");

            entity.Property(e => e.IdModulo).HasColumnName("ID_Modulo");
            entity.Property(e => e.IdProyecto).HasColumnName("ID_Proyecto");
            entity.Property(e => e.IdSeguimiento).HasColumnName("ID_Seguimiento");
            entity.Property(e => e.NombreModulo)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("Nombre_Modulo");
        });

        modelBuilder.Entity<NivelIngle>(entity =>
        {
            entity.HasKey(e => e.IdIngles).HasName("PK__NivelIng__4B643DFC6B3A9FEE");

            entity.Property(e => e.IdIngles).HasColumnName("ID_Ingles");
        });

        modelBuilder.Entity<Persona>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__Persona__3214EC27220915A9");

            entity.ToTable("Persona");

            entity.Property(e => e.Id).HasColumnName("ID");
            entity.Property(e => e.Apellido)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.Correo)
                .HasMaxLength(100)
                .IsUnicode(false);
            entity.Property(e => e.Direccion)
                .HasMaxLength(150)
                .IsUnicode(false);
            entity.Property(e => e.FechaRegitro).HasColumnType("date");
            entity.Property(e => e.IdRoles)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("ID_Roles");
            entity.Property(e => e.Nombre)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.Telefono)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.WhatsApp)
                .HasMaxLength(50)
                .IsUnicode(false);
        });

        modelBuilder.Entity<PersonaHasModuloHasDesempeño>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__Persona___3214EC076198E7FD");

            entity.ToTable("Persona_has_Modulo_has_Desempeño");

            entity.Property(e => e.Area)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.FechaRegistro).HasColumnType("date");
            entity.Property(e => e.IdDesempeño).HasColumnName("ID_Desempeño");
            entity.Property(e => e.IdModulo).HasColumnName("ID_Modulo");
            entity.Property(e => e.IdPersona).HasColumnName("ID_Persona");
        });

        modelBuilder.Entity<Proyecto>(entity =>
        {
            entity.HasKey(e => e.IdProyecto).HasName("PK__Proyecto__F3BC07D22FDFF429");

            entity.ToTable("Proyecto");

            entity.Property(e => e.IdProyecto).HasColumnName("ID_Proyecto");
            entity.Property(e => e.FechaFinal).HasColumnType("date");
            entity.Property(e => e.FechaInicio).HasColumnType("date");
            entity.Property(e => e.NombreProyecto)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("Nombre_Proyecto");
        });

        modelBuilder.Entity<Role>(entity =>
        {
            entity.HasKey(e => e.IdRoles).HasName("PK__Roles__30F629932E79C78A");

            entity.Property(e => e.IdRoles).HasColumnName("ID_Roles");
            entity.Property(e => e.Rol)
                .HasMaxLength(50)
                .IsUnicode(false);
        });

        modelBuilder.Entity<Seguimiento>(entity =>
        {
            entity.HasKey(e => e.IdSeguimiento).HasName("PK__Seguimie__B710FBA3003457BD");

            entity.ToTable("Seguimiento");

            entity.Property(e => e.IdSeguimiento).HasColumnName("ID_Seguimiento");
            entity.Property(e => e.Estado)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.IdProyecto).HasColumnName("ID_Proyecto");
        });

        modelBuilder.Entity<Usuario>(entity =>
        {
            entity.HasKey(e => e.IdUsuario).HasName("PK__Usuario__DE4431C510B6FBC1");

            entity.ToTable("Usuario");

            entity.Property(e => e.IdUsuario).HasColumnName("ID_Usuario");
            entity.Property(e => e.Contraseña)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.IdPersona).HasColumnName("ID_Persona");
            entity.Property(e => e.StastusPersona)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("Stastus_Persona");
            entity.Property(e => e.Usuario1)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("Usuario");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
