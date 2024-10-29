using System;
using System.Collections.Generic;

namespace CrudIntern.Models.ESSFinance;

public partial class MVat
{
    public int Id { get; set; }

    public string? Name { get; set; }

    public int? Value { get; set; }

    public bool? IsActive { get; set; }
}
