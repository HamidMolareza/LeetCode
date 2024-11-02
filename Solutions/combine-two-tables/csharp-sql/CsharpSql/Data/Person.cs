using System;
using System.Collections.Generic;

namespace ConsoleSharpTemplate.Data;

public partial class Person
{
    public int PersonId { get; set; }

    public string? LastName { get; set; }

    public string? FirstName { get; set; }

    public virtual ICollection<Address> Addresses { get; set; } = new List<Address>();
}
