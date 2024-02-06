---

# Taskify - .NET Web API To-Do App

Taskify is a simple To-Do application built with .NET Web API and MSSQL, designed to help you manage your tasks efficiently.

## Table of Contents

- [Features](#features)
- [Technologies Used](#technologies-used)
- [Getting Started](#getting-started)
- [API Endpoints](#api-endpoints)
- [Database Schema](#database-schema)
- [Contributing](#contributing)
- [License](#license)

## Features

- Create, read, update, and delete tasks.
- Mark tasks as completed or pending.
- Retrieve a list of all tasks or specific tasks.
- User-friendly API for integration with front-end applications.

## Technologies Used

- **.NET Web API:** The backend is implemented using the .NET Web API framework.
- **MSSQL:** The database is powered by Microsoft SQL Server for storing task information.

## Getting Started

To run Taskify locally, follow these steps:

1. **Clone the Repository:**
   ```bash
   git clone https://github.com/your-username/Taskify.git
   cd Taskify
   ```

2. **Set Up Database:**
   - Create a new MSSQL database.
   - Update the connection string in [`appsettings.json`](Taskify/Taskify.API/appsettings.json) with your database details.

3. **Run the Application:**
   - Open the solution in Visual Studio or your preferred IDE.
   - Build and run the project.

4. **Explore API Endpoints:**
   - Navigate to `https://localhost:5001/swagger` to access the Swagger documentation for API endpoints.
   - Use tools like [Postman](https://www.postman.com/) to interact with the API.

## API Endpoints

- **GET /api/tasks:** Get a list of all tasks.
- **GET /api/tasks/{id}:** Get details of a specific task by ID.
- **POST /api/tasks:** Create a new task.
- **PUT /api/tasks/{id}:** Update an existing task.
- **DELETE /api/tasks/{id}:** Delete a task.
- **PATCH /api/tasks/{id}/complete:** Mark a task as completed.

## Database Schema

The database schema includes a `Tasks` table with fields such as `Id`, `Title`, `Description`, `IsCompleted`, and `CreatedAt`.

```sql
CREATE TABLE Tasks (
    Id INT PRIMARY KEY IDENTITY(1,1),
    Title NVARCHAR(255) NOT NULL,
    Description NVARCHAR(MAX),
    IsCompleted BIT NOT NULL,
    CreatedAt DATETIME2 NOT NULL DEFAULT GETDATE()
);
```

## Contributing

If you want to contribute to Taskify, feel free to open issues or pull requests. Your feedback and contributions are highly appreciated!

## License

This project is licensed under the [MIT License](LICENSE).

---
