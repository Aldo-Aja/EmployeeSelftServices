using System;
using System.Collections.Generic;

namespace CrudIntern.Models.ESSFinance;

public partial class MTarifWht
{
    public int Id { get; set; }

    public decimal? Tarif { get; set; }

    public string? Description { get; set; }
}
