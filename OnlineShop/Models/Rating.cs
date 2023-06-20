using System;
using System.Collections.Generic;

namespace OnlineShop.Models;

public partial class Rating
{
    public double? Rating1 { get; set; }

    public int IdRating { get; set; }

    public int? UserId { get; set; }

    public string? ProductId { get; set; }

    public virtual Product? Product { get; set; }
}
