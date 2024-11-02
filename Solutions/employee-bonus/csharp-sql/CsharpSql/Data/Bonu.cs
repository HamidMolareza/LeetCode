using System;
using System.Collections.Generic;

namespace ConsoleSharpTemplate.Data;

public partial class Bonu
{
    public int? EmpId { get; set; }

    public int? Bonus { get; set; }

    public virtual Employee? Emp { get; set; }
}
