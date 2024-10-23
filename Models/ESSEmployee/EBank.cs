using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace CrudIntern.Models.ESSEmployee;

public partial class EBank
{
    public int Id { get; set; }

    [Required(ErrorMessage = "Bank name is required.")]
    public string? Name { get; set; }

    [Required(ErrorMessage = "Bank value is required.")]
    public string? Value { get; set; }
}
