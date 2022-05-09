using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace ApiAppCuisine.entities
{
    public partial class DbAppContext : DbContext
    {
        public DbAppContext()
        {
        }

        public DbAppContext(DbContextOptions<DbAppContext> options)
            : base(options)
        {
        }

        public virtual DbSet<EtapeRecette> EtapeRecettes { get; set; } = null!;
        public virtual DbSet<ImageIngredient> ImageIngredients { get; set; } = null!;
        public virtual DbSet<ImageRecette> ImageRecettes { get; set; } = null!;
        public virtual DbSet<Ingredient> Ingredients { get; set; } = null!;
        public virtual DbSet<Recette> Recettes { get; set; } = null!;
        public virtual DbSet<RecetteIngrdient> RecetteIngrdients { get; set; } = null!;
        public virtual DbSet<RecetteUstencile> RecetteUstenciles { get; set; } = null!;
        public virtual DbSet<TypeRecette> TypeRecettes { get; set; } = null!;
        public virtual DbSet<User> Users { get; set; } = null!;
        public virtual DbSet<Ustensile> Ustensiles { get; set; } = null!;

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
                optionsBuilder.UseSqlServer("Server=.;Database=appcuisine;Trusted_Connection=True;");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<EtapeRecette>(entity =>
            {
                entity.HasKey(e => e.IdEtapeRecette)
                    .HasName("PK__Etape_re__F950140238C2D607");

                entity.HasOne(d => d.IdRecetteNavigation)
                    .WithMany(p => p.EtapeRecettes)
                    .HasForeignKey(d => d.IdRecette)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__Etape_rec__Id_Re__32E0915F");
            });

            modelBuilder.Entity<ImageIngredient>(entity =>
            {
                entity.HasKey(e => e.IdPhoto)
                    .HasName("PK__imageIng__96CEBB73B6F1572C");

                entity.HasOne(d => d.IdIngredientNavigation)
                    .WithMany(p => p.ImageIngredients)
                    .HasForeignKey(d => d.IdIngredient)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__imageIngr__Id_In__267ABA7A");
            });

            modelBuilder.Entity<ImageRecette>(entity =>
            {
                entity.HasKey(e => e.IdPhoto)
                    .HasName("PK__imageRec__96CEBB73B8AD92DF");

                entity.HasOne(d => d.IdRecetteNavigation)
                    .WithMany(p => p.ImageRecettes)
                    .HasForeignKey(d => d.IdRecette)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__imageRece__Id_Re__35BCFE0A");
            });

            modelBuilder.Entity<Ingredient>(entity =>
            {
                entity.HasKey(e => e.IdIngredient)
                    .HasName("PK__Ingredie__C39FEB495316A7C1");
            });

            modelBuilder.Entity<Recette>(entity =>
            {
                entity.HasKey(e => e.IdRecette)
                    .HasName("PK__Recette__24F2D524088812B2");

                entity.HasOne(d => d.IdTypeRecetteNavigation)
                    .WithMany(p => p.Recettes)
                    .HasForeignKey(d => d.IdTypeRecette)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__Recette__Id_Type__300424B4");

                entity.HasOne(d => d.IdUserNavigation)
                    .WithMany(p => p.Recettes)
                    .HasForeignKey(d => d.IdUser)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__Recette__Id_User__2F10007B");
            });

            modelBuilder.Entity<RecetteIngrdient>(entity =>
            {
                entity.HasKey(e => new { e.IdRecette, e.IdIngredient })
                    .HasName("PK__recette___A8CB2B906F5F0AF0");

                entity.HasOne(d => d.IdIngredientNavigation)
                    .WithMany(p => p.RecetteIngrdients)
                    .HasForeignKey(d => d.IdIngredient)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__recette_i__Id_In__398D8EEE");

                entity.HasOne(d => d.IdRecetteNavigation)
                    .WithMany(p => p.RecetteIngrdients)
                    .HasForeignKey(d => d.IdRecette)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__recette_i__Id_Re__38996AB5");
            });

            modelBuilder.Entity<RecetteUstencile>(entity =>
            {
                entity.HasKey(e => new { e.IdRecette, e.IdUstensiles })
                    .HasName("PK__recette___A419156A2CA4E614");

                entity.HasOne(d => d.IdRecetteNavigation)
                    .WithMany(p => p.RecetteUstenciles)
                    .HasForeignKey(d => d.IdRecette)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__recette_u__Id_Re__3C69FB99");

                entity.HasOne(d => d.IdUstensilesNavigation)
                    .WithMany(p => p.RecetteUstenciles)
                    .HasForeignKey(d => d.IdUstensiles)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__recette_u__Id_Us__3D5E1FD2");
            });

            modelBuilder.Entity<TypeRecette>(entity =>
            {
                entity.HasKey(e => e.IdTypeRecette)
                    .HasName("PK__Type_rec__45AEE2B314E6B368");
            });

            modelBuilder.Entity<User>(entity =>
            {
                entity.HasKey(e => e.IdUser)
                    .HasName("PK__Users__D03DEDCBD99F5BA1");
            });

            modelBuilder.Entity<Ustensile>(entity =>
            {
                entity.HasKey(e => e.IdUstensiles)
                    .HasName("PK__Ustensil__0EBC04E978D187AB");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
