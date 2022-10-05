using ConsoleApp.Models;
using Microsoft.EntityFrameworkCore;

namespace ConsoleApp.Data;

public partial class ProblemContext {
    public DbSet<FriendRequest> FriendRequests { get; set; } = null!;
    public DbSet<RequestAccepted> RequestAccepteds { get; set; } = null!;

    public static async Task SeedDataAsync(ProblemContext db) {
        var friendRequests = new FriendRequest[] {
            new() {
                SenderId = 1,
                SendToId = 2
            },
            new() {
                SenderId = 1,
                SendToId = 3
            },
            new() {
                SenderId = 1,
                SendToId = 4
            },
            new() {
                SenderId = 2,
                SendToId = 3
            },
            new() {
                SenderId = 3,
                SendToId = 4
            },
            new() {
                SenderId = 3,
                SendToId = 4
            }
            ,
            new() {
                SenderId = 1,
                SendToId = 4
            }
        };
        db.FriendRequests.AddRange(friendRequests);

        var accepted = new RequestAccepted[] {
            new() {
                RequesterId = 1,
                AccepterId = 2
            },
            new() {
                RequesterId = 1,
                AccepterId = 3
            },
            new() {
                RequesterId = 2,
                AccepterId = 3
            },
            new() {
                RequesterId = 3,
                AccepterId = 4
            },
            new() {
                RequesterId = 3,
                AccepterId = 4
            }
        };
        db.RequestAccepteds.AddRange(accepted);

        await db.SaveChangesAsync();
    }
}