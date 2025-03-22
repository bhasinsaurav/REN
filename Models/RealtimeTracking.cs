using System;
using System.Collections.Generic;

namespace REN.Models;

public partial class RealtimeTracking
{
    public int TrackingId { get; set; }

    public int? OrderId { get; set; }

    public int? StatusId { get; set; }

    public DateTime? UpdatedAt { get; set; }

    public virtual Ordertable? Order { get; set; }

    public virtual OrderStatus? Status { get; set; }
}
