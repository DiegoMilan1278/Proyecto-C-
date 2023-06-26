using System;
using System.Collections.Generic;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace NUEVODOS.Models
{
    public partial class NETJACKET2Context : IdentityDbContext
    {
        public NETJACKET2Context()
        {
        }

        public NETJACKET2Context(DbContextOptions<NETJACKET2Context> options)
            : base(options)
        {
        }

        public virtual DbSet<Compra> Compras { get; set; } = null!;
        public virtual DbSet<Vehiculo> Vehiculos { get; set; } = null!;
        public virtual DbSet<Venta> Ventas { get; set; } = null!;

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
//#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
//                optionsBuilder.UseSqlServer("Server=localhost;Initial Catalog=NETJACKET2;integrated security=True; TrustServerCertificate=True");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Compra>(entity =>
            {
                entity.HasKey(e => e.Idcompra)
                    .HasName("PK__Compras__6CA76DB8E7F239E3");

                entity.Property(e => e.Ciudadcompra)
                    .HasMaxLength(30)
                    .IsUnicode(false);

                entity.Property(e => e.Fechacompra)
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("(getdate())");

                entity.Property(e => e.Limitacionescompra)
                    .HasMaxLength(500)
                    .IsUnicode(false);

                entity.Property(e => e.Mpcompra)
                    .HasMaxLength(30)
                    .IsUnicode(false)
                    .HasColumnName("MPcompra");

                entity.Property(e => e.Placacompra)
                    .HasMaxLength(10)
                    .IsUnicode(false);

                entity.Property(e => e.Spcompra).HasColumnName("SPcompra");

                entity.HasOne(d => d.PlacaC)
                    .WithMany(p => p.Compras)
                    .HasForeignKey(d => d.Placacompra)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__Compras__Placaco__276EDEB3");
            });

            modelBuilder.Entity<Vehiculo>(entity =>
            {
                entity.HasKey(e => e.Placa)
                    .HasName("PK__Vehiculo__8310F99C85B7A0BC");

                entity.Property(e => e.Placa)
                    .HasMaxLength(10)
                    .IsUnicode(false);

                entity.Property(e => e.Capacidad)
                    .HasMaxLength(10)
                    .IsUnicode(false);

                entity.Property(e => e.Chasis)
                    .HasMaxLength(30)
                    .IsUnicode(false);

                entity.Property(e => e.Cilindraje)
                    .HasMaxLength(20)
                    .IsUnicode(false);

                entity.Property(e => e.Color)
                    .HasMaxLength(30)
                    .IsUnicode(false);

                entity.Property(e => e.Combustible)
                    .HasMaxLength(30)
                    .IsUnicode(false);

                entity.Property(e => e.Correadentada)
                    .HasMaxLength(30)
                    .IsUnicode(false);

                entity.Property(e => e.Empresa)
                    .HasMaxLength(30)
                    .IsUnicode(false);

                entity.Property(e => e.Kilometraje)
                    .HasMaxLength(20)
                    .IsUnicode(false);

                entity.Property(e => e.Linea)
                    .HasMaxLength(30)
                    .IsUnicode(false);

                entity.Property(e => e.Marca)
                    .HasMaxLength(30)
                    .IsUnicode(false);

                entity.Property(e => e.Matricula)
                    .HasMaxLength(7)
                    .IsUnicode(false);

                entity.Property(e => e.Motor)
                    .HasMaxLength(10)
                    .IsUnicode(false);

                entity.Property(e => e.Serie)
                    .HasMaxLength(20)
                    .IsUnicode(false);

                entity.Property(e => e.Servicio)
                    .HasMaxLength(30)
                    .IsUnicode(false);

                entity.Property(e => e.Soat)
                    .HasMaxLength(30)
                    .IsUnicode(false);

                entity.Property(e => e.Tecnomecanica)
                    .HasMaxLength(30)
                    .IsUnicode(false);

                entity.Property(e => e.Tipo)
                    .HasMaxLength(30)
                    .IsUnicode(false);

                entity.Property(e => e.Traccion)
                    .HasMaxLength(6)
                    .IsUnicode(false);

                entity.Property(e => e.Vehiculo1)
                    .HasMaxLength(30)
                    .IsUnicode(false)
                    .HasColumnName("Vehiculo");
            });

            modelBuilder.Entity<Venta>(entity =>
            {
                entity.HasKey(e => e.Idventa)
                    .HasName("PK__Ventas__AF5FD380C7D4DE2A");

                entity.Property(e => e.Ciudadventa)
                    .HasMaxLength(30)
                    .IsUnicode(false);

                entity.Property(e => e.Fechaventa)
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("(getdate())");

                entity.Property(e => e.Limitacionesventa)
                    .HasMaxLength(500)
                    .IsUnicode(false);

                entity.Property(e => e.Mpventa)
                    .HasMaxLength(30)
                    .IsUnicode(false)
                    .HasColumnName("MPventa");

                entity.Property(e => e.Placaventa)
                    .HasMaxLength(10)
                    .IsUnicode(false);

                entity.Property(e => e.Spventa).HasColumnName("SPventa");

                entity.HasOne(d => d.PlacaV)
                    .WithMany(p => p.Venta)
                    .HasForeignKey(d => d.Placaventa)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__Ventas__Placaven__2B3F6F97");
                base.OnModelCreating(modelBuilder);
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
