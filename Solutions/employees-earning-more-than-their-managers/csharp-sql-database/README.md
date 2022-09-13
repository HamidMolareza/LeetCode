# About this solution

🌟 If you like this solution, please give it a star.

## How Run?

1. `dotnet build`
2. `dotnet run`

## Database

This program uses a **memory** database by default. If you want, use another database.

### Supported Databases:

- Postgres
- MySQL
- SqlServer
- Memory

### How Change Database

1. Open the [AppSettings file](AppSettings.json). (this is a json file)
2. Change `DatabaseType` key to desired database (look [Supported Databases](#supported-databases))
3. Update `ConnectionString` key
4. Run your database service or Use docker compose files in [Docker-Compose directory](Docker-Compose)

### Example for postgres database

1. Update `AppSettings.json` to
```json
{
  "DatabaseType": "postgres",
  "ConnectionString": "Host=localhost;Port=6000;Username=postgres;Password=postgres;Database=LeetCode"
}
```
2. docker-compose -f Docker-Compose/postgres.yml up
3. [Run program](#how-run)

> Note: If necessary, you can change the desired docker-compose file information. For example, port 6000 is used by default, which you can change to another number.

## File Structure

- [Program.cs](Program.cs) (`Solution` and `Main` methods)
- [Data](Data)
  - AppSettings.cs (loading the program settings)
  - ProblemContext (Database context, `DbSet` properties, `SeedData`, etc)
- [Docker-Compose](Docker-Compose) (docker compose for database)
- [Models](Models) (Database models)
- [AppSettings.json](AppSettings.json)
- [Runtime.cs](RunTime.cs) (Print runtime of process)
- [Utility.js](Utility.cs)

## Support

Reach out to the maintainer at one of the following places:

- [GitHub issues](https://github.com/HamidMolareza/LeetCode/issues/new?assignees=&labels=question&template=04_SUPPORT_QUESTION.md&title=support%3A+)

## Authors & contributors

The original setup of this repository is by [Hamid Molareza](https://github.com/HamidMolareza).

## License

This solution is licensed under the [GPLv3](https://choosealicense.com/licenses/gpl-3.0/).