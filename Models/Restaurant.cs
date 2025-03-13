using System;
using System.Collections.Generic;

namespace REN.Models;

public partial class Restaurant
{
    public int RestaurantId { get; set; }

    public int UserId { get; set; }

    public string ContactNumber { get; set; } = null!;

    public string RestaurantName { get; set; } = null!;

    public virtual ICollection<Menuitem> Menuitems { get; set; } = new List<Menuitem>();

    public virtual ICollection<Ordertable> Ordertables { get; set; } = new List<Ordertable>();

    public virtual ICollection<RestaurantAddress> RestaurantAddresses { get; set; } = new List<RestaurantAddress>();

    public virtual User User { get; set; } = null!;
}
