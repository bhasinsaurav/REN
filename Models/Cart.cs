using System;
using System.Collections.Generic;

namespace REN.Models;

public partial class Cart
{
    public int CartId { get; set; }

    public int? UserId { get; set; }

    public int? MenuitemId { get; set; }

    public int Quantity { get; set; }

    public DateTime? CreatedAt { get; set; }

    public virtual Menuitem? Menuitem { get; set; }

    public virtual User? User { get; set; }
}
