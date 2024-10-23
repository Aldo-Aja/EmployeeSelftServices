using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace CrudIntern.Models.ESSEmployee;

public partial class ECity
{
    public int Id { get; set; }

    [Required(ErrorMessage = "City name is required.")]
    public string? Name { get; set; }

    [Required(ErrorMessage = "Value is required.")]
    public string? Value { get; set; }

    [Required(ErrorMessage = "ProvinceId is required.")]
    public int? ProvinceId { get; set; }

    public virtual EProvince? Province { get; set; }
}
