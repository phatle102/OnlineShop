using System;
using System.Collections.Generic;

namespace OnlineShop.Models;

public partial class Order
{
    public string IdOrder { get; set; } = null!;

    public string? OrderName { get; set; }

    public string? IdCustomer { get; set; }

    public string? ProductId { get; set; }

    public decimal? Totalmoney { get; set; }

    public virtual Customer? IdCustomerNavigation { get; set; }

    public virtual ICollection<OrderDetail> OrderDetails { get; set; } = new List<OrderDetail>();
}
