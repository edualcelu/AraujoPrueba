using System;
using Datos.Negocio;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

#nullable disable

namespace Datos.Data
{
    public partial class AraujoDastosContext : DbContext
    {
        public AraujoDastosContext(DbContextOptions<AraujoDastosContext> options)
            : base(options)
        {
        }

        public virtual DbSet<PCliente> PClientes { get; set; }
        public virtual DbSet<PCuenta> PCuentas { get; set; }
        public virtual DbSet<PMovimiento> PMovimientos { get; set; }
        //public virtual DbSet<PPersona> PPersonas { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.Entity<PCliente>(entity =>
            {
                entity.HasKey(e => e.ClIdCliente)
                    .HasName("PK__p_client__0ED7ADE52FF1715F");

                entity.ToTable("p_cliente");

                entity.Property(e => e.ClIdCliente).HasColumnName("cl_id_cliente");

                entity.Property(e => e.ClContrasenia)
                    .IsRequired()
                    .HasMaxLength(30)
                    .IsUnicode(false)
                    .HasColumnName("cl_contrasenia");

                entity.Property(e => e.ClEstado).HasColumnName("cl_estado");

                entity.Property(e => e.PeIdentificacion)
                    .IsRequired()
                    .HasMaxLength(30)
                    .IsUnicode(false)
                    .HasColumnName("cl_identificacion");

                entity.Property(e => e.PeNombre)
                    .IsRequired()
                    .HasMaxLength(30)
                    .IsUnicode(false)
                    .HasColumnName("cl_nombre");

                entity.Property(e => e.PeGenero)
                    .IsRequired()
                    .HasMaxLength(30)
                    .IsUnicode(false)
                    .HasColumnName("cl_genero");

                entity.Property(e => e.PeEdad)
                    .IsRequired()
                    .HasMaxLength(30)
                    .IsUnicode(false)
                    .HasColumnName("cl_edad");

                entity.Property(e => e.PeDireccion)
                    .IsRequired()
                    .HasMaxLength(30)
                    .IsUnicode(false)
                    .HasColumnName("cl_direccion");

                entity.Property(e => e.PeTelefono)
                    .IsRequired()
                    .HasMaxLength(30)
                    .IsUnicode(false)
                    .HasColumnName("cl_telefono");


                //entity.HasOne(d => d.ClIdentificaciónNavigation)
                //    .WithMany(p => p.PClientes)
                //    .HasForeignKey(d => d.ClIdentificación)
                //    .OnDelete(DeleteBehavior.ClientSetNull)
                //    .HasConstraintName("FK__p_cliente__cl_id__267ABA7A");
            });

            modelBuilder.Entity<PCuenta>(entity =>
            {
                entity.HasKey(e => e.CuNumeroCuenta)
                    .HasName("PK__p_cuenta__5138EEC7A3581378");

                entity.ToTable("p_cuentas");

                entity.Property(e => e.CuNumeroCuenta)
                    .HasMaxLength(30)
                    .IsUnicode(false)
                    .HasColumnName("cu_numero_cuenta");

                entity.Property(e => e.CuEstado).HasColumnName("cu_estado");

                entity.Property(e => e.CuIdCliente).HasColumnName("cu_id_cliente");

                

                entity.Property(e => e.CuTipo)
                    .IsRequired()
                    .HasMaxLength(30)
                    .IsUnicode(false)
                    .HasColumnName("cu_tipo");

                entity.HasOne(d => d.CuIdClienteNavigation)
                    .WithMany(p => p.PCuenta)
                    .HasForeignKey(d => d.CuIdCliente)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__p_cuentas__cu_id__29572725");
            });

            modelBuilder.Entity<PMovimiento>(entity =>
            {
                entity.HasKey(e => e.MoIdMovimiento)
                    .HasName("PK__p_movimi__2D96FD7464EFD3EB");

                entity.ToTable("p_movimientos");

                entity.Property(e => e.MoIdMovimiento).HasColumnName("mo_id_movimiento");

             
                entity.Property(e => e.MoFecha)
                    .HasColumnType("datetime")
                    .HasColumnName("mo_fecha");

                entity.Property(e => e.MoNumeroCuenta)
                    .IsRequired()
                    .HasMaxLength(30)
                    .IsUnicode(false)
                    .HasColumnName("mo_numero_cuenta");

                entity.Property(e => e.MoSaldoInicial)
                    .HasColumnType("money")
                    .HasColumnName("mo_saldo_inicial");


                entity.Property(e => e.MoMovimiento)
                    .HasColumnType("money")
                    .HasColumnName("mo_movimiento");


                entity.Property(e => e.MoSaldoDisponible)
                    .HasColumnType("money")
                    .HasColumnName("mo_saldo_disponible");

                entity.Property(e => e.MoTipoMovimiento)
                    .IsRequired()
                    .HasMaxLength(30)
                    .IsUnicode(false)
                    .HasColumnName("mo_tipo_movimiento");

                

                entity.HasOne(d => d.MoNumeroCuentaNavigation)
                    .WithMany(p => p.PMovimientos)
                    .HasForeignKey(d => d.MoNumeroCuenta)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__p_movimie__mo_nu__2C3393D0");
            });

            //modelBuilder.Entity<PPersona>(entity =>
            //{
            //    entity.HasKey(e => e.PeIdentificacion)
            //        .HasName("PK__p_person__404B9ED99D2399DF");

            //    entity.ToTable("p_persona");

            //    entity.Property(e => e.PeIdentificacion)
            //        .HasMaxLength(30)
            //        .IsUnicode(false)
            //        .HasColumnName("pe_identificación");

            //    entity.Property(e => e.PeDireccion)
            //        .HasMaxLength(50)
            //        .IsUnicode(false)
            //        .HasColumnName("pe_dirección");

            //    entity.Property(e => e.PeEdad)
            //        .IsRequired()
            //        .HasMaxLength(3)
            //        .IsUnicode(false)
            //        .HasColumnName("pe_edad");

            //    entity.Property(e => e.PeGenero)
            //        .IsRequired()
            //        .HasMaxLength(30)
            //        .IsUnicode(false)
            //        .HasColumnName("pe_genero");

            //    entity.Property(e => e.PeNombre)
            //        .IsRequired()
            //        .HasMaxLength(30)
            //        .IsUnicode(false)
            //        .HasColumnName("pe_nombre");

            //    entity.Property(e => e.PeTelefono)
            //        .HasMaxLength(20)
            //        .IsUnicode(false)
            //        .HasColumnName("pe_teléfono");
            //});
        }

    }
}
