using System;
using System.Collections.Generic;

namespace CrudIntern.Models.ESSFinance;

public partial class MDataBank
{
    public int Id { get; set; }

    public string? BankName { get; set; }

    public string? BankAddress { get; set; }

    public string? BankCity { get; set; }

    public string? BankCode { get; set; }

    public string? BeneficiaryName { get; set; }

    public string? Nrp { get; set; }

    public string? BeneficiaryAccount { get; set; }

    public string? BeneficiaryCurrency { get; set; }

    public string? Description2 { get; set; }

    public string? BeneficiaryEmailAddress { get; set; }

    public string? TransactionType { get; set; }

    public int? ResidentStatus { get; set; }

    public int? CitizenStatus { get; set; }

    public string? Branch { get; set; }

    public string? Npk { get; set; }

    public string? CustomerReferenceNumber { get; set; }

    public string? EffectiveDate { get; set; }

    public string? SmsNotification { get; set; }

    public string? FaxNotification { get; set; }

    public string? DebitedAccountName { get; set; }

    public string? DebitedAccountNumber { get; set; }

    public string? DebitedAccountCurrency { get; set; }

    public string? ExchangeRate { get; set; }

    public string? TreasuryConfirmationReferenceNumber { get; set; }

    public string? BeneficiaryAddress1 { get; set; }

    public string? BeneficiaryAddress2 { get; set; }

    public string? BeneficiaryAddress3 { get; set; }

    public string? IndonesianMigrantWorkerFlag { get; set; }

    public string? LocationOfReceivingBank { get; set; }

    public string? UnderlyingDocuments { get; set; }

    public int? BeneficiaryType { get; set; }

    public string? TransactionPurposeCode { get; set; }

    public string? EmployeeType { get; set; }

    public string? CostCenter { get; set; }

    public int? DepartmentId { get; set; }
}
