using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace ToscanaWebApp.Models
{
    public partial class ToscanaBDContext : DbContext
    {
        public virtual DbSet<Categoriaproducto> Categoriaproducto { get; set; }
        public virtual DbSet<Cliente> Cliente { get; set; }
        public virtual DbSet<Detallepedido> Detallepedido { get; set; }
        public virtual DbSet<Producto> Producto { get; set; }

        public ToscanaBDContext(DbContextOptions options) : base(options)
        { }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Categoriaproducto>(entity =>
            {
                entity.ToTable("CATEGORIAPRODUCTO");

                entity.Property(e => e.Id).HasColumnName("ID");

                entity.Property(e => e.Categoria)
                    .IsRequired()
                    .HasColumnName("CATEGORIA")
                    .HasMaxLength(50)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<Cliente>(entity =>
            {
                entity.ToTable("CLIENTE");

                entity.Property(e => e.Id).HasColumnName("ID");

                entity.Property(e => e.Descripcion)
                    .IsRequired()
                    .HasColumnName("DESCRIPCION")
                    .HasColumnType("nchar(50)");

                entity.Property(e => e.Direccion)
                    .IsRequired()
                    .HasColumnName("DIRECCION")
                    .HasColumnType("char(350)");

                entity.Property(e => e.Email)
                    .IsRequired()
                    .HasColumnName("EMAIL")
                    .HasColumnType("nchar(100)");

                entity.Property(e => e.Nombre)
                    .IsRequired()
                    .HasColumnName("NOMBRE")
                    .HasColumnType("nchar(30)");

                entity.Property(e => e.Telefono)
                    .IsRequired()
                    .HasColumnName("TELEFONO")
                    .HasColumnType("char(15)");

                entity.Property(e => e.Username)
                    .HasColumnName("USERNAME")
                    .HasColumnType("nchar(256)");
            });

            modelBuilder.Entity<Detallepedido>(entity =>
            {
                entity.ToTable("DETALLEPEDIDO");

                entity.Property(e => e.Id).HasColumnName("ID");

                entity.Property(e => e.Cantidad).HasColumnName("CANTIDAD");

                entity.Property(e => e.Generado).HasColumnName("GENERADO");

                entity.Property(e => e.Pedidoid).HasColumnName("PEDIDOID");

                entity.Property(e => e.Productoid).HasColumnName("PRODUCTOID");

                entity.Property(e => e.Subtotal)
                    .HasColumnName("SUBTOTAL")
                    .HasColumnType("decimal(18, 4)");

                entity.HasOne(d => d.Producto)
                    .WithMany(p => p.Detallepedido)
                    .HasForeignKey(d => d.Productoid)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_DETALLEPEDIDO_PRODUCTO");
            });

            modelBuilder.Entity<Producto>(entity =>
            {
                entity.ToTable("PRODUCTO");

                entity.Property(e => e.Id).HasColumnName("ID");

                entity.Property(e => e.Activo).HasColumnName("ACTIVO");

                entity.Property(e => e.Cantidad).HasColumnName("CANTIDAD");

                entity.Property(e => e.Categoriaid).HasColumnName("CATEGORIAID");

                entity.Property(e => e.Costo)
                    .HasColumnName("COSTO")
                    .HasColumnType("decimal(18, 4)");

                entity.Property(e => e.Descripcion)
                    .IsRequired()
                    .HasColumnName("DESCRIPCION")
                    .HasColumnType("char(250)");

                entity.Property(e => e.Familiaid).HasColumnName("FAMILIAID");

                entity.Property(e => e.Fechacreacion)
                    .HasColumnName("FECHACREACION")
                    .HasColumnType("datetime");

                entity.Property(e => e.Fechamodifica)
                    .HasColumnName("FECHAMODIFICA")
                    .HasColumnType("datetime");

                entity.Property(e => e.Gravado)
                    .IsRequired()
                    .HasColumnName("GRAVADO")
                    .HasColumnType("char(1)")
                    .HasDefaultValueSql("('S')");

                entity.Property(e => e.Nombre)
                    .IsRequired()
                    .HasColumnName("NOMBRE")
                    .HasColumnType("char(50)");

                entity.Property(e => e.Precio)
                    .HasColumnName("PRECIO")
                    .HasColumnType("decimal(18, 4)");
            });
        }
    }
}
