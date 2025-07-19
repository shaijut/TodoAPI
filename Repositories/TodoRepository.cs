using System.Collections.Generic;
using System.Data;
using Microsoft.Data.Sqlite;
using TodoAPI.Models;

namespace TodoAPI.Repositories
{
    public class TodoRepository
    {
        private readonly string _connectionString = "Data Source=App_Data/TodoDatabase.db";

        public List<TodoItem> GetAll()
        {
            var todos = new List<TodoItem>();

            using (var connection = new SqliteConnection(_connectionString))
            {
                connection.Open();
                var command = connection.CreateCommand();
                command.CommandText = "SELECT Id, Title, IsCompleted FROM Todos";
                
                using (var reader = command.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        todos.Add(new TodoItem
                        {
                            Id = reader.GetInt32(0),
                            Title = reader.GetString(1),
                            IsCompleted = reader.GetBoolean(2)
                        });
                    }
                }
            }

            return todos;
        }

        public TodoItem? GetById(int id)
        {
            using (var connection = new SqliteConnection(_connectionString))
            {
                connection.Open();
                var command = connection.CreateCommand();
                command.CommandText = "SELECT Id, Title, IsCompleted FROM Todos WHERE Id = @id";
                command.Parameters.AddWithValue("@id", id);

                using (var reader = command.ExecuteReader())
                {
                    if (reader.Read())
                    {
                        return new TodoItem
                        {
                            Id = reader.GetInt32(0),
                            Title = reader.GetString(1),
                            IsCompleted = reader.GetBoolean(2)
                        };
                    }
                }
            }

            return null;
        }

        public Int64 Add(TodoItem todo)
        {
            using (var connection = new SqliteConnection(_connectionString))
            {
                connection.Open();
                var command = connection.CreateCommand();
                command.CommandText =
                @"
                    INSERT INTO Todos (Title, IsCompleted)
                    VALUES (@title, @isCompleted);
                    SELECT last_insert_rowid();
                ";
                command.Parameters.AddWithValue("@title", todo.Title);
                command.Parameters.AddWithValue("@isCompleted", todo.IsCompleted ? 1 : 0);

                //command.ExecuteNonQuery();

                // ExecuteScalar returns the first column of the first row from the SELECT
                var insertedId = (Int64)command.ExecuteScalar();

                return insertedId;
            }
        }

        public TodoItem Update(TodoItem todo)
        {
            using (var connection = new SqliteConnection(_connectionString))
            {
                connection.Open();
                var command = connection.CreateCommand();
                command.CommandText =
                @"
            UPDATE Todos
            SET Title = @title, IsCompleted = @isCompleted
            WHERE Id = @id
            RETURNING Id, Title, IsCompleted;
        ";
                command.Parameters.AddWithValue("@id", todo.Id);
                command.Parameters.AddWithValue("@title", todo.Title);
                command.Parameters.AddWithValue("@isCompleted", todo.IsCompleted ? 1 : 0);

                using (var reader = command.ExecuteReader())
                {
                    if (reader.Read())
                    {
                        return new TodoItem
                        {
                            Id = reader.GetInt64(0),
                            Title = reader.GetString(1),
                            IsCompleted = reader.GetInt64(2) == 1
                        };
                    }
                }

                return null; // Or throw if not found
            }
        }

        public void Delete(int id)
        {
            using (var connection = new SqliteConnection(_connectionString))
            {
                connection.Open();
                var command = connection.CreateCommand();
                command.CommandText =
                @"
                    DELETE FROM Todos
                    WHERE Id = @id;
                ";
                command.Parameters.AddWithValue("@id", id);

                command.ExecuteNonQuery();
            }
        }
    }
}
