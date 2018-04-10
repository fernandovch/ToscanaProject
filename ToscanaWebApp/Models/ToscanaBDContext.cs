﻿using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace ToscanaWebApp.Models
{
    public partial class ToscanaBDContext : DbContext
    {
        public virtual DbSet<AspNetRoleClaims> AspNetRoleClaims { get; set; }
        public virtual DbSet<AspNetRoles> AspNetRoles { get; set; }
        public virtual DbSet<AspNetUserClaims> AspNetUserClaims { get; set; }
        public virtual DbSet<AspNetUserLogins> AspNetUserLogins { get; set; }
        public virtual DbSet<AspNetUserRoles> AspNetUserRoles { get; set; }
        public virtual DbSet<AspNetUsers> AspNetUsers { get; set; }
        public virtual DbSet<AspNetUserTokens> AspNetUserTokens { get; set; }
        public virtual DbSet<Categoriaproducto> Categoriaproducto { get; set; }
        public virtual DbSet<Cliente> Cliente { get; set; }
        public virtual DbSet<Detallepedido> Detallepedido { get; set; }
        public virtual DbSet<Inventariohistorico> Inventariohistorico { get; set; }
        public virtual DbSet<Pedidos> Pedidos { get; set; }
        public virtual DbSet<Producto> Producto { get; set; }
        public virtual DbSet<Tipounidad> Tipounidad { get; set; }

        public ToscanaBDContext(DbContextOptions<ToscanaBDContext> options) : base(options)
        { }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {

            if (!optionsBuilder.IsConfigured)
            {

                
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<AspNetRoleClaims>(entity =>
            {
                entity.HasIndex(e => e.RoleId);

                entity.Property(e => e.RoleId).IsRequired();

                entity.HasOne(d => d.Role)
                    .WithMany(p => p.AspNetRoleClaims)
                    .HasForeignKey(d => d.RoleId);
            });

            modelBuilder.Entity<AspNetRoles>(entity =>
            {
                entity.HasIndex(e => e.NormalizedName)
                    .HasName("RoleNameIndex")
                    .IsUnique()
                    .HasFilter("([NormalizedName] IS NOT NULL)");

                entity.Property(e => e.Id).ValueGeneratedNever();

                entity.Property(e => e.Name).HasMaxLength(256);

                entity.Property(e => e.NormalizedName).HasMaxLength(256);
            });

            modelBuilder.Entity<AspNetUserClaims>(entity =>
            {
                entity.HasIndex(e => e.UserId);

                entity.Property(e => e.UserId).IsRequired();

                entity.HasOne(d => d.User)
                    .WithMany(p => p.AspNetUserClaims)
                    .HasForeignKey(d => d.UserId);
            });

            modelBuilder.Entity<AspNetUserLogins>(entity =>
            {
                entity.HasKey(e => new { e.LoginProvider, e.ProviderKey });

                entity.HasIndex(e => e.UserId);

                entity.Property(e => e.UserId).IsRequired();

                entity.HasOne(d => d.User)
                    .WithMany(p => p.AspNetUserLogins)
                    .HasForeignKey(d => d.UserId);
            });

            modelBuilder.Entity<AspNetUserRoles>(entity =>
            {
                entity.HasKey(e => new { e.UserId, e.RoleId });

                entity.HasIndex(e => e.RoleId);

                entity.HasOne(d => d.Role)
                    .WithMany(p => p.AspNetUserRoles)
                    .HasForeignKey(d => d.RoleId);

                entity.HasOne(d => d.User)
                    .WithMany(p => p.AspNetUserRoles)
                    .HasForeignKey(d => d.UserId);
            });

            modelBuilder.Entity<AspNetUsers>(entity =>
            {
                entity.HasIndex(e => e.NormalizedEmail)
                    .HasName("EmailIndex");

                entity.HasIndex(e => e.NormalizedUserName)
                    .HasName("UserNameIndex")
                    .IsUnique()
                    .HasFilter("([NormalizedUserName] IS NOT NULL)");

                entity.Property(e => e.Id).ValueGeneratedNever();

                entity.Property(e => e.Email).HasMaxLength(256);

                entity.Property(e => e.NormalizedEmail).HasMaxLength(256);

                entity.Property(e => e.NormalizedUserName).HasMaxLength(256);

                entity.Property(e => e.UserName).HasMaxLength(256);
            });

            modelBuilder.Entity<AspNetUserTokens>(entity =>
            {
                entity.HasKey(e => new { e.UserId, e.LoginProvider, e.Name });

                entity.HasOne(d => d.User)
                    .WithMany(p => p.AspNetUserTokens)
                    .HasForeignKey(d => d.UserId);
            });

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
            });

            modelBuilder.Entity<Detallepedido>(entity =>
            {
                entity.ToTable("DETALLEPEDIDO");

                entity.Property(e => e.Id).HasColumnName("ID");

                entity.Property(e => e.Cantidad).HasColumnName("CANTIDAD");

                entity.Property(e => e.Pedidoid).HasColumnName("PEDIDOID");

                entity.Property(e => e.Productoid).HasColumnName("PRODUCTOID");

                entity.Property(e => e.Subtotal)
                    .HasColumnName("SUBTOTAL")
                    .HasColumnType("decimal(18, 4)");

                entity.HasOne(d => d.Pedido)
                    .WithMany(p => p.Detallepedido)
                    .HasForeignKey(d => d.Pedidoid)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_DETALLEPEDIDO_PEDIDOS");

                entity.HasOne(d => d.Producto)
                    .WithMany(p => p.Detallepedido)
                    .HasForeignKey(d => d.Productoid)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_DETALLEPEDIDO_PRODUCTO");
            });

            modelBuilder.Entity<Inventariohistorico>(entity =>
            {
                entity.HasKey(e => e.Indice);

                entity.ToTable("INVENTARIOHISTORICO");

                entity.Property(e => e.Indice).HasColumnName("INDICE");

                entity.Property(e => e.Cantidadactual).HasColumnName("CANTIDADACTUAL");

                entity.Property(e => e.Cantidadprevia).HasColumnName("CANTIDADPREVIA");

                entity.Property(e => e.Productoid).HasColumnName("PRODUCTOID");

                entity.HasOne(d => d.Producto)
                    .WithMany(p => p.Inventariohistorico)
                    .HasForeignKey(d => d.Productoid)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_INVENTARIOHISTORICO_PRODUCTO");
            });

            modelBuilder.Entity<Pedidos>(entity =>
            {
                entity.ToTable("PEDIDOS");

                entity.Property(e => e.Id).HasColumnName("ID");

                entity.Property(e => e.Celular)
                    .HasColumnName("CELULAR")
                    .HasColumnType("char(15)");

                entity.Property(e => e.Clienteid).HasColumnName("CLIENTEID");

                entity.Property(e => e.Codigopedido)
                    .IsRequired()
                    .HasColumnName("CODIGOPEDIDO")
                    .HasColumnType("char(50)");

                entity.Property(e => e.Direccion)
                    .HasColumnName("DIRECCION")
                    .HasColumnType("char(350)");

                entity.Property(e => e.Estado)
                    .IsRequired()
                    .HasColumnName("ESTADO")
                    .HasColumnType("char(1)");

                entity.Property(e => e.Telefono)
                    .HasColumnName("TELEFONO")
                    .HasColumnType("char(15)");

                entity.Property(e => e.Total)
                    .HasColumnName("TOTAL")
                    .HasColumnType("decimal(18, 4)");

                entity.HasOne(d => d.Cliente)
                    .WithMany(p => p.Pedidos)
                    .HasForeignKey(d => d.Clienteid)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_PEDIDOS_CLIENTE");
            });

            modelBuilder.Entity<Producto>(entity =>
            {
                entity.ToTable("PRODUCTO");

                entity.Property(e => e.Id).HasColumnName("ID");

                entity.Property(e => e.Cantidad).HasColumnName("CANTIDAD");

                entity.Property(e => e.Cantidadid).HasColumnName("CANTIDADID");

                entity.Property(e => e.Categoriaid).HasColumnName("CATEGORIAID");

                entity.Property(e => e.Costo)
                    .HasColumnName("COSTO")
                    .HasColumnType("decimal(18, 4)");

                entity.Property(e => e.Descripcion)
                    .IsRequired()
                    .HasColumnName("DESCRIPCION")
                    .HasColumnType("char(250)");

                entity.Property(e => e.Gravado)
                    .IsRequired()
                    .HasColumnName("GRAVADO")
                    .HasColumnType("char(1)")
                    .HasDefaultValueSql("('S')");

                entity.Property(e => e.Impuestovarios)
                    .HasColumnName("IMPUESTOVARIOS")
                    .HasColumnType("decimal(18, 4)");

                entity.Property(e => e.Impuestoventas)
                    .HasColumnName("IMPUESTOVENTAS")
                    .HasColumnType("decimal(18, 4)");

                entity.Property(e => e.Nombre)
                    .IsRequired()
                    .HasColumnName("NOMBRE")
                    .HasColumnType("char(50)");

                entity.Property(e => e.Precio)
                    .HasColumnName("PRECIO")
                    .HasColumnType("decimal(18, 4)");

                entity.HasOne(d => d.CantidadNavigation)
                    .WithMany(p => p.Producto)
                    .HasForeignKey(d => d.Cantidadid)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_PRODUCTO_TIPOUNIDAD");

                entity.HasOne(d => d.Categoria)
                    .WithMany(p => p.Producto)
                    .HasForeignKey(d => d.Categoriaid)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_PRODUCTO_CATEGORIAPRODUCTO");
            });

            modelBuilder.Entity<Tipounidad>(entity =>
            {
                entity.ToTable("TIPOUNIDAD");

                entity.Property(e => e.Id).HasColumnName("ID");

                entity.Property(e => e.Cantidad).HasColumnName("CANTIDAD");

                entity.Property(e => e.Descripcion)
                    .IsRequired()
                    .HasColumnName("DESCRIPCION")
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.Unidadmetrica)
                    .IsRequired()
                    .HasColumnName("UNIDADMETRICA")
                    .HasColumnType("nchar(10)");
            });
        }
    }
}