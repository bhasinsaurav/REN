using System;
using System.Collections.Generic;

namespace REN.Models;

public partial class CustomerAddress
{
    public int CustAddId { get; set; }

    public int CustomerId { get; set; }

    public string Country { get; set; } = null!;

    public string City { get; set; } = null!;

    public string? StreetName { get; set; }

    public string StreetAddress { get; set; } = null!;

    public string? PinCode { get; set; }

    public string? Province { get; set; }

    public virtual Customer Customer { get; set; } = null!;
}
