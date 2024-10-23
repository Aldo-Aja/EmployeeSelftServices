using System;
using System.Collections.Generic;
using CrudIntern.Models.ESSEmployee;
using Microsoft.EntityFrameworkCore;

namespace CrudIntern.Services;

public partial class MyAppDbContext : DbContext
{
    public MyAppDbContext()
    {
    }

    public MyAppDbContext(DbContextOptions<MyAppDbContext> options)
        : base(options)
    {
    }

    public virtual DbSet<EBank> EBanks { get; set; }

    public virtual DbSet<ECity> ECities { get; set; }

    public virtual DbSet<ECostCenter> ECostCenters { get; set; }

    public virtual DbSet<ECountry> ECountries { get; set; }

    public virtual DbSet<EDepartment> EDepartments { get; set; }

    public virtual DbSet<EEducation> EEducations { get; set; }

    public virtual DbSet<EEmployeeStatus> EEmployeeStatuses { get; set; }

    public virtual DbSet<EGrade> EGrades { get; set; }

    public virtual DbSet<EGradeCategory> EGradeCategories { get; set; }

    public virtual DbSet<EHardshipLocation> EHardshipLocations { get; set; }

    public virtual DbSet<EInsurance> EInsurances { get; set; }

    public virtual DbSet<EMaritalStatus> EMaritalStatuses { get; set; }

    public virtual DbSet<ENationality> ENationalities { get; set; }

    public virtual DbSet<EOccupation> EOccupations { get; set; }

    public virtual DbSet<EPosition> EPositions { get; set; }

    public virtual DbSet<EProvince> EProvinces { get; set; }

    public virtual DbSet<ERelationship> ERelationships { get; set; }

    public virtual DbSet<EReligion> EReligions { get; set; }

    public virtual DbSet<ESection> ESections { get; set; }

    public virtual DbSet<EStatusOwner> EStatusOwners { get; set; }

    public virtual DbSet<EStayStatus> EStayStatuses { get; set; }

    public virtual DbSet<EUniversity> EUniversities { get; set; }

    public virtual DbSet<EWorkLocation> EWorkLocations { get; set; }

    public virtual DbSet<MAssigmentStatus> MAssigmentStatuses { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        => optionsBuilder.UseSqlServer("Name=ConnectionStrings:ConnEmplo");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.HasDefaultSchema("db_accessadmin");

        modelBuilder.Entity<EBank>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK_Banks");

            entity.ToTable("E_Banks", "dbo");

            entity.Property(e => e.Name)
                .HasMaxLength(255)
                .IsUnicode(false);
            entity.Property(e => e.Value)
                .HasMaxLength(255)
                .IsUnicode(false);
        });

        modelBuilder.Entity<ECity>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK_Cities");

            entity.ToTable("E_Cities", "dbo");

            entity.Property(e => e.Name)
                .HasMaxLength(255)
                .IsUnicode(false);
            entity.Property(e => e.Value)
                .HasMaxLength(255)
                .IsUnicode(false);

            entity.HasOne(d => d.Province).WithMany(p => p.ECities)
                .HasForeignKey(d => d.ProvinceId)
                .HasConstraintName("FK_Cities_Provinces");
        });

        modelBuilder.Entity<ECostCenter>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK_CostCenter");

            entity.ToTable("E_CostCenter", "dbo");

            entity.Property(e => e.Code)
                .HasMaxLength(255)
                .IsUnicode(false);
            entity.Property(e => e.CostCenter)
                .HasMaxLength(255)
                .IsUnicode(false);
            entity.Property(e => e.Name)
                .HasMaxLength(255)
                .IsUnicode(false);
        });

        modelBuilder.Entity<ECountry>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK_Countries");

            entity.ToTable("E_Countries", "dbo");

            entity.Property(e => e.IsoCode)
                .HasMaxLength(255)
                .IsUnicode(false)
                .HasColumnName("ISO_CODE");
            entity.Property(e => e.Name)
                .HasMaxLength(255)
                .IsUnicode(false);
            entity.Property(e => e.Value)
                .HasMaxLength(255)
                .IsUnicode(false);
        });

        modelBuilder.Entity<EDepartment>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK_Departments");

            entity.ToTable("E_Departments", "dbo");

            entity.Property(e => e.Code).IsUnicode(false);
            entity.Property(e => e.Name)
                .HasMaxLength(255)
                .IsUnicode(false);
            entity.Property(e => e.Value)
                .HasMaxLength(255)
                .IsUnicode(false);
        });

        modelBuilder.Entity<EEducation>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK_Educations");

            entity.ToTable("E_Educations", "dbo");

            entity.Property(e => e.Name)
                .HasMaxLength(255)
                .IsUnicode(false);
            entity.Property(e => e.Value)
                .HasMaxLength(255)
                .IsUnicode(false);
        });

        modelBuilder.Entity<EEmployeeStatus>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__E_Employ__3214EC0765619410");

            entity.ToTable("E_EmployeeStatus", "dbo");

            entity.Property(e => e.Name).IsUnicode(false);
            entity.Property(e => e.Value).IsUnicode(false);
        });

        modelBuilder.Entity<EGrade>(entity =>
        {
            entity.ToTable("E_Grade", "dbo");

            entity.HasIndex(e => e.Value, "UQ__E_Grade__07D9BBC2C3CC6944").IsUnique();

            entity.HasIndex(e => e.Value, "idx_ValueGrade");

            entity.Property(e => e.Name).IsUnicode(false);
            entity.Property(e => e.Value)
                .HasMaxLength(255)
                .IsUnicode(false);
        });

        modelBuilder.Entity<EGradeCategory>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__E_GradeC__3214EC073566F89A");

            entity.ToTable("E_GradeCategory", "dbo");

            entity.Property(e => e.Name).IsUnicode(false);
            entity.Property(e => e.Value).IsUnicode(false);
        });

        modelBuilder.Entity<EHardshipLocation>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__E_HardshipLocation");

            entity.ToTable("E_HardshipLocation", "dbo");

            entity.Property(e => e.Name)
                .HasMaxLength(200)
                .IsUnicode(false);
            entity.Property(e => e.Province)
                .HasMaxLength(200)
                .IsUnicode(false);
        });

        modelBuilder.Entity<EInsurance>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK_Insurances");

            entity.ToTable("E_Insurances", "dbo");

            entity.Property(e => e.Name)
                .HasMaxLength(255)
                .IsUnicode(false);
            entity.Property(e => e.Value)
                .HasMaxLength(255)
                .IsUnicode(false);
        });

        modelBuilder.Entity<EMaritalStatus>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK_MaritalStatus");

            entity.ToTable("E_MaritalStatus", "dbo");

            entity.Property(e => e.Name)
                .HasMaxLength(255)
                .IsUnicode(false);
            entity.Property(e => e.Value)
                .HasMaxLength(255)
                .IsUnicode(false);
        });

        modelBuilder.Entity<ENationality>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK_Nationalities");

            entity.ToTable("E_Nationalities", "dbo");

            entity.Property(e => e.Name)
                .HasMaxLength(255)
                .IsUnicode(false);
            entity.Property(e => e.Value)
                .HasMaxLength(255)
                .IsUnicode(false);
        });

        modelBuilder.Entity<EOccupation>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK_Occupations");

            entity.ToTable("E_Occupations", "dbo");

            entity.Property(e => e.Name)
                .HasMaxLength(255)
                .IsUnicode(false);
            entity.Property(e => e.Value)
                .HasMaxLength(255)
                .IsUnicode(false);
        });

        modelBuilder.Entity<EPosition>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__E_Positi__3214EC072CB345E1");

            entity.ToTable("E_Position", "dbo");

            entity.Property(e => e.Authorization).IsUnicode(false);
            entity.Property(e => e.Name).IsUnicode(false);
            entity.Property(e => e.Value).IsUnicode(false);
        });

        modelBuilder.Entity<EProvince>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK_Provinces");

            entity.ToTable("E_Provinces", "dbo");

            entity.Property(e => e.Name)
                .HasMaxLength(255)
                .IsUnicode(false);
            entity.Property(e => e.Value)
                .HasMaxLength(255)
                .IsUnicode(false);

            entity.HasOne(d => d.Country).WithMany(p => p.EProvinces)
                .HasForeignKey(d => d.CountryId)
                .HasConstraintName("FK_Provinces_Countries");
        });

        modelBuilder.Entity<ERelationship>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__E_Relati__3214EC0737BDD449");

            entity.ToTable("E_Relationship", "dbo");

            entity.Property(e => e.Name).IsUnicode(false);
            entity.Property(e => e.Value).IsUnicode(false);
        });

        modelBuilder.Entity<EReligion>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK_Religions");

            entity.ToTable("E_Religions", "dbo");

            entity.Property(e => e.Name)
                .HasMaxLength(255)
                .IsUnicode(false);
            entity.Property(e => e.Value)
                .HasMaxLength(255)
                .IsUnicode(false);
        });

        modelBuilder.Entity<ESection>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__E_Sectio__3214EC077A9E0451");

            entity.ToTable("E_Sections", "dbo");

            entity.Property(e => e.Code).IsUnicode(false);
            entity.Property(e => e.Name)
                .HasMaxLength(255)
                .IsUnicode(false);
            entity.Property(e => e.Value)
                .HasMaxLength(255)
                .IsUnicode(false);

            entity.HasOne(d => d.Department).WithMany(p => p.ESections)
                .HasForeignKey(d => d.DepartmentId)
                .HasConstraintName("FK_Section_Department");
        });

        modelBuilder.Entity<EStatusOwner>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK_StatusOwner");

            entity.ToTable("E_StatusOwner", "dbo");

            entity.Property(e => e.Name)
                .HasMaxLength(255)
                .IsUnicode(false);
            entity.Property(e => e.Value)
                .HasMaxLength(255)
                .IsUnicode(false);
        });

        modelBuilder.Entity<EStayStatus>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK_StayStatus");

            entity.ToTable("E_StayStatus", "dbo");

            entity.Property(e => e.Name)
                .HasMaxLength(255)
                .IsUnicode(false);
            entity.Property(e => e.Value)
                .HasMaxLength(255)
                .IsUnicode(false);
        });

        modelBuilder.Entity<EUniversity>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK_Universities");

            entity.ToTable("E_Universities", "dbo");

            entity.Property(e => e.Name)
                .HasMaxLength(255)
                .IsUnicode(false);
            entity.Property(e => e.Value)
                .HasMaxLength(255)
                .IsUnicode(false);
        });

        modelBuilder.Entity<EWorkLocation>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__E_WorkLo__3214EC07710D254F");

            entity.ToTable("E_WorkLocation", "dbo");

            entity.Property(e => e.Name).IsUnicode(false);
            entity.Property(e => e.Value).IsUnicode(false);
        });

        modelBuilder.Entity<MAssigmentStatus>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__M_Assigm__3214EC073284038D");

            entity.ToTable("M_AssigmentStatus", "dbo");

            entity.Property(e => e.Name)
                .HasMaxLength(255)
                .IsUnicode(false);
            entity.Property(e => e.Value)
                .HasMaxLength(255)
                .IsUnicode(false);
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
