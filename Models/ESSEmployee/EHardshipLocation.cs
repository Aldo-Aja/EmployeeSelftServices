using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace CrudIntern.Models.ESSEmployee;

public partial class EHardshipLocation
{
    public int Id { get; set; }

    [Required(ErrorMessage = "Name is required.")]
    public string? Name { get; set; }

    [Required(ErrorMessage = "Province is required.")]
    public string? Province { get; set; }

    [Required(ErrorMessage = "ProvinceId is required.")]
    public int? ProvinceId { get; set; }
}
