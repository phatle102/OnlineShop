using System;
using System.Collections.Generic;

namespace OnlineShop.Models;

public partial class OrderDetail
{
    public string IdOrder { get; set; } = null!;

    public string IdProduct { get; set; } = null!;

    public decimal? ProductCost { get; set; }

    public short? Quantity { get; set; }

    public virtual Order IdOrderNavigation { get; set; } = null!;

    public virtual Product IdProductNavigation { get; set; } = null!;
}
