using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace CrudIntern.Models.ESSEmployee;

public partial class ESection
{
    public int Id { get; set; }

    [Required(ErrorMessage = "Name is required.")]
    public string? Name { get; set; }

    [Required(ErrorMessage = "Value is required.")]
    public string? Value { get; set; }

    [Required(ErrorMessage = "DepartmentId is required.")]
    public int? DepartmentId { get; set; }

    [Required(ErrorMessage = "Code is required.")]
    public string? Code { get; set; }

    public virtual EDepartment? Department { get; set; }
}
