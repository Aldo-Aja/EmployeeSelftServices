using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace CrudIntern.Models.ESSEmployee;

public partial class EDepartment
{
    public int Id { get; set; }

    [Required(ErrorMessage = "Name is required.")]
    public string? Name { get; set; }

    [Required(ErrorMessage = "Value is required.")]
    public string? Value { get; set; }

    [Required(ErrorMessage = "Code is required.")]
    public string? Code { get; set; }

    public virtual ICollection<ESection> ESections { get; set; } = new List<ESection>();
}
