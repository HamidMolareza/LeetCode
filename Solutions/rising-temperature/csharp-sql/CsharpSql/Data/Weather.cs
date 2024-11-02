using System;
using System.Collections.Generic;

namespace ConsoleSharpTemplate.Data;

public partial class Weather
{
    public int Id { get; set; }

    public DateOnly? RecordDate { get; set; }

    public int? Temperature { get; set; }
}
