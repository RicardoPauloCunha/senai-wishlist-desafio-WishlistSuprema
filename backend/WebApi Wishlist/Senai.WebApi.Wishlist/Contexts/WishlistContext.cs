using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace Senai.WebApi.Wishlist.Domains
{
    public partial class WishlistContext : DbContext
    {
        public WishlistContext()
        {
        }

        public WishlistContext(DbContextOptions<WishlistContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Desejo> Desejo { get; set; }
        public virtual DbSet<Usuario> Usuario { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. See http://go.microsoft.com/fwlink/?LinkId=723263 for guidance on storing connection strings.
                optionsBuilder.UseSqlServer("Data source =.\\SQLSERVERJIROS;Initial Catalog=Wishlist; User id=sa;pwd=ji_15?27101001_roS");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Desejo>(entity =>
            {
                entity.ToTable("DESEJO");

                entity.Property(e => e.Desejoid).HasColumnName("DESEJOID");

                entity.Property(e => e.Datacricao)
                    .HasColumnName("DATACRICAO")
                    .HasColumnType("datetime");

                entity.Property(e => e.Descricao)
                    .IsRequired()
                    .HasColumnName("DESCRICAO")
                    .HasColumnType("text");

                entity.Property(e => e.Nome)
                    .IsRequired()
                    .HasColumnName("NOME")
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.Usuarioid).HasColumnName("USUARIOID");

                entity.HasOne(d => d.Usuario)
                    .WithMany(p => p.Desejo)
                    .HasForeignKey(d => d.Usuarioid)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__DESEJO__USUARIOI__3A81B327");
            });

            modelBuilder.Entity<Usuario>(entity =>
            {
                entity.ToTable("USUARIO");

                entity.HasIndex(e => e.Email)
                    .HasName("UQ__USUARIO__161CF7245A28215A")
                    .IsUnique();

                entity.Property(e => e.Usuarioid).HasColumnName("USUARIOID");

                entity.Property(e => e.Email)
                    .IsRequired()
                    .HasColumnName("EMAIL")
                    .HasMaxLength(250)
                    .IsUnicode(false);

                entity.Property(e => e.Nome)
                    .IsRequired()
                    .HasColumnName("NOME")
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.Senha)
                    .IsRequired()
                    .HasColumnName("SENHA")
                    .HasMaxLength(250)
                    .IsUnicode(false);
            });
        }
    }
}
