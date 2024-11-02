using System;
using System.Collections.Generic;

namespace ConsoleSharpTemplate.Data;

public partial class Employee
{
    public int EmpId { get; set; }

    public string? Name { get; set; }

    public int? Salary { get; set; }

    public int? ManagerId { get; set; }
}
