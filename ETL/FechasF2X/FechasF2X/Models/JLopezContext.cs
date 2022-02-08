using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace FechasF2X.Models
{
    public partial class JLopezContext : DbContext
    {
        public JLopezContext()
        {
        }

        public JLopezContext(DbContextOptions<JLopezContext> options)
            : base(options)
        {
        }

        public virtual DbSet<ConteoVehiculo> ConteoVehiculos { get; set; } = null!;
        public virtual DbSet<RecaudoVehiculo> RecaudoVehiculos { get; set; } = null!;

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
                optionsBuilder.UseSqlServer(@"Server=20.122.126.220;Database=JLopez; User Id=julianl;Password=AP7ce2$_{\DtNr,a;");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<ConteoVehiculo>(entity =>
            {
                entity.ToTable("ConteoVehiculos", "julian");

                entity.Property(e => e.Id).HasColumnName("ID");

                entity.Property(e => e.Categoria)
                    .HasMaxLength(10)
                    .IsFixedLength();

                entity.Property(e => e.Estacion)
                    .HasMaxLength(10)
                    .IsFixedLength();

                entity.Property(e => e.Fecha).HasColumnType("date");

                entity.Property(e => e.Hora).HasColumnType("decimal(18, 0)");

                entity.Property(e => e.Sentido)
                    .HasMaxLength(10)
                    .IsFixedLength();
            });

            modelBuilder.Entity<RecaudoVehiculo>(entity =>
            {
                entity.ToTable("RecaudoVehiculos", "julian");

                entity.Property(e => e.Id).HasColumnName("ID");

                entity.Property(e => e.Categoria)
                    .HasMaxLength(10)
                    .IsFixedLength();

                entity.Property(e => e.Estacion)
                    .HasMaxLength(10)
                    .IsFixedLength();

                entity.Property(e => e.Fecha).HasColumnType("date");

                entity.Property(e => e.Sentido)
                    .HasMaxLength(10)
                    .IsFixedLength();

                entity.Property(e => e.ValorTabulado).HasColumnType("decimal(18, 0)");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
