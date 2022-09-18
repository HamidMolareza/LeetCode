using ConsoleApp.Models;
using Microsoft.EntityFrameworkCore;

namespace ConsoleApp.Data; 

public partial class ProblemContext {
    public DbSet<Person> Persons { get; set; } = null!;
    public DbSet<Address> Addresses { get; set; } = null!;
    
    public static async Task SeedDataAsync(ProblemContext db) {
        var persons = new Person[] {
            new() {
                LastName = "Wang",
                FirstName = "Allen"
            },
            new() {
                LastName = "Alice",
                FirstName = "Bob",
                Addresses = new List<Address> {
                    new() {
                        AddressId = 1,
                        PersonId = 2,
                        City = "New York City",
                        State = "New York"
                    }
                }
            }
        };

        db.Persons.AddRange(persons);
        db.Addresses.Add(new Address {
            AddressId = 2,
            PersonId = 3,
            City = "Leetcode",
            State = "California"
        });
        await db.SaveChangesAsync();
    }
}