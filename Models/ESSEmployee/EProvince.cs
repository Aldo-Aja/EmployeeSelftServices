using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace CrudIntern.Models.ESSEmployee;

public partial class EProvince
{
    public int Id { get; set; }

    [Required(ErrorMessage = "Name is required.")]
    public string? Name { get; set; }

    [Required(ErrorMessage = "Value is required.")]
    public string? Value { get; set; }

    [Required(ErrorMessage = "CountryId is required.")]
    public int? CountryId { get; set; }

    public virtual ECountry? Country { get; set; }

    public virtual ICollection<ECity> ECities { get; set; } = new List<ECity>();
}
