using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace GSB._0.Models
{
    public partial class GSB_2024Context : DbContext
    {
        public GSB_2024Context()
        {
        }

        public GSB_2024Context(DbContextOptions<GSB_2024Context> options)
            : base(options)
        {
        }

        public virtual DbSet<Departement> Departements { get; set; } = null!;
        public virtual DbSet<DomaineDeSpecialite> DomaineDeSpecialites { get; set; } = null!;
        public virtual DbSet<Medecin> Medecins { get; set; } = null!;
        public virtual DbSet<User> Users { get; set; } = null!;

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
                optionsBuilder.UseSqlServer("Data Source=.;Initial Catalog=GSB_2024;Integrated Security=True;Trust Server Certificate=True");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Departement>(entity =>
            {
                entity.HasKey(e => e.IdDepartement)
                    .HasName("PK__Departem__1013779A23150A1C");

                entity.ToTable("Departement");

                entity.Property(e => e.IdDepartement)
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.CodeDeDistrict).HasColumnName("Code_de_District");

                entity.Property(e => e.NomDeDistcict)
                    .HasMaxLength(70)
                    .IsUnicode(false)
                    .HasColumnName("Nom_de_Distcict");

                entity.Property(e => e.NomDuDepartement)
                    .HasMaxLength(60)
                    .IsUnicode(false)
                    .HasColumnName("Nom_du_Departement");
            });

            modelBuilder.Entity<DomaineDeSpecialite>(entity =>
            {
                entity.HasKey(e => e.IdSpecialite)
                    .HasName("PK__Domaine___5C8D4E7CE6C8B6A3");

                entity.ToTable("Domaine_de_Specialite");

                entity.Property(e => e.IdSpecialite)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.IntituleDeSpecialite)
                    .HasMaxLength(75)
                    .IsUnicode(false)
                    .HasColumnName("Intitule_de_Specialite");
            });

            modelBuilder.Entity<Medecin>(entity =>
            {
                entity.HasKey(e => e.IdMedecin)
                    .HasName("PK__Medecin__8371CA437D4D118B");

                entity.ToTable("Medecin");

                entity.Property(e => e.IdMedecin)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.Adresse)
                    .HasMaxLength(150)
                    .IsUnicode(false);

                entity.Property(e => e.IdDepartement)
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.IdSpecialite)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.Nom)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.Prenom)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.HasOne(d => d.IdDepartementNavigation)
                    .WithMany(p => p.Medecins)
                    .HasForeignKey(d => d.IdDepartement)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__Medecin__IdDepar__3E52440B");

                entity.HasOne(d => d.IdSpecialiteNavigation)
                    .WithMany(p => p.Medecins)
                    .HasForeignKey(d => d.IdSpecialite)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__Medecin__IdSpeci__3D5E1FD2");
            });

            modelBuilder.Entity<User>(entity =>
            {
                entity.HasKey(e => e.IdUser)
                    .HasName("PK__Users__B7C92638F6A81760");

                entity.Property(e => e.IdUser)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.LoginUser)
                    .HasMaxLength(100)
                    .IsUnicode(false)
                    .HasColumnName("Login_User");

                entity.Property(e => e.PassewordUser)
                    .HasMaxLength(100)
                    .IsUnicode(false)
                    .HasColumnName("Passeword_User");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
