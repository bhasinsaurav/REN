using System;
using System.Collections.Generic;

namespace REN.Models;

public partial class OrderStatus
{
    public int StatusId { get; set; }

    public string StatusName { get; set; } = null!;

    public virtual ICollection<Ordertable> Ordertables { get; set; } = new List<Ordertable>();

    public virtual ICollection<RealtimeTracking> RealtimeTrackings { get; set; } = new List<RealtimeTracking>();
}
