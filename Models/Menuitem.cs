using System;
using System.Collections.Generic;

namespace REN.Models;

public partial class Menuitem
{
    public int ItemId { get; set; }

    public int RestaurantId { get; set; }

    public string ItemName { get; set; } = null!;

    public string? MenuitemCategory { get; set; }

    public string? Description { get; set; }

    public string? Image { get; set; }

    public decimal Price { get; set; }

    public bool? Isavailable { get; set; }

    public DateTime? CreatedAt { get; set; }

    public DateTime? UpdatedAt { get; set; }

    public virtual ICollection<Cart> Carts { get; set; } = new List<Cart>();

    public virtual ICollection<OrderItem> OrderItems { get; set; } = new List<OrderItem>();

    public virtual Restaurant Restaurant { get; set; } = null!;
}
