using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;

namespace REN.Models;

public partial class User:IdentityUser
{
    public int Userid { get; }

    public string FirstName { get; set; } = null!;

    public string LastName { get; set; } = null!;

    public string? UserRole { get; set; }

    public DateTime? UserTimestamp { get; set; }

    public string Password { get; set; } = null!;

    public virtual ICollection<Cart> Carts { get; set; } = new List<Cart>();

    public virtual ICollection<Customer> Customers { get; set; } = new List<Customer>();

    public virtual ICollection<Restaurant> Restaurants { get; set; } = new List<Restaurant>();
}
