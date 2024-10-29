using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace CrudIntern.Models.ESSFinance;

public partial class MBankingRoutingCode
{
    public int Id { get; set; }

    [Required(ErrorMessage = "Bank Name is required.")]
    public string? BankName { get; set; }

    [Required(ErrorMessage = "Bank Code is required.")]
    public string? RoutingCode { get; set; }
}
