# QueryTerminal

This is a simple console application developed using C# and .NET 8. Its purpose is to connect directly to a Microsoft SQL Server database and execute raw SQL queries.

I developed this project to practice the fundamentals of the ADO.NET (`Microsoft.Data.SqlClient`) library, without relying on an ORM (Object-Relational Mapper) like Entity Framework.

## What Does This Project Do?

* Connects to an MS SQL Server using a standard connection string.
* Waits for the user to input an SQL query (within a continuous loop).
* If the query starts with `SELECT`, it dynamically detects the column names and rows from the returned data and prints them to the console as a table.
* If the query is `INSERT`, `UPDATE`, or `DELETE`, it informs the user of the number of rows affected by the operation.
* It catches potential errors from the database (e.g., incorrect syntax) and displays them in the console.

## Technologies Used

* **Language:** C#
* **Platform:** .NET 8 (Console Application)
* **Database Library:** ADO.NET (Microsoft.Data.SqlClient)
* **Tested On:** Microsoft SQL Server 2022 Developer Edition


## How to Run

1.  Clone or download this repository.
2.  Open the `QueryTerminal.sln` file with Visual Studio 2022.
3.  **Important:** Before running the project, you must update the `connectionString` variable in the `Program.cs` file to match your own local SQL Server and test database (like our `TestDB`).
4.  Press F5 or the "Start" button to run the application.

---
Mehmet İkbal Kahraman - Portfolio Project.
