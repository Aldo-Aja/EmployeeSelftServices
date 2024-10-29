using System;
using System.Collections.Generic;
using CrudIntern.Models.ESSFinance;
using Microsoft.EntityFrameworkCore;

namespace CrudIntern.Services;

public partial class FinanceDbContext : DbContext
{
    public FinanceDbContext()
    {
    }

    public FinanceDbContext(DbContextOptions<FinanceDbContext> options)
        : base(options)
    {
    }

    public virtual DbSet<MAttnCustomer> MAttnCustomers { get; set; }

    public virtual DbSet<MBankingRoutingCode> MBankingRoutingCodes { get; set; }

    public virtual DbSet<MBenefitGradeConfig> MBenefitGradeConfigs { get; set; }

    public virtual DbSet<MConfigApprovalGeneralInformation> MConfigApprovalGeneralInformations { get; set; }

    public virtual DbSet<MConfigApprovalVendorCriterion> MConfigApprovalVendorCriteria { get; set; }

    public virtual DbSet<MCustomer> MCustomers { get; set; }

    public virtual DbSet<MDataBank> MDataBanks { get; set; }

    public virtual DbSet<MKmsiBank> MKmsiBanks { get; set; }

    public virtual DbSet<MPayTo> MPayTos { get; set; }

    public virtual DbSet<MPointingActivity> MPointingActivities { get; set; }

    public virtual DbSet<MSupplier> MSuppliers { get; set; }

    public virtual DbSet<MTarifWht> MTarifWhts { get; set; }

    public virtual DbSet<MTypeWht> MTypeWhts { get; set; }

    public virtual DbSet<MVat> MVats { get; set; }

    public virtual DbSet<VsTOldVendor> VsTOldVendors { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        => optionsBuilder.UseSqlServer("Name=ConnFinn");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.HasDefaultSchema("db_accessadmin");

        modelBuilder.Entity<MAttnCustomer>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK_AttnCustomer");

            entity.ToTable("M_AttnCustomer", "dbo");

            entity.Property(e => e.AttnName).IsUnicode(false);
            entity.Property(e => e.BpCode).IsUnicode(false);
            entity.Property(e => e.Description).IsUnicode(false);
            entity.Property(e => e.Email).IsUnicode(false);
        });

        modelBuilder.Entity<MBankingRoutingCode>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__M_Bankin__3214EC0721CAD373");

            entity.ToTable("M_BankingRoutingCode", "dbo");

            entity.Property(e => e.BankName)
                .HasMaxLength(255)
                .IsUnicode(false);
            entity.Property(e => e.RoutingCode)
                .HasMaxLength(255)
                .IsUnicode(false);
        });

        modelBuilder.Entity<MBenefitGradeConfig>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK_M_BenefitConfig");

            entity.ToTable("M_BenefitGradeConfig", "dbo");

            entity.Property(e => e.ConfigType).IsUnicode(false);
            entity.Property(e => e.Cop).HasColumnName("COP");
            entity.Property(e => e.Grade).IsUnicode(false);
        });

        modelBuilder.Entity<MConfigApprovalGeneralInformation>(entity =>
        {
            entity.ToTable("M_ConfigApprovalGeneralInformation", "dbo");

            entity.Property(e => e.ApprovalType)
                .HasMaxLength(200)
                .IsUnicode(false);
            entity.Property(e => e.DepartmentName)
                .HasMaxLength(200)
                .IsUnicode(false);
            entity.Property(e => e.Name).IsUnicode(false);
            entity.Property(e => e.Nrp).IsUnicode(false);
        });

        modelBuilder.Entity<MConfigApprovalVendorCriterion>(entity =>
        {
            entity.ToTable("M_ConfigApprovalVendorCriteria", "dbo");

            entity.Property(e => e.ApprovalType)
                .HasMaxLength(200)
                .IsUnicode(false);
            entity.Property(e => e.DepartmentName)
                .HasMaxLength(200)
                .IsUnicode(false);
            entity.Property(e => e.Name).IsUnicode(false);
            entity.Property(e => e.Nrp).IsUnicode(false);
        });

        modelBuilder.Entity<MCustomer>(entity =>
        {
            entity.ToTable("M_Customer", "dbo");

            entity.Property(e => e.AccountNum)
                .HasMaxLength(255)
                .IsUnicode(false);
            entity.Property(e => e.ActivityType)
                .HasMaxLength(225)
                .IsUnicode(false);
            entity.Property(e => e.App1)
                .HasMaxLength(255)
                .IsUnicode(false);
            entity.Property(e => e.App2)
                .HasMaxLength(255)
                .IsUnicode(false);
            entity.Property(e => e.App3)
                .HasMaxLength(255)
                .IsUnicode(false);
            entity.Property(e => e.App4)
                .HasMaxLength(255)
                .IsUnicode(false);
            entity.Property(e => e.App5)
                .HasMaxLength(255)
                .IsUnicode(false);
            entity.Property(e => e.AppDate1).HasColumnType("datetime");
            entity.Property(e => e.AppDate2).HasColumnType("datetime");
            entity.Property(e => e.AppDate3).HasColumnType("datetime");
            entity.Property(e => e.AppDate4).HasColumnType("datetime");
            entity.Property(e => e.AppDate5).HasColumnType("datetime");
            entity.Property(e => e.AppName1)
                .HasMaxLength(255)
                .IsUnicode(false);
            entity.Property(e => e.AppName2)
                .HasMaxLength(255)
                .IsUnicode(false);
            entity.Property(e => e.AppName3)
                .HasMaxLength(255)
                .IsUnicode(false);
            entity.Property(e => e.AppName4)
                .HasMaxLength(255)
                .IsUnicode(false);
            entity.Property(e => e.AppName5)
                .HasMaxLength(255)
                .IsUnicode(false);
            entity.Property(e => e.AppStatus1)
                .HasMaxLength(255)
                .IsUnicode(false);
            entity.Property(e => e.AppStatus2)
                .HasMaxLength(255)
                .IsUnicode(false);
            entity.Property(e => e.AppStatus3)
                .HasMaxLength(255)
                .IsUnicode(false);
            entity.Property(e => e.AppStatus4)
                .HasMaxLength(255)
                .IsUnicode(false);
            entity.Property(e => e.AppStatus5)
                .HasMaxLength(255)
                .IsUnicode(false);
            entity.Property(e => e.BankCode)
                .HasMaxLength(255)
                .IsUnicode(false);
            entity.Property(e => e.BankCountry)
                .HasMaxLength(255)
                .IsUnicode(false);
            entity.Property(e => e.BeneFiciaryAccount)
                .HasMaxLength(255)
                .IsUnicode(false);
            entity.Property(e => e.BeneFiciaryAddress)
                .HasMaxLength(255)
                .IsUnicode(false);
            entity.Property(e => e.BeneFiciaryName)
                .HasMaxLength(255)
                .IsUnicode(false);
            entity.Property(e => e.BeneficiaryBank)
                .HasMaxLength(255)
                .IsUnicode(false);
            entity.Property(e => e.BeneficiaryBankBranch)
                .HasMaxLength(255)
                .IsUnicode(false);
            entity.Property(e => e.BeneficiaryType)
                .HasMaxLength(255)
                .IsUnicode(false);
            entity.Property(e => e.BillingEmail)
                .HasMaxLength(255)
                .IsUnicode(false);
            entity.Property(e => e.BillingName)
                .HasMaxLength(225)
                .IsUnicode(false);
            entity.Property(e => e.BillingPhone)
                .HasMaxLength(255)
                .IsUnicode(false);
            entity.Property(e => e.BpCode)
                .HasMaxLength(255)
                .IsUnicode(false);
            entity.Property(e => e.City)
                .HasMaxLength(255)
                .IsUnicode(false);
            entity.Property(e => e.Clasify)
                .HasMaxLength(255)
                .IsUnicode(false);
            entity.Property(e => e.Country)
                .HasMaxLength(255)
                .IsUnicode(false);
            entity.Property(e => e.CreatedAt).HasColumnType("datetime");
            entity.Property(e => e.Currency)
                .HasMaxLength(225)
                .IsUnicode(false);
            entity.Property(e => e.CustomerReference)
                .HasMaxLength(255)
                .IsUnicode(false);
            entity.Property(e => e.CustomerReferenceBaanwf)
                .HasMaxLength(255)
                .IsUnicode(false);
            entity.Property(e => e.CustomerRemark)
                .HasMaxLength(255)
                .IsUnicode(false);
            entity.Property(e => e.CustomerRequestType)
                .HasMaxLength(255)
                .IsUnicode(false);
            entity.Property(e => e.CustomerType)
                .HasMaxLength(255)
                .IsUnicode(false);
            entity.Property(e => e.Email)
                .HasMaxLength(255)
                .IsUnicode(false);
            entity.Property(e => e.Location)
                .HasMaxLength(200)
                .IsUnicode(false);
            entity.Property(e => e.MarketingEmail)
                .HasMaxLength(255)
                .IsUnicode(false);
            entity.Property(e => e.MarketingName)
                .HasMaxLength(225)
                .IsUnicode(false);
            entity.Property(e => e.MarketingPhone)
                .HasMaxLength(255)
                .IsUnicode(false);
            entity.Property(e => e.NpwpNumber)
                .HasMaxLength(255)
                .IsUnicode(false);
            entity.Property(e => e.Nrp)
                .HasMaxLength(255)
                .IsUnicode(false);
            entity.Property(e => e.PaymentType)
                .HasMaxLength(255)
                .IsUnicode(false);
            entity.Property(e => e.PengusahaKenaPajak)
                .HasMaxLength(255)
                .IsUnicode(false);
            entity.Property(e => e.Phone)
                .HasMaxLength(255)
                .IsUnicode(false);
            entity.Property(e => e.PostalCode)
                .HasMaxLength(255)
                .IsUnicode(false);
            entity.Property(e => e.RejectReason1)
                .HasMaxLength(255)
                .IsUnicode(false);
            entity.Property(e => e.RejectReason2)
                .HasMaxLength(255)
                .IsUnicode(false);
            entity.Property(e => e.RejectReason3)
                .HasMaxLength(255)
                .IsUnicode(false);
            entity.Property(e => e.RejectReason4)
                .HasMaxLength(255)
                .IsUnicode(false);
            entity.Property(e => e.RejectReason5)
                .HasMaxLength(255)
                .IsUnicode(false);
            entity.Property(e => e.RemittingCurrency)
                .HasMaxLength(255)
                .IsUnicode(false);
            entity.Property(e => e.Resident)
                .HasMaxLength(255)
                .IsUnicode(false);
            entity.Property(e => e.SettlementAccount)
                .HasMaxLength(255)
                .IsUnicode(false);
            entity.Property(e => e.Status)
                .HasMaxLength(255)
                .IsUnicode(false);
            entity.Property(e => e.TableConnectId)
                .HasMaxLength(255)
                .IsUnicode(false);
            entity.Property(e => e.TaxesEmail)
                .HasMaxLength(255)
                .IsUnicode(false);
            entity.Property(e => e.TaxesPhone)
                .HasMaxLength(255)
                .IsUnicode(false);
            entity.Property(e => e.TaxsName)
                .HasMaxLength(225)
                .IsUnicode(false);
            entity.Property(e => e.TempAccountNum)
                .HasMaxLength(255)
                .IsUnicode(false);
            entity.Property(e => e.TempBankCode)
                .HasMaxLength(255)
                .IsUnicode(false);
            entity.Property(e => e.TempBankCountry)
                .HasMaxLength(255)
                .IsUnicode(false);
            entity.Property(e => e.TempBeneFiciaryAccount)
                .HasMaxLength(255)
                .IsUnicode(false);
            entity.Property(e => e.TempBeneFiciaryAddress)
                .HasMaxLength(255)
                .IsUnicode(false);
            entity.Property(e => e.TempBeneFiciaryName)
                .HasMaxLength(255)
                .IsUnicode(false);
            entity.Property(e => e.TempBeneficiaryBank)
                .HasMaxLength(255)
                .IsUnicode(false);
            entity.Property(e => e.TempBeneficiaryType)
                .HasMaxLength(255)
                .IsUnicode(false);
            entity.Property(e => e.TempBillingEmail)
                .HasMaxLength(255)
                .IsUnicode(false);
            entity.Property(e => e.TempBillingPhone)
                .HasMaxLength(255)
                .IsUnicode(false);
            entity.Property(e => e.TempBpCode)
                .HasMaxLength(255)
                .IsUnicode(false);
            entity.Property(e => e.TempCity)
                .HasMaxLength(255)
                .IsUnicode(false);
            entity.Property(e => e.TempClasify)
                .HasMaxLength(255)
                .IsUnicode(false);
            entity.Property(e => e.TempCountry)
                .HasMaxLength(255)
                .IsUnicode(false);
            entity.Property(e => e.TempCreatedAt).HasColumnType("datetime");
            entity.Property(e => e.TempCustomerReference)
                .HasMaxLength(255)
                .IsUnicode(false);
            entity.Property(e => e.TempCustomerReferenceBaanwf)
                .HasMaxLength(255)
                .IsUnicode(false);
            entity.Property(e => e.TempCustomerRemark)
                .HasMaxLength(255)
                .IsUnicode(false);
            entity.Property(e => e.TempCustomerRequestType)
                .HasMaxLength(255)
                .IsUnicode(false);
            entity.Property(e => e.TempCustomerType)
                .HasMaxLength(255)
                .IsUnicode(false);
            entity.Property(e => e.TempEmail)
                .HasMaxLength(255)
                .IsUnicode(false);
            entity.Property(e => e.TempLocation)
                .HasMaxLength(200)
                .IsUnicode(false);
            entity.Property(e => e.TempMarketingEmail)
                .HasMaxLength(255)
                .IsUnicode(false);
            entity.Property(e => e.TempMarketingPhone)
                .HasMaxLength(255)
                .IsUnicode(false);
            entity.Property(e => e.TempNpwpNumber)
                .HasMaxLength(255)
                .IsUnicode(false);
            entity.Property(e => e.TempPaymentType)
                .HasMaxLength(255)
                .IsUnicode(false);
            entity.Property(e => e.TempPengusahaKenaPajak)
                .HasMaxLength(255)
                .IsUnicode(false);
            entity.Property(e => e.TempPhone)
                .HasMaxLength(255)
                .IsUnicode(false);
            entity.Property(e => e.TempPostalCode)
                .HasMaxLength(255)
                .IsUnicode(false);
            entity.Property(e => e.TempRemittingCurrency)
                .HasMaxLength(255)
                .IsUnicode(false);
            entity.Property(e => e.TempResident)
                .HasMaxLength(255)
                .IsUnicode(false);
            entity.Property(e => e.TempSettlementAccount)
                .HasMaxLength(255)
                .IsUnicode(false);
            entity.Property(e => e.TempTableConnectId)
                .HasMaxLength(255)
                .IsUnicode(false);
            entity.Property(e => e.TempTaxesEmail)
                .HasMaxLength(255)
                .IsUnicode(false);
            entity.Property(e => e.TempTaxesPhone)
                .HasMaxLength(255)
                .IsUnicode(false);
            entity.Property(e => e.TempTransactionType)
                .HasMaxLength(255)
                .IsUnicode(false);
            entity.Property(e => e.TempUpdateAt).HasColumnType("datetime");
            entity.Property(e => e.TransactionType)
                .HasMaxLength(255)
                .IsUnicode(false);
            entity.Property(e => e.Type)
                .HasMaxLength(255)
                .IsUnicode(false);
            entity.Property(e => e.UpdateAt).HasColumnType("datetime");
        });

        modelBuilder.Entity<MDataBank>(entity =>
        {
            entity.ToTable("M_DataBank", "dbo");

            entity.Property(e => e.BankAddress)
                .HasMaxLength(200)
                .IsUnicode(false);
            entity.Property(e => e.BankCity)
                .HasMaxLength(200)
                .IsUnicode(false);
            entity.Property(e => e.BankCode)
                .HasMaxLength(200)
                .IsUnicode(false);
            entity.Property(e => e.BankName)
                .HasMaxLength(200)
                .IsUnicode(false);
            entity.Property(e => e.BeneficiaryAccount)
                .HasMaxLength(200)
                .IsUnicode(false);
            entity.Property(e => e.BeneficiaryAddress1)
                .HasMaxLength(200)
                .IsUnicode(false);
            entity.Property(e => e.BeneficiaryAddress2)
                .HasMaxLength(200)
                .IsUnicode(false);
            entity.Property(e => e.BeneficiaryAddress3)
                .HasMaxLength(200)
                .IsUnicode(false);
            entity.Property(e => e.BeneficiaryCurrency)
                .HasMaxLength(200)
                .IsUnicode(false);
            entity.Property(e => e.BeneficiaryEmailAddress)
                .HasMaxLength(200)
                .IsUnicode(false);
            entity.Property(e => e.BeneficiaryName)
                .HasMaxLength(200)
                .IsUnicode(false);
            entity.Property(e => e.Branch)
                .HasMaxLength(200)
                .IsUnicode(false);
            entity.Property(e => e.CostCenter).IsUnicode(false);
            entity.Property(e => e.CustomerReferenceNumber)
                .HasMaxLength(200)
                .IsUnicode(false);
            entity.Property(e => e.DebitedAccountCurrency)
                .HasMaxLength(200)
                .IsUnicode(false);
            entity.Property(e => e.DebitedAccountName)
                .HasMaxLength(200)
                .IsUnicode(false);
            entity.Property(e => e.DebitedAccountNumber)
                .HasMaxLength(200)
                .IsUnicode(false);
            entity.Property(e => e.Description2)
                .HasMaxLength(200)
                .IsUnicode(false);
            entity.Property(e => e.EffectiveDate)
                .HasMaxLength(200)
                .IsUnicode(false);
            entity.Property(e => e.EmployeeType).IsUnicode(false);
            entity.Property(e => e.ExchangeRate)
                .HasMaxLength(200)
                .IsUnicode(false);
            entity.Property(e => e.FaxNotification)
                .HasMaxLength(200)
                .IsUnicode(false);
            entity.Property(e => e.IndonesianMigrantWorkerFlag)
                .HasMaxLength(200)
                .IsUnicode(false);
            entity.Property(e => e.LocationOfReceivingBank)
                .HasMaxLength(200)
                .IsUnicode(false);
            entity.Property(e => e.Npk)
                .HasMaxLength(200)
                .IsUnicode(false);
            entity.Property(e => e.Nrp)
                .HasMaxLength(200)
                .IsUnicode(false);
            entity.Property(e => e.SmsNotification)
                .HasMaxLength(200)
                .IsUnicode(false);
            entity.Property(e => e.TransactionPurposeCode)
                .HasMaxLength(200)
                .IsUnicode(false);
            entity.Property(e => e.TransactionType)
                .HasMaxLength(200)
                .IsUnicode(false);
            entity.Property(e => e.TreasuryConfirmationReferenceNumber)
                .HasMaxLength(200)
                .IsUnicode(false);
            entity.Property(e => e.UnderlyingDocuments)
                .HasMaxLength(200)
                .IsUnicode(false);
        });

        modelBuilder.Entity<MKmsiBank>(entity =>
        {
            entity.ToTable("M_KmsiBank", "dbo");

            entity.Property(e => e.BankName)
                .HasMaxLength(200)
                .IsUnicode(false);
            entity.Property(e => e.Description)
                .HasMaxLength(200)
                .IsUnicode(false);
        });

        modelBuilder.Entity<MPayTo>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__M_PayTo__3214EC0756468CE9");

            entity.ToTable("M_PayTo", "dbo");

            entity.Property(e => e.DepartmentApproval)
                .HasMaxLength(255)
                .IsUnicode(false);
            entity.Property(e => e.Name)
                .HasMaxLength(255)
                .IsUnicode(false);
            entity.Property(e => e.Value)
                .HasMaxLength(255)
                .IsUnicode(false);
        });

        modelBuilder.Entity<MPointingActivity>(entity =>
        {
            entity.ToTable("M_PointingActivity", "dbo");

            entity.Property(e => e.Description).IsUnicode(false);
            entity.Property(e => e.Name).IsUnicode(false);
        });

        modelBuilder.Entity<MSupplier>(entity =>
        {
            entity.ToTable("M_Supplier", "dbo");

            entity.Property(e => e.AccountNum)
                .HasMaxLength(255)
                .IsUnicode(false);
            entity.Property(e => e.ActivityType)
                .HasMaxLength(225)
                .IsUnicode(false);
            entity.Property(e => e.App1)
                .HasMaxLength(255)
                .IsUnicode(false);
            entity.Property(e => e.App2)
                .HasMaxLength(255)
                .IsUnicode(false);
            entity.Property(e => e.App3)
                .HasMaxLength(255)
                .IsUnicode(false);
            entity.Property(e => e.App4)
                .HasMaxLength(255)
                .IsUnicode(false);
            entity.Property(e => e.App5)
                .HasMaxLength(255)
                .IsUnicode(false);
            entity.Property(e => e.AppDate1).HasColumnType("datetime");
            entity.Property(e => e.AppDate2).HasColumnType("datetime");
            entity.Property(e => e.AppDate3).HasColumnType("datetime");
            entity.Property(e => e.AppDate4).HasColumnType("datetime");
            entity.Property(e => e.AppDate5).HasColumnType("datetime");
            entity.Property(e => e.AppName1)
                .HasMaxLength(255)
                .IsUnicode(false);
            entity.Property(e => e.AppName2)
                .HasMaxLength(255)
                .IsUnicode(false);
            entity.Property(e => e.AppName3)
                .HasMaxLength(255)
                .IsUnicode(false);
            entity.Property(e => e.AppName4)
                .HasMaxLength(255)
                .IsUnicode(false);
            entity.Property(e => e.AppName5)
                .HasMaxLength(255)
                .IsUnicode(false);
            entity.Property(e => e.AppStatus1)
                .HasMaxLength(255)
                .IsUnicode(false);
            entity.Property(e => e.AppStatus2)
                .HasMaxLength(255)
                .IsUnicode(false);
            entity.Property(e => e.AppStatus3)
                .HasMaxLength(255)
                .IsUnicode(false);
            entity.Property(e => e.AppStatus4)
                .HasMaxLength(255)
                .IsUnicode(false);
            entity.Property(e => e.AppStatus5)
                .HasMaxLength(255)
                .IsUnicode(false);
            entity.Property(e => e.BankCode)
                .HasMaxLength(255)
                .IsUnicode(false);
            entity.Property(e => e.BankCountry)
                .HasMaxLength(255)
                .IsUnicode(false);
            entity.Property(e => e.BeneFiciaryAccount)
                .HasMaxLength(255)
                .IsUnicode(false);
            entity.Property(e => e.BeneFiciaryAddress)
                .HasMaxLength(255)
                .IsUnicode(false);
            entity.Property(e => e.BeneFiciaryName)
                .HasMaxLength(255)
                .IsUnicode(false);
            entity.Property(e => e.BeneficiaryBank)
                .HasMaxLength(255)
                .IsUnicode(false);
            entity.Property(e => e.BeneficiaryBankBranch)
                .HasMaxLength(255)
                .IsUnicode(false);
            entity.Property(e => e.BeneficiaryType)
                .HasMaxLength(255)
                .IsUnicode(false);
            entity.Property(e => e.BillingEmail)
                .HasMaxLength(255)
                .IsUnicode(false);
            entity.Property(e => e.BillingPhone)
                .HasMaxLength(255)
                .IsUnicode(false);
            entity.Property(e => e.BpCode)
                .HasMaxLength(255)
                .IsUnicode(false);
            entity.Property(e => e.City)
                .HasMaxLength(255)
                .IsUnicode(false);
            entity.Property(e => e.Clasify)
                .HasMaxLength(255)
                .IsUnicode(false);
            entity.Property(e => e.Country)
                .HasMaxLength(255)
                .IsUnicode(false);
            entity.Property(e => e.CreatedAt).HasColumnType("datetime");
            entity.Property(e => e.Currency)
                .HasMaxLength(225)
                .IsUnicode(false);
            entity.Property(e => e.CustomerReference)
                .HasMaxLength(255)
                .IsUnicode(false);
            entity.Property(e => e.CustomerReferenceBaanwf)
                .HasMaxLength(255)
                .IsUnicode(false);
            entity.Property(e => e.Email)
                .HasMaxLength(255)
                .IsUnicode(false);
            entity.Property(e => e.EmployeeAddress)
                .HasMaxLength(255)
                .IsUnicode(false);
            entity.Property(e => e.EmployeeNrp)
                .HasMaxLength(255)
                .IsUnicode(false);
            entity.Property(e => e.EmployeeRemark)
                .HasMaxLength(255)
                .IsUnicode(false);
            entity.Property(e => e.EmployeeRequestType)
                .HasMaxLength(255)
                .IsUnicode(false);
            entity.Property(e => e.MarketingEmail)
                .HasMaxLength(255)
                .IsUnicode(false);
            entity.Property(e => e.MarketingPhone)
                .HasMaxLength(255)
                .IsUnicode(false);
            entity.Property(e => e.NpwpNumber)
                .HasMaxLength(255)
                .IsUnicode(false);
            entity.Property(e => e.Nrp)
                .HasMaxLength(255)
                .IsUnicode(false);
            entity.Property(e => e.PaymentType)
                .HasMaxLength(255)
                .IsUnicode(false);
            entity.Property(e => e.PengusahaKenaPajak)
                .HasMaxLength(255)
                .IsUnicode(false);
            entity.Property(e => e.Phone)
                .HasMaxLength(255)
                .IsUnicode(false);
            entity.Property(e => e.PostalCode)
                .HasMaxLength(255)
                .IsUnicode(false);
            entity.Property(e => e.RejectReason1)
                .HasMaxLength(255)
                .IsUnicode(false);
            entity.Property(e => e.RejectReason2)
                .HasMaxLength(255)
                .IsUnicode(false);
            entity.Property(e => e.RejectReason3)
                .HasMaxLength(255)
                .IsUnicode(false);
            entity.Property(e => e.RejectReason4)
                .HasMaxLength(255)
                .IsUnicode(false);
            entity.Property(e => e.RejectReason5)
                .HasMaxLength(255)
                .IsUnicode(false);
            entity.Property(e => e.RemittingCurrency)
                .HasMaxLength(255)
                .IsUnicode(false);
            entity.Property(e => e.Resident)
                .HasMaxLength(255)
                .IsUnicode(false);
            entity.Property(e => e.SettlementAccount)
                .HasMaxLength(255)
                .IsUnicode(false);
            entity.Property(e => e.Status)
                .HasMaxLength(255)
                .IsUnicode(false);
            entity.Property(e => e.SupplierRemark)
                .HasMaxLength(255)
                .IsUnicode(false);
            entity.Property(e => e.SupplierRequestType)
                .HasMaxLength(255)
                .IsUnicode(false);
            entity.Property(e => e.SupplierType)
                .HasMaxLength(255)
                .IsUnicode(false);
            entity.Property(e => e.TableConnectId)
                .HasMaxLength(255)
                .IsUnicode(false);
            entity.Property(e => e.TaxesEmail)
                .HasMaxLength(255)
                .IsUnicode(false);
            entity.Property(e => e.TaxesPhone)
                .HasMaxLength(255)
                .IsUnicode(false);
            entity.Property(e => e.TempAccountNum)
                .HasMaxLength(255)
                .IsUnicode(false);
            entity.Property(e => e.TempBankCode)
                .HasMaxLength(255)
                .IsUnicode(false);
            entity.Property(e => e.TempBankCountry)
                .HasMaxLength(255)
                .IsUnicode(false);
            entity.Property(e => e.TempBeneFiciaryAccount)
                .HasMaxLength(255)
                .IsUnicode(false);
            entity.Property(e => e.TempBeneFiciaryAddress)
                .HasMaxLength(255)
                .IsUnicode(false);
            entity.Property(e => e.TempBeneFiciaryName)
                .HasMaxLength(255)
                .IsUnicode(false);
            entity.Property(e => e.TempBeneficiaryBank)
                .HasMaxLength(255)
                .IsUnicode(false);
            entity.Property(e => e.TempBeneficiaryType)
                .HasMaxLength(255)
                .IsUnicode(false);
            entity.Property(e => e.TempBillingEmail)
                .HasMaxLength(255)
                .IsUnicode(false);
            entity.Property(e => e.TempBillingPhone)
                .HasMaxLength(255)
                .IsUnicode(false);
            entity.Property(e => e.TempBpCode)
                .HasMaxLength(255)
                .IsUnicode(false);
            entity.Property(e => e.TempCity)
                .HasMaxLength(255)
                .IsUnicode(false);
            entity.Property(e => e.TempClasify)
                .HasMaxLength(255)
                .IsUnicode(false);
            entity.Property(e => e.TempCountry)
                .HasMaxLength(255)
                .IsUnicode(false);
            entity.Property(e => e.TempCreatedAt).HasColumnType("datetime");
            entity.Property(e => e.TempCustomerReference)
                .HasMaxLength(255)
                .IsUnicode(false);
            entity.Property(e => e.TempCustomerReferenceBaanwf)
                .HasMaxLength(255)
                .IsUnicode(false);
            entity.Property(e => e.TempEmail)
                .HasMaxLength(255)
                .IsUnicode(false);
            entity.Property(e => e.TempEmployeeAddress)
                .HasMaxLength(255)
                .IsUnicode(false);
            entity.Property(e => e.TempEmployeeNrp)
                .HasMaxLength(255)
                .IsUnicode(false);
            entity.Property(e => e.TempEmployeeRemark)
                .HasMaxLength(255)
                .IsUnicode(false);
            entity.Property(e => e.TempEmployeeRequestType)
                .HasMaxLength(255)
                .IsUnicode(false);
            entity.Property(e => e.TempMarketingEmail)
                .HasMaxLength(255)
                .IsUnicode(false);
            entity.Property(e => e.TempMarketingPhone)
                .HasMaxLength(255)
                .IsUnicode(false);
            entity.Property(e => e.TempNpwpNumber)
                .HasMaxLength(255)
                .IsUnicode(false);
            entity.Property(e => e.TempPaymentType)
                .HasMaxLength(255)
                .IsUnicode(false);
            entity.Property(e => e.TempPengusahaKenaPajak)
                .HasMaxLength(255)
                .IsUnicode(false);
            entity.Property(e => e.TempPhone)
                .HasMaxLength(255)
                .IsUnicode(false);
            entity.Property(e => e.TempPostalCode)
                .HasMaxLength(255)
                .IsUnicode(false);
            entity.Property(e => e.TempRemittingCurrency)
                .HasMaxLength(255)
                .IsUnicode(false);
            entity.Property(e => e.TempResident)
                .HasMaxLength(255)
                .IsUnicode(false);
            entity.Property(e => e.TempSettlementAccount)
                .HasMaxLength(255)
                .IsUnicode(false);
            entity.Property(e => e.TempSupplierRemark)
                .HasMaxLength(255)
                .IsUnicode(false);
            entity.Property(e => e.TempSupplierRequestType)
                .HasMaxLength(255)
                .IsUnicode(false);
            entity.Property(e => e.TempSupplierType)
                .HasMaxLength(255)
                .IsUnicode(false);
            entity.Property(e => e.TempTableConnectId)
                .HasMaxLength(255)
                .IsUnicode(false);
            entity.Property(e => e.TempTaxesEmail)
                .HasMaxLength(255)
                .IsUnicode(false);
            entity.Property(e => e.TempTaxesPhone)
                .HasMaxLength(255)
                .IsUnicode(false);
            entity.Property(e => e.TempTransactionType)
                .HasMaxLength(255)
                .IsUnicode(false);
            entity.Property(e => e.TempUpdateAt).HasColumnType("datetime");
            entity.Property(e => e.TransactionType)
                .HasMaxLength(255)
                .IsUnicode(false);
            entity.Property(e => e.Type)
                .HasMaxLength(255)
                .IsUnicode(false);
            entity.Property(e => e.UpdateAt).HasColumnType("datetime");
        });

        modelBuilder.Entity<MTarifWht>(entity =>
        {
            entity.ToTable("M_TarifWht", "dbo");

            entity.Property(e => e.Description).IsUnicode(false);
            entity.Property(e => e.Tarif).HasColumnType("decimal(30, 2)");
        });

        modelBuilder.Entity<MTypeWht>(entity =>
        {
            entity.ToTable("M_TypeWht", "dbo");

            entity.Property(e => e.Description).IsUnicode(false);
            entity.Property(e => e.Name).IsUnicode(false);
        });

        modelBuilder.Entity<MVat>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__M_Vat__3214EC07EA9A19C5");

            entity.ToTable("M_Vat", "dbo");

            entity.Property(e => e.IsActive).HasColumnName("Is_Active");
            entity.Property(e => e.Name)
                .HasMaxLength(225)
                .IsUnicode(false);
        });

        modelBuilder.Entity<VsTOldVendor>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__VS_T_Old__3214EC07949EED6F");

            entity.ToTable("VS_T_OldVendor", "dbo");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
