using System;
using System.Collections.Generic;

namespace OnlineShop.Models;

public partial class VwOrderWrapper
{
    public string COrderNo { get; set; } = null!;

    public string CToyId { get; set; } = null!;

    public short SiQty { get; set; }

    public string? VDescription { get; set; }

    public decimal MWrapperRate { get; set; }
}
