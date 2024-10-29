using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace CrudIntern.Models.ESSFinance;

public partial class MAttnCustomer
{
    public int Id { get; set; }

    [Required(ErrorMessage = "BpCode is required.")]
    public string? BpCode { get; set; }

    [Required(ErrorMessage = "AttnName is required.")]
    public string? AttnName { get; set; }

    [Required(ErrorMessage = "Email is required.")]
    public string? Email { get; set; }

    [Required(ErrorMessage = "Description is required.")]
    public string? Description { get; set; }
}
