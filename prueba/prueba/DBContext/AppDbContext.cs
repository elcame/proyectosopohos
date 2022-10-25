using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;
using prueba.Models;

namespace prueba.DBContext
{
    public partial class AppDbContext : DbContext
    {
        public AppDbContext()
        {
        }

        public AppDbContext(DbContextOptions<AppDbContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Enfrentamiento> Enfrentamientos { get; set; } = null!;
        public virtual DbSet<Heroe> Heroes { get; set; } = null!;
        public virtual DbSet<Patrocina> Patrocinas { get; set; } = null!;
        public virtual DbSet<Patrocinador> Patrocinadors { get; set; } = null!;
        public virtual DbSet<Relacione> Relaciones { get; set; } = null!;
        public virtual DbSet<Villano> Villanos { get; set; } = null!;

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
                optionsBuilder.UseSqlServer("Data Source= DESKTOP-IB90627\\SQLEXPRESS;Initial Catalog= Guardians;Integrated Security=True");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Enfrentamiento>(entity =>
            {
                entity.HasKey(e => e.IdRegistro)
                    .HasName("PK__enfrenta__B803EB1161965693");

                entity.HasOne(d => d.IdHeroNavigation)
                    .WithMany(p => p.Enfrentamientos)
                    .HasForeignKey(d => d.IdHero)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__enfrentam__Id_he__3F466844");

                entity.HasOne(d => d.IdVillainNavigation)
                    .WithMany(p => p.Enfrentamientos)
                    .HasForeignKey(d => d.IdVillain)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__enfrentam__Id_vi__403A8C7D");
            });

            modelBuilder.Entity<Heroe>(entity =>
            {
                entity.HasKey(e => e.IdHero)
                    .HasName("PK__HEROE__81DF444D44B1441E");
            });

            modelBuilder.Entity<Patrocina>(entity =>
            {
                entity.HasKey(e => e.IdPatrocinio)
                    .HasName("PK__Patrocin__BED3D14CC7EAB8AA");

                entity.HasOne(d => d.IdHeroNavigation)
                    .WithMany(p => p.Patrocinas)
                    .HasForeignKey(d => d.IdHero)
                    .HasConstraintName("FK__Patrocina__id_he__656C112C");

                entity.HasOne(d => d.IdPatrocinadorNavigation)
                    .WithMany(p => p.Patrocinas)
                    .HasForeignKey(d => d.IdPatrocinador)
                    .HasConstraintName("FK__Patrocina__Id_pa__66603565");
            });

            modelBuilder.Entity<Patrocinador>(entity =>
            {
                entity.HasKey(e => e.IdPatrocinador)
                    .HasName("PK__Patrocin__16A94644C490EB6D");
            });

            modelBuilder.Entity<Relacione>(entity =>
            {
                entity.HasKey(e => e.IdRelacion)
                    .HasName("PK__Relacion__51F3AF4C5AF205E0");

                entity.HasOne(d => d.IdHeroNavigation)
                    .WithMany(p => p.Relaciones)
                    .HasForeignKey(d => d.IdHero)
                    .HasConstraintName("FK__Relacione__id_he__693CA210");
            });

            modelBuilder.Entity<Villano>(entity =>
            {
                entity.HasKey(e => e.IdVillain)
                    .HasName("PK__villano__CCE5B2E64FCFE50D");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
