using System;
using System.Collections.Generic;

namespace REN.Models;

public partial class OrderItem
{
    public int ItemId { get; set; }

    public int? MenuitemId { get; set; }

    public int? OrderId { get; set; }

    public int Quantity { get; set; }

    public virtual Menuitem? Menuitem { get; set; }

    public virtual Ordertable? Order { get; set; }
}
