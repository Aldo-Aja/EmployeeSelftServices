using System;
using System.Collections.Generic;

namespace CrudIntern.Models.ESSFinance;

public partial class MConfigApprovalVendorCriterion
{
    public int Id { get; set; }

    public int? DepartmentId { get; set; }

    public string? DepartmentName { get; set; }

    public string? ApprovalType { get; set; }

    public string? Nrp { get; set; }

    public string? Name { get; set; }
}
