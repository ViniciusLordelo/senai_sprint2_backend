using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;
using senai.hroads.webApi.Domains;

#nullable disable

namespace senai.hroads.webApi.Contexts
{
    public partial class HRoadsContext : DbContext
    {
        public HRoadsContext()
        {
        }

        public HRoadsContext(DbContextOptions<HRoadsContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Class> Classes { get; set; }
        public virtual DbSet<ClassesHabilidade> ClassesHabilidades { get; set; }
        public virtual DbSet<Habilidade> Habilidades { get; set; }
        public virtual DbSet<Personagen> Personagens { get; set; }
        public virtual DbSet<TiposHabilidade> TiposHabilidades { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
                optionsBuilder.UseSqlServer("Data Source=DESKTOP-2PS01IL; Initial Catalog=SENAI_HROADS_MANHA; user Id= sa; pwd=vinilordelo1;");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.HasAnnotation("Relational:Collation", "Latin1_General_CI_AS");

            modelBuilder.Entity<Class>(entity =>
            {
                entity.HasKey(e => e.IdClasses)
                    .HasName("PK__Classes__570106728DD7B350");

                entity.Property(e => e.IdClasses).HasColumnName("idClasses");

                entity.Property(e => e.Nome)
                    .IsRequired()
                    .HasMaxLength(200)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<ClassesHabilidade>(entity =>
            {
                entity.HasKey(e => e.IdClassesHabilidades)
                    .HasName("PK__ClassesH__C86EC7764C1E047C");

                entity.Property(e => e.IdClassesHabilidades).HasColumnName("idClassesHabilidades");

                entity.Property(e => e.IdClasses).HasColumnName("idClasses");

                entity.Property(e => e.IdHabilidades).HasColumnName("idHabilidades");

                entity.HasOne(d => d.IdClassesNavigation)
                    .WithMany(p => p.ClassesHabilidades)
                    .HasForeignKey(d => d.IdClasses)
                    .HasConstraintName("FK__ClassesHa__idCla__3D5E1FD2");

                entity.HasOne(d => d.IdHabilidadesNavigation)
                    .WithMany(p => p.ClassesHabilidades)
                    .HasForeignKey(d => d.IdHabilidades)
                    .HasConstraintName("FK__ClassesHa__idHab__3E52440B");
            });

            modelBuilder.Entity<Habilidade>(entity =>
            {
                entity.HasKey(e => e.IdHabilidades)
                    .HasName("PK__Habilida__A5B0BFF59AB10BAF");

                entity.Property(e => e.IdHabilidades).HasColumnName("idHabilidades");

                entity.Property(e => e.IdTipo).HasColumnName("idTipo");

                entity.Property(e => e.Nome)
                    .IsRequired()
                    .HasMaxLength(200)
                    .IsUnicode(false);

                entity.HasOne(d => d.IdTipoNavigation)
                    .WithMany(p => p.Habilidades)
                    .HasForeignKey(d => d.IdTipo)
                    .HasConstraintName("FK__Habilidad__idTip__38996AB5");
            });

            modelBuilder.Entity<Personagen>(entity =>
            {
                entity.HasKey(e => e.IdPersonagens)
                    .HasName("PK__Personag__F43A00D19A8A5974");

                entity.Property(e => e.IdPersonagens).HasColumnName("idPersonagens");

                entity.Property(e => e.DataAtualizacao).HasColumnType("date");

                entity.Property(e => e.DataCriacao).HasColumnType("date");

                entity.Property(e => e.IdClasses).HasColumnName("idClasses");

                entity.Property(e => e.Nome)
                    .IsRequired()
                    .HasMaxLength(200)
                    .IsUnicode(false);

                entity.HasOne(d => d.IdClassesNavigation)
                    .WithMany(p => p.Personagens)
                    .HasForeignKey(d => d.IdClasses)
                    .HasConstraintName("FK__Personage__idCla__412EB0B6");
            });

            modelBuilder.Entity<TiposHabilidade>(entity =>
            {
                entity.HasKey(e => e.IdTipo)
                    .HasName("PK__TiposHab__BDD0DFE17B439C5D");

                entity.ToTable("TiposHabilidade");

                entity.Property(e => e.IdTipo).HasColumnName("idTipo");

                entity.Property(e => e.Nome)
                    .IsRequired()
                    .HasMaxLength(200)
                    .IsUnicode(false);
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
