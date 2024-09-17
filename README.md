# Todo API Project

Welcome to the Todo API project! This project is a simple RESTful API built with .NET Core 8 and SQLite. It provides basic CRUD operations for managing todo items. Follow the instructions below to set up and run the project, and test the API using Postman.

## Prerequisites

Before running the project, make sure you have the following installed on your machine:

1. **.NET Core 8 SDK**
   - Download and install the .NET Core 8 SDK from the [official .NET website](https://dotnet.microsoft.com/download/dotnet/8.0).
   
2. **SQLite Browser**
   - Download and install SQLite Browser (DB Browser for SQLite) from the [official website](https://sqlitebrowser.org/). This tool will help you view and manage the SQLite database used by the project.

## Getting Started

### 1. Clone the Repository

First, clone the repository to your local machine: 

    git clone https://github.com/shaijut/TodoAPI.git
    cd TodoAPI

### **2. Restore Dependencies**
Navigate to the project directory and restore the necessary NuGet packages:

    dotnet restore

### **3. Run the Project**
Build and run the project using the following command:

    dotnet run

The API will start and be accessible at http://localhost:5083.

### **4. Open the SQLite Database**

**Launch DB Browser for SQLite.**
Open the TodoDatabase.db file located in the project's directory (usually under App_Data or similar). This will allow you to view and manage the SQLite database.

### Testing the API with Postman

We have provided a Postman collection for testing the API endpoints. Follow these steps to import and use the Postman collection:

**1. Import Postman Collection**
Open Postman.

Click on the Import button (usually found in the top-left corner).

Select Import From Link and enter the following URL:

       https://github.com/shaijut/TodoAPI/blob/main/Postman/Todo_API.postman_collection.json

Click Continue and then Import to add the collection to Postman.

**2. Run API Tests**

Once the collection is imported:
Open the collection in Postman.

You will see various API requests such as GET, POST, PUT, and DELETE for the Todo API.

Click on each request to configure and test the API endpoints. Ensure the API server is running locally at http://localhost:5083.

**Endpoints Overview**

    GET /api/todos: Retrieve all todos
    GET /api/todos/{id}: Retrieve a specific todo by ID
    POST /api/todos: Create a new todo
    PUT /api/todos/{id}: Update an existing todo
    DELETE /api/todos/{id}: Delete a specific todo by ID

**Troubleshooting**

If you encounter any issues, ensure that the .NET Core SDK and SQLite Browser are correctly installed and configured.

 - Verify that the API server is running and accessible at
  -  http://localhost:5083. Check the project’s console output for any
   errors or warnings.

**Contributing**
If you would like to contribute to this project, please fork the repository, make your changes, and submit a pull request.

**License**
This project is licensed under the MIT License.

**Contact**
For any questions or issues, please contact me :).
