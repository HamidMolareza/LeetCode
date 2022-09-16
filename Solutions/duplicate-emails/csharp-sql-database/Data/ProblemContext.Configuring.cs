using Microsoft.EntityFrameworkCore;

namespace ConsoleApp.Data;

public partial class ProblemContext : DbContext {
    protected override void OnConfiguring(DbContextOptionsBuilder options) {
        switch (AppSettings.DatabaseType.ToLower()) {
            case "postgres":
                options.UseNpgsql(AppSettings.ConnectionString);
                break;
            case "sqlserver":
                options.UseSqlServer(AppSettings.ConnectionString);
                break;
            case "memory":
                options.UseInMemoryDatabase(AppSettings.ConnectionString);
                break;
            case "mysql":
                options.UseMySQL(AppSettings.ConnectionString);
                break;
            default:
                throw new ArgumentOutOfRangeException($"This database is not supported.");
        }
    }

    public async Task RenewDatabaseAsync() {
        await Database.EnsureDeletedAsync();
        await Database.EnsureCreatedAsync();
    }
}