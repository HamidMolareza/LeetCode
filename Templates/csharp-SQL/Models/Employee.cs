using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ConsoleApp.Models; 

//Sample
// public class Employee {
//     [Key]
//     [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
//     public int Id { get; set; }
//     public string Name { get; set; } = null!;
//     public decimal Salary { get; set; }
//     public int? ManagerId { get; set; }
// }