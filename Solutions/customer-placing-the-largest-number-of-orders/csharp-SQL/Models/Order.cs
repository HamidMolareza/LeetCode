
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ConsoleApp.Models; 

public class Order {
     [Key]
     [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
     public int OrderNumber { get; set; }
     public int CustomerNumber { get; set; }
}