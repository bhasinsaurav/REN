using System;
using System.Collections.Generic;

namespace REN.Models;

public partial class Ordertable
{
    public int OrderId { get; set; }

    public int? CustomerId { get; set; }

    public int? RestaurantId { get; set; }

    public int? StatusId { get; set; }

    public decimal TotalAmount { get; set; }

    public DateTime? CreatedAt { get; set; }

    public DateTime? UpdatedAt { get; set; }

    public virtual Customer? Customer { get; set; }

    public virtual ICollection<OrderItem> OrderItems { get; set; } = new List<OrderItem>();

    public virtual ICollection<Payment> Payments { get; set; } = new List<Payment>();

    public virtual ICollection<RealtimeTracking> RealtimeTrackings { get; set; } = new List<RealtimeTracking>();

    public virtual Restaurant? Restaurant { get; set; }

    public virtual OrderStatus? Status { get; set; }
}
