using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace YMTDotNetTrainingBatch2.DB.AppDbContextModels;

public partial class AppDbContext : DbContext
{
    public AppDbContext()
    {
    }

    public AppDbContext(DbContextOptions<AppDbContext> options)
        : base(options)
    {
    }

    public virtual DbSet<TblProduct> TblProducts { get; set; }

    public virtual DbSet<TblSalesDetail> TblSalesDetails { get; set; }

    public virtual DbSet<TblSalesSummary> TblSalesSummaries { get; set; }

    public virtual DbSet<TblStaff> TblStaffs { get; set; }

    
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<TblProduct>(entity =>
        {
            entity.HasKey(e => e.ProductId);

            entity.ToTable("Tbl_Products");

            entity.Property(e => e.Price).HasColumnType("decimal(10, 2)");
            entity.Property(e => e.ProductName)
                .HasMaxLength(50)
                .IsUnicode(false);
        });

        modelBuilder.Entity<TblSalesDetail>(entity =>
        {
            entity.HasKey(e => e.SaleDetailId).HasName("PK_Tbl_SaleDetails");

            entity.ToTable("Tbl_SalesDetails");

            entity.Property(e => e.SaleDetailId).HasColumnName("SaleDetail_Id");
            entity.Property(e => e.Price).HasColumnType("decimal(10, 2)");
            entity.Property(e => e.Quantity).HasColumnType("decimal(10, 3)");
        });

        modelBuilder.Entity<TblSalesSummary>(entity =>
        {
            entity.HasKey(e => e.SaleId);

            entity.ToTable("Tbl_SalesSummary");

            entity.Property(e => e.Date).HasColumnType("datetime");
            entity.Property(e => e.TotalAmount).HasColumnType("decimal(10, 2)");
            entity.Property(e => e.VoucherId)
                .HasMaxLength(50)
                .IsUnicode(false);
        });

        modelBuilder.Entity<TblStaff>(entity =>
        {
            entity.HasKey(e => e.StaffId);

            entity.ToTable("Tbl_Staff");

            entity.Property(e => e.EmailAddress)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("emailAddress");
            entity.Property(e => e.MobileNo)
                .HasMaxLength(20)
                .IsUnicode(false);
            entity.Property(e => e.Password)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.Position)
                .HasMaxLength(100)
                .IsUnicode(false);
            entity.Property(e => e.StaffCode)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.StaffName)
                .HasMaxLength(50)
                .IsUnicode(false);
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
