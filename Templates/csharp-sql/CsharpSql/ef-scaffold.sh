#!/bin/bash

# Function to display the help message
show_help() {
    echo "Usage: $(basename "$0") <connection_string> [output_models] [dbcontext_name]"
    echo
    echo "Arguments:"
    echo "  connection_string   The database connection string."
    echo "  output_models       (Optional) Directory to output the scaffolded models. Defaults to 'Data'."
    echo "  dbcontext_name      The name of the DbContext. Defaults: AppDbContext"
    echo
    echo "Sample Connection Strings:"
    echo "  SqlServer: Server=localhost,1433;Database=LeetCode;User Id=SA;Password=PASS; TrustServerCertificate=True;"
    echo "  Postgresql: Host=localhost;Port=5432;Database=LeetCode;Username=myusername;Password=PASS;"
    echo "  MySQL: Server=localhost;Port=3306;Database=LeetCode;User=myusername;Password=PASS;"
    echo "  Sqlite: Data Source=app.db"
    exit 1
}

# Check if the connection string is provided
connection_string="$1"
if [ -z "$connection_string" ]; then
    echo "Error: Connection string is required."
    show_help
fi

# Set the output directory for the models, default to 'Data' if not provided
output_models="${2:-Data}"

dbcontext_name="${3:-AppDbContext}"

# Check if 'dotnet ef' is installed
if ! command -v dotnet &> /dev/null || ! dotnet ef &> /dev/null; then
    echo "Error: 'dotnet ef' is not installed or not available in the PATH."
    echo "Please install the EF Core tools by running: dotnet tool install --global dotnet-ef"
    exit 1
fi

# Scaffold the DbContext and models
dotnet ef dbcontext scaffold "$connection_string" Microsoft.EntityFrameworkCore.SqlServer -o "$output_models" -c "$dbcontext_name"

# Check if the command was successful
if [ $? -eq 0 ]; then
    echo "Scaffolding completed successfully. Models output in '$output_models'."
else
    echo "Error: Scaffolding failed."
    exit 1
fi
