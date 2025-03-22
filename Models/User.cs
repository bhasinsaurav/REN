using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;

namespace REN.Models;

public partial class User:IdentityUser<int>
{

    public string FirstName { get; set; } = null!;

    public string LastName { get; set; } = null!;

    public DateTime? UserTimestamp { get; set; }
 
    public virtual ICollection<Cart> Carts { get; set; } = new List<Cart>();

    public virtual ICollection<Customer> Customers { get; set; } = new List<Customer>();

    public virtual ICollection<Restaurant> Restaurants { get; set; } = new List<Restaurant>();
}
