using System;
using System.Collections.Generic;

namespace OnlineShop.Models;

public partial class VwOrder
{
    public short SiQty { get; set; }

    public string CToyId { get; set; } = null!;

    public DateTime DOrderDate { get; set; }

    public string CMode { get; set; } = null!;

    public string VFirstName { get; set; } = null!;

    public string? VLastName { get; set; }

    public string VAddress { get; set; } = null!;

    public string VToyName { get; set; } = null!;

    public string COrderNo { get; set; } = null!;

    public decimal MToyRate { get; set; }
}
