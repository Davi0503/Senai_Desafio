using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace Infra.Data.Domains
{
    public partial class WishContext : DbContext
    {
        public WishContext()
        {
        }

        public WishContext(DbContextOptions<WishContext> options)
            : base(options)
        {
        }

        public virtual DbSet<User> Usuarios { get; set; }
        public virtual DbSet<Wish> Wish { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. See http://go.microsoft.com/fwlink/?LinkId=723263 for guidance on storing connection strings.
                optionsBuilder.UseSqlServer("Data Source=.\\SQLEXPRESS; Initial Catalog= WISHLIST; USER ID = sa; Pwd= 132");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<User>(entity =>
            {
                entity.ToTable("USUARIOS");

                entity.Property(e => e.Id).HasColumnName("ID");

                entity.Property(e => e.Ativo).HasColumnName("ATIVO");

                entity.Property(e => e.Email)
                    .IsRequired()
                    .HasColumnName("EMAIL")
                    .HasMaxLength(150)
                    .IsUnicode(false);

                entity.Property(e => e.Nome)
                    .IsRequired()
                    .HasColumnName("NOME")
                    .HasMaxLength(150)
                    .IsUnicode(false);

                entity.Property(e => e.Senha)
                    .IsRequired()
                    .HasColumnName("SENHA")
                    .HasMaxLength(150)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<Wish>(entity =>
            {
                entity.ToTable("WISH");

                entity.Property(e => e.Id).HasColumnName("ID");

                entity.Property(e => e.Ativo).HasColumnName("ATIVO");

                entity.Property(e => e.Creationdt)
                    .HasColumnName("CREATIONDT")
                    .HasColumnType("datetime");

                entity.Property(e => e.Descwish)
                    .IsRequired()
                    .HasColumnName("DESCWISH")
                    .HasMaxLength(150)
                    .IsUnicode(false);

                entity.Property(e => e.IdUsuario).HasColumnName("ID_USUARIO");

                
            });
        }
    }
}
