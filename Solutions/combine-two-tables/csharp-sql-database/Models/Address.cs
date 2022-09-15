using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ConsoleApp.Models; 

public class Address {
    [Key]
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public int AddressId { get; set; }
    public string City { get; set; }
    public string State { get; set; }
    
    public Person Person { get; set; }
    public int PersonId { get; set; }
}