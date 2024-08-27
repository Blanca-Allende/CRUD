using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;
using Tienda.Models.Entidades;

namespace Tienda.Models.Context
{
    public partial class ArticuloContext : DbContext
    {
        public ArticuloContext()
        {
        }

        public ArticuloContext(DbContextOptions<ArticuloContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Articulos> Articulos { get; set; } = null!;

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
//            if (!optionsBuilder.IsConfigured)
//            {
//#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
//                optionsBuilder.UseSqlServer("Server=localhost ;Database=PRODUCTOS;User ID=sa;password=tich;");
//            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Articulos>(entity =>
            {
                entity.ToTable("ARTICULOS");

                entity.Property(e => e.Codigo)
                    .HasMaxLength(15)
                    .IsUnicode(false);

                entity.Property(e => e.Descripcion).HasColumnType("text");

                entity.Property(e => e.Nombre)
                    .HasMaxLength(150)
                    .IsUnicode(false);
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
