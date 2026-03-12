using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using WebApplication1.Models;

namespace WebApplication1.Contexts;

public partial class MainContext : DbContext
{
    public MainContext()
    {
    }

    public MainContext(DbContextOptions<MainContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Asset> Assets { get; set; }

    public virtual DbSet<AssetGroup> AssetGroups { get; set; }

    public virtual DbSet<AssetPhoto> AssetPhotos { get; set; }

    public virtual DbSet<AssetTransferLog> AssetTransferLogs { get; set; }

    public virtual DbSet<Department> Departments { get; set; }

    public virtual DbSet<DepartmentLocation> DepartmentLocations { get; set; }

    public virtual DbSet<Employee> Employees { get; set; }

    public virtual DbSet<Image> Images { get; set; }

    public virtual DbSet<Location> Locations { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see https://go.microsoft.com/fwlink/?LinkId=723263.
        => optionsBuilder.UseSqlServer("Data Source=(localdb)\\MSSQLLocalDB; Initial Catalog=Session1; Integrated Security=True; TrustServerCertificate=True");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Asset>(entity =>
        {
            entity.Property(e => e.Id).HasColumnName("ID");
            entity.Property(e => e.AssetGroupId).HasColumnName("AssetGroupID");
            entity.Property(e => e.AssetName).HasMaxLength(150);
            entity.Property(e => e.AssetSn)
                .HasMaxLength(20)
                .HasColumnName("AssetSN");
            entity.Property(e => e.DepartmentLocationId).HasColumnName("DepartmentLocationID");
            entity.Property(e => e.Description).HasMaxLength(2000);
            entity.Property(e => e.EmployeeId).HasColumnName("EmployeeID");

            entity.HasOne(d => d.AssetGroup).WithMany(p => p.Assets)
                .HasForeignKey(d => d.AssetGroupId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Assets_AssetGroups");

            entity.HasOne(d => d.DepartmentLocation).WithMany(p => p.Assets)
                .HasForeignKey(d => d.DepartmentLocationId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Assets_DepartmentLocations");

            entity.HasOne(d => d.Employee).WithMany(p => p.Assets)
                .HasForeignKey(d => d.EmployeeId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Assets_Employees");
        });

        modelBuilder.Entity<AssetGroup>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK_AssetTypes");

            entity.Property(e => e.Id).HasColumnName("ID");
            entity.Property(e => e.Name).HasMaxLength(50);
        });

        modelBuilder.Entity<AssetPhoto>(entity =>
        {
            entity.Property(e => e.Id).HasColumnName("ID");
            entity.Property(e => e.AssetId).HasColumnName("AssetID");
            entity.Property(e => e.AssetPhoto1).HasColumnName("AssetPhoto");

            entity.HasOne(d => d.Asset).WithMany(p => p.AssetPhotos)
                .HasForeignKey(d => d.AssetId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_AssetPhotos_Assets");
        });

        modelBuilder.Entity<AssetTransferLog>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK_AssetRelocationLogs");

            entity.Property(e => e.Id).HasColumnName("ID");
            entity.Property(e => e.AssetId).HasColumnName("AssetID");
            entity.Property(e => e.FromAssetSn)
                .HasMaxLength(20)
                .HasColumnName("FromAssetSN");
            entity.Property(e => e.FromDepartmentLocationId).HasColumnName("FromDepartmentLocationID");
            entity.Property(e => e.ToAssetSn)
                .HasMaxLength(20)
                .HasColumnName("ToAssetSN");
            entity.Property(e => e.ToDepartmentLocationId).HasColumnName("ToDepartmentLocationID");

            entity.HasOne(d => d.Asset).WithMany(p => p.AssetTransferLogs)
                .HasForeignKey(d => d.AssetId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_AssetTransfers_Assets");

            entity.HasOne(d => d.FromDepartmentLocation).WithMany(p => p.AssetTransferLogFromDepartmentLocations)
                .HasForeignKey(d => d.FromDepartmentLocationId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_AssetTransferLogs_DepartmentLocations");

            entity.HasOne(d => d.ToDepartmentLocation).WithMany(p => p.AssetTransferLogToDepartmentLocations)
                .HasForeignKey(d => d.ToDepartmentLocationId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_AssetTransferLogs_DepartmentLocations1");
        });

        modelBuilder.Entity<Department>(entity =>
        {
            entity.Property(e => e.Id).HasColumnName("ID");
            entity.Property(e => e.Name).HasMaxLength(100);
        });

        modelBuilder.Entity<DepartmentLocation>(entity =>
        {
            entity.Property(e => e.Id).HasColumnName("ID");
            entity.Property(e => e.DepartmentId).HasColumnName("DepartmentID");
            entity.Property(e => e.LocationId).HasColumnName("LocationID");

            entity.HasOne(d => d.Department).WithMany(p => p.DepartmentLocations)
                .HasForeignKey(d => d.DepartmentId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_DepartmentLocations_Departments");

            entity.HasOne(d => d.Location).WithMany(p => p.DepartmentLocations)
                .HasForeignKey(d => d.LocationId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_DepartmentLocations_Locations");
        });

        modelBuilder.Entity<Employee>(entity =>
        {
            entity.Property(e => e.Id).HasColumnName("ID");
            entity.Property(e => e.FirstName).HasMaxLength(50);
            entity.Property(e => e.LastName).HasMaxLength(50);
            entity.Property(e => e.Phone).HasMaxLength(50);
        });

        modelBuilder.Entity<Image>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__Images__3214EC07F0EBB106");

            entity.Property(e => e.Id).ValueGeneratedNever();
            entity.Property(e => e.ContentType)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.Name).HasMaxLength(200);
        });

        modelBuilder.Entity<Location>(entity =>
        {
            entity.Property(e => e.Id).HasColumnName("ID");
            entity.Property(e => e.Name).HasMaxLength(100);
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
