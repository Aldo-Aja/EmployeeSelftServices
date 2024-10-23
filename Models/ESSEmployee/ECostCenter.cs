using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace CrudIntern.Models.ESSEmployee;

public partial class ECostCenter
{
    public int Id { get; set; }

    [Required(ErrorMessage = "Name is required.")]
    public string? Name { get; set; }

    [Required(ErrorMessage = "Code is required.")]
    public string? Code { get; set; }

    [Required(ErrorMessage = "CostCenter is required.")]
    public string? CostCenter { get; set; }
}
