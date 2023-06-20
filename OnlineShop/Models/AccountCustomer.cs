using System;
using System.Collections.Generic;

namespace OnlineShop.Models;

public partial class AccountCustomer
{
    public string Phone { get; set; } = null!;

    public string? Username { get; set; }

    public string? Password { get; set; }

    public string? Email { get; set; }
}
