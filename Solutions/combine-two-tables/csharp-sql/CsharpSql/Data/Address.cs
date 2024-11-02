using System;
using System.Collections.Generic;

namespace ConsoleSharpTemplate.Data;

public partial class Address
{
    public int AddressId { get; set; }

    public int? PersonId { get; set; }

    public string? City { get; set; }

    public string? State { get; set; }

    public virtual Person? Person { get; set; }
}
