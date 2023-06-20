using System;
using System.Collections.Generic;

namespace OnlineShop.Models;

public partial class VwReportOrder
{
    public string COrderNo { get; set; } = null!;

    public DateTime DOrderDate { get; set; }

    public decimal? MTotalCost { get; set; }

    public string VFirstName { get; set; } = null!;

    public string? VEmailId { get; set; }

    public string VAddress { get; set; } = null!;

    public string VToyName { get; set; } = null!;

    public decimal MToyRate { get; set; }

    public short SiQty { get; set; }

    public string CToyId { get; set; } = null!;
}
