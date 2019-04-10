using Microsoft.EntityFrameworkCore;

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
                optionsBuilder.UseSqlServer("Data Source = .\\SQLEXPRESS ; Initial Catalog = Senai_Wishlist_Desafio; user id = sa; pwd = 132;");
                //optionsBuilder.UseSqlServer("Data Source=.\\NOVOSERVIDOR ; Initial Catalog = Senai_Wishlist_Desafio ; Integrated Security=SSPI;");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Desejo>(entity =>
            {
                entity.ToTable("DESEJO");

                entity.Property(e => e.Desejoid).HasColumnName("DESEJOID");

                entity.Property(e => e.Datacriacao)
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
                    .HasConstraintName("FK__DESEJO__USUARIOI__4CA06362");
            });

            modelBuilder.Entity<Usuario>(entity =>
            {
                entity.ToTable("USUARIO");

                entity.HasIndex(e => e.Email)
                    .HasName("UQ__USUARIO__161CF724C75CD11E")
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
