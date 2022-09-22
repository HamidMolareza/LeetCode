using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ConsoleApp.Models;

public class Employee {
    [Key]
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public int EmployeeId { get; set; }

    public string Name { get; set; } = null!;
    public int? Supervisor { get; set; }
    public decimal Salary { get; set; }
    
    public Bonus Bonus { get; set; }
}