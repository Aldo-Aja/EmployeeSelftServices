using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace CrudIntern.Models.ESSEmployee;

public partial class EInsurance
{
    public int Id { get; set; }

    [Required(ErrorMessage = "Insurance name is required.")]
    public string? Name { get; set; }

    [Required(ErrorMessage = "Insurance value is required.")]
    public string? Value { get; set; }
}
