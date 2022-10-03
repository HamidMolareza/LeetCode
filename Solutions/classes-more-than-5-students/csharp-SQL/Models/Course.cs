using System.ComponentModel.DataAnnotations;

namespace ConsoleApp.Models;

public class Course {
    [Key] public string Student { get; set; } = null!;
    public string Class { get; set; } = null!;
}