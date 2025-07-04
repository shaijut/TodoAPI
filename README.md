
🚀 A fast , minimal REST API built with .NET 9 and SQLite — perfect for powering Todo apps, prototyping ideas, or plugging into any frontend with zero hassle.

## 🛠️ Prerequisites

-   Download [.NET 9 SDK](https://dotnet.microsoft.com/en-us/download/dotnet/9.0)
    
-   (Optional) [DB Browser for SQLite](https://sqlitebrowser.org/) — to inspect the local database.
    

## 🚀 Getting Started

1.  **Clone the Repository**
    
    `git clone https://github.com/shaijut/TodoAPI.git`
 
     - Move into the project folder `TodoAPI`
    
2.  **Run the API**
    
    -   Double-click `Run-Todo-API.bat`
        
    -   This will restore dependencies and launch the API at `http://localhost:5083`
        
3.  **Test the API**
    
-   Visit `http://localhost:5083/swagger` to explore and test endpoints via Swagger UI
    
-   You’re now ready to use the API — or connect it to any frontend as a real backend for managing todos 🚀
    
-   Optionally, inspect the SQLite database or test with Postman (see below)
        

## 🛢️ SQLite Database

To view or edit stored data:

1.  Open DB Browser for SQLite
    
2.  Load `TodoDatabase.db` (found in the project folder)
    

## 🧪 Testing with Postman

1.  **Import Collection**
    
    -   In Postman, click _Import > Link_  
        Use:  
        `https://raw.githubusercontent.com/shaijut/TodoAPI/refs/heads/main/API_Testing/Todo_API.postman_collection.json`
        
2.  **Run Requests**
    
    -   Ensure API is running at `http://localhost:5083`
        
    -   Use the included `GET`, `POST`, `PUT`, and `DELETE` endpoints.
        

### 🔌 API Endpoints

-   `GET /api/todos` — Get all todos
    
-   `GET /api/todos/{id}` — Get a todo by ID
    
-   `POST /api/todos` — Create a new todo
    
-   `PUT /api/todos/{id}` — Update an existing todo
    
-   `DELETE /api/todos/{id}` — Delete a todo
    

## ❗ Troubleshooting

-   Ensure `.NET 9 SDK` and `SQLite Browser` are installed correctly.
    
-   Confirm the API is running at `http://localhost:5083`.
    
-   Check the terminal for any startup errors.

-   If the batch file doesn’t work, run the following commands manually in your terminal or command prompt:

        cd TodoAPI        # Navigate to the project folder
        dotnet restore    # Restore dependencies
        dotnet run        # Start the API

## 🤝 Contributing

Fork, branch, and submit a PR — contributions are welcome!

## 📄 License

MIT License

## 📬 Contact

For questions or feedback, feel free to reach out or open an issue.