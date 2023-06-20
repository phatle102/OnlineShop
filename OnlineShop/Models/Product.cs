using System;
using System.Collections.Generic;

namespace OnlineShop.Models;

public partial class Product
{
    public string? ProductName { get; set; }

    public double? Rating { get; set; }

    public int? ProductAmount { get; set; }

    public int? Likes { get; set; }

    public double? Cost { get; set; }

    public string IdProduct { get; set; } = null!;

    public string? ImgProduct { get; set; }

    public string? ProductInformation { get; set; }

    public string? CategoryId { get; set; }

    public string? ViewProduct1 { get; set; }

    public string? ViewProduct2 { get; set; }

    public virtual Category? Category { get; set; }

    public virtual ICollection<OrderDetail> OrderDetails { get; set; } = new List<OrderDetail>();

    public virtual ICollection<Rating> Ratings { get; set; } = new List<Rating>();
}
