using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ConsoleApp.Models;

public class Bonus {
    [Key]
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public int BonusId { get; set; }

    public int BonusValue { get; set; }

    public int EmployeeId { get; set; }
    public Employee Employee { get; set; }
}