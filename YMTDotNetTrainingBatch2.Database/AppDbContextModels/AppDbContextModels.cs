using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace YMTDotNetTrainingBatch2.Database.AppDbContextModels;

public partial class AppDbContextModels : DbContext
{
    public AppDbContextModels()
    {
    }

    public AppDbContextModels(DbContextOptions<AppDbContextModels> options)
        : base(options)
    {
    }

    public virtual DbSet<TblProduct> TblProducts { get; set; }

    public virtual DbSet<TblSalesDetail> TblSalesDetails { get; set; }

    public virtual DbSet<TblSalesSummary> TblSalesSummaries { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see https://go.microsoft.com/fwlink/?LinkId=723263.
        => optionsBuilder.UseSqlServer("Data Source=.;Initial Catalog=MiniPOS;User ID=sa;Password=sasa@123;Trust Server Certificate=True");

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

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
