using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace projectStore.Models;

public partial class SouqContext : DbContext
{
    public SouqContext()
    {
    }

    public SouqContext(DbContextOptions<SouqContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Card> Cards { get; set; }

    public virtual DbSet<Catigory> Catigories { get; set; }

    public virtual DbSet<Product> Products { get; set; }

    public virtual DbSet<Reviw> Reviws { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see https://go.microsoft.com/fwlink/?LinkId=723263.
        => optionsBuilder.UseSqlServer("Server=ABANI;User Id=sa;Password=123456;Database=souq;TrustServerCertificate=true;");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Card>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__Card__3213E83F0BA7D4DE");

            entity.ToTable("Card");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.Countity).HasColumnName("countity");
            entity.Property(e => e.ProductId).HasColumnName("product_id");
            entity.Property(e => e.Userid)
                .HasMaxLength(50)
                .HasColumnName("userid");

            entity.HasOne(d => d.Product).WithMany(p => p.Cards)
                .HasForeignKey(d => d.ProductId)
                .HasConstraintName("FK_Card_Product");
        });

        modelBuilder.Entity<Catigory>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__Catigory__3213E83F9ABEB62C");

            entity.ToTable("Catigory");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.Name).HasMaxLength(50);
            entity.Property(e => e.Photo).HasColumnName("photo");
        });

        modelBuilder.Entity<Product>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__Product__3213E83F5352BFB5");

            entity.ToTable("Product");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.CatId).HasColumnName("cat_id");
            entity.Property(e => e.Name).HasMaxLength(50);
            entity.Property(e => e.Photo).HasColumnName("photo");

            entity.HasOne(d => d.Cat).WithMany(p => p.Products)
                .HasForeignKey(d => d.CatId)
                .HasConstraintName("FK_Product_Catigory");
        });

        modelBuilder.Entity<Reviw>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__reviw__3213E83F61BFE8D5");

            entity.ToTable("reviw");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.Email).HasMaxLength(100);
            entity.Property(e => e.Name).HasMaxLength(50);
            entity.Property(e => e.Subject).HasColumnName("subject");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
