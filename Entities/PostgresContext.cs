using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace GGExam.Entities;

public partial class PostgresContext : DbContext
{
    public PostgresContext()
    {
    }

    public PostgresContext(DbContextOptions<PostgresContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Category> Categories { get; set; }

    public virtual DbSet<Employeer> Employeers { get; set; }

    public virtual DbSet<Gender> Genders { get; set; }

    public virtual DbSet<Order> Orders { get; set; }

    public virtual DbSet<Product> Products { get; set; }

    public virtual DbSet<Status> Statuses { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see https://go.microsoft.com/fwlink/?LinkId=723263.
        => optionsBuilder.UseNpgsql("host=localhost;port=5432;database=postgres;username=postgres");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Category>(entity =>
        {
            entity.HasKey(e => e.Categoryid).HasName("category_pkey");

            entity.ToTable("category");

            entity.Property(e => e.Categoryid).HasColumnName("categoryid");
            entity.Property(e => e.Name)
                .HasMaxLength(100)
                .HasColumnName("name");
        });

        modelBuilder.Entity<Employeer>(entity =>
        {
            entity.HasKey(e => e.Employeeid).HasName("employeers_pkey");

            entity.ToTable("employeers");

            entity.Property(e => e.Employeeid).HasColumnName("employeeid");
            entity.Property(e => e.Adres)
                .HasMaxLength(100)
                .HasColumnName("adres");
            entity.Property(e => e.Birthday).HasColumnName("birthday");
            entity.Property(e => e.Email)
                .HasMaxLength(100)
                .HasColumnName("email");
            entity.Property(e => e.Fio)
                .HasMaxLength(100)
                .HasColumnName("fio");
            entity.Property(e => e.Tel)
                .HasMaxLength(100)
                .HasColumnName("tel");
        });

        modelBuilder.Entity<Gender>(entity =>
        {
            entity.HasKey(e => e.Genderid).HasName("genders_pkey");

            entity.ToTable("genders");

            entity.Property(e => e.Genderid).HasColumnName("genderid");
            entity.Property(e => e.Name)
                .HasMaxLength(100)
                .HasColumnName("name");
        });

        modelBuilder.Entity<Order>(entity =>
        {
            entity.HasKey(e => e.Orderid).HasName("orders_pkey");

            entity.ToTable("orders");

            entity.Property(e => e.Orderid).HasColumnName("orderid");
            entity.Property(e => e.Discount)
                .HasMaxLength(100)
                .HasColumnName("discount");
            entity.Property(e => e.Email)
                .HasMaxLength(100)
                .HasColumnName("email");
            entity.Property(e => e.Fio)
                .HasMaxLength(100)
                .HasColumnName("fio");
            entity.Property(e => e.Genderid).HasColumnName("genderid");
            entity.Property(e => e.ProductsId).HasColumnName("products_id");
            entity.Property(e => e.Quantity).HasColumnName("quantity");
            entity.Property(e => e.StatusId).HasColumnName("status_id");
            entity.Property(e => e.Tel)
                .HasMaxLength(100)
                .HasColumnName("tel");

            entity.HasOne(d => d.Gender).WithMany(p => p.Orders)
                .HasForeignKey(d => d.Genderid)
                .HasConstraintName("orders_genderid_fkey");

            entity.HasOne(d => d.Products).WithMany(p => p.Orders)
                .HasForeignKey(d => d.ProductsId)
                .HasConstraintName("orders_products_id_fkey");

            entity.HasOne(d => d.Status).WithMany(p => p.Orders)
                .HasForeignKey(d => d.StatusId)
                .HasConstraintName("orders_status_id_fkey");
        });

        modelBuilder.Entity<Product>(entity =>
        {
            entity.HasKey(e => e.Productid).HasName("products_pkey");

            entity.ToTable("products");

            entity.Property(e => e.Productid).HasColumnName("productid");
            entity.Property(e => e.Article)
                .HasMaxLength(100)
                .HasColumnName("article");
            entity.Property(e => e.BestBeforeDate).HasColumnName("best_before_date");
            entity.Property(e => e.Categoryid).HasColumnName("categoryid");
            entity.Property(e => e.CountryProduct)
                .HasMaxLength(100)
                .HasColumnName("country_product");
            entity.Property(e => e.Data).HasColumnName("data");
            entity.Property(e => e.Firm)
                .HasMaxLength(100)
                .HasColumnName("firm");
            entity.Property(e => e.Name)
                .HasMaxLength(100)
                .HasColumnName("name");
            entity.Property(e => e.Price).HasColumnName("price");

            entity.HasOne(d => d.Category).WithMany(p => p.Products)
                .HasForeignKey(d => d.Categoryid)
                .HasConstraintName("products_categoryid_fkey");
        });

        modelBuilder.Entity<Status>(entity =>
        {
            entity.HasKey(e => e.Statusid).HasName("status_pkey");

            entity.ToTable("status");

            entity.Property(e => e.Statusid).HasColumnName("statusid");
            entity.Property(e => e.Name)
                .HasMaxLength(100)
                .HasColumnName("name");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
