using System;
using System.Collections.Generic;

namespace OnlineShop.Models;

public partial class Customer
{
    public string IdCustomer { get; set; } = null!;

    public string? NameCustomer { get; set; }

    public string? Phone { get; set; }

    public string? Address { get; set; }

    public string? Email { get; set; }

    public virtual ICollection<Order> Orders { get; set; } = new List<Order>();
}
