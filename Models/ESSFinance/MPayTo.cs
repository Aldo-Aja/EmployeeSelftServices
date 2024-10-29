using System;
using System.Collections.Generic;

namespace CrudIntern.Models.ESSFinance;

public partial class MPayTo
{
    public int Id { get; set; }

    public string? Name { get; set; }

    public string? Value { get; set; }

    public string? DepartmentApproval { get; set; }
}
