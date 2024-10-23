using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace CrudIntern.Models.ESSEmployee;

public partial class ECountry
{
    public int Id { get; set; }

    [Required(ErrorMessage = "Name is required.")]
    public string? Name { get; set; }

    [Required(ErrorMessage = "Value is required.")]
    public string? Value { get; set; }

    [Required(ErrorMessage = "IsoCode is required.")]
    public string? IsoCode { get; set; }

    public virtual ICollection<EProvince> EProvinces { get; set; } = new List<EProvince>();
}
