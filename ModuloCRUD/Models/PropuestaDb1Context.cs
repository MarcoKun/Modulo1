using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace ModuloCRUD.Models;

public partial class PropuestaDb1Context : DbContext
{
    public PropuestaDb1Context()
    {
    }

    public PropuestaDb1Context(DbContextOptions<PropuestaDb1Context> options)
        : base(options)
    {
    }

    public virtual DbSet<EspacioTrabajo> EspacioTrabajo { get; set; }

    public virtual DbSet<EstatusLicencia> EstatusLicencia { get; set; }

    public virtual DbSet<TipoLicencia> TipoLicencia { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder) { }
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<EspacioTrabajo>(entity =>
        {
            entity.HasKey(e => e.IdEspacioTrabajo).HasName("PK__EspacioT__268785B73C4A6CCB");

            entity.ToTable("EspacioTrabajo");

            entity.Property(e => e.CorreoAdministrador)
                .HasMaxLength(80)
                .IsUnicode(false);
            entity.Property(e => e.EstatusLicenciaIdEstatusLicencia).HasColumnName("EstatusLicencia_IdEstatusLicencia");
            entity.Property(e => e.FechaCaducidadLicencia).HasColumnType("date");
            entity.Property(e => e.FechaCreacionEspacioTrabajo).HasColumnType("date");
            entity.Property(e => e.FechaInicioLicencia).HasColumnType("date");
            entity.Property(e => e.NombreAdministradorEspacio)
                .HasMaxLength(45)
                .IsUnicode(false);
            entity.Property(e => e.NombreEspacioTrabajo)
                .HasMaxLength(100)
                .IsUnicode(false);
            entity.Property(e => e.NombreInstitucion)
                .HasMaxLength(100)
                .IsUnicode(false);
            entity.Property(e => e.TelefonoContacto)
                .HasMaxLength(15)
                .IsUnicode(false);
            entity.Property(e => e.TipoLicenciaIdTipoLicencia).HasColumnName("TipoLicencia_IdTipoLicencia");
            entity.Property(e => e.Usuario)
                .HasMaxLength(45)
                .IsUnicode(false);

            entity.HasOne(d => d.EstatusLicenciaIdEstatusLicenciaNavigation).WithMany(p => p.EspacioTrabajos)
                .HasForeignKey(d => d.EstatusLicenciaIdEstatusLicencia)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__EspacioTr__Estat__3B75D760");

            entity.HasOne(d => d.TipoLicenciaIdTipoLicenciaNavigation).WithMany(p => p.EspacioTrabajos)
                .HasForeignKey(d => d.TipoLicenciaIdTipoLicencia)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__EspacioTr__TipoL__3C69FB99");
        });

        modelBuilder.Entity<EstatusLicencia>(entity =>
        {
            entity.HasKey(e => e.IdEstatusLicencia).HasName("PK__EstatusL__AAEE4ADF43D122D5");

            entity.Property(e => e.Estatus)
                .HasMaxLength(25)
                .IsUnicode(false);
        });

        modelBuilder.Entity<TipoLicencia>(entity =>
        {
            entity.HasKey(e => e.IdTipoLicencia).HasName("PK__TipoLice__8E36AAAA7B707877");

            entity.Property(e => e.Tipo)
                .HasMaxLength(1)
                .IsUnicode(false);
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
