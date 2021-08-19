using Microsoft.AspNetCore.Mvc;
using Microsoft.Data.SqlClient;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using WebAppMVC.Models;

namespace WebAppMVC.DAL
{
    /// <summary>
    /// Класс для работы с базой данных
    /// </summary>
    public static class DAL
    {
        //static string connectionString = @"Data Source=.\SQLEXPRESS;Initial Catalog=usersdb;Integrated Security=True";
        static string connectionString = @"Data source = (LocalDB)\MSSQLLocalDB;Initial Catalog = DbHomeLibrary; Integrated Security = True";

        /// <summary>
        /// Получить список книг
        /// </summary>
        /// <returns></returns>
        public static List<Book>GetBooks()
        {
            List<Book> listBook = new List<Book>();

            // название хранимой процедуры
            string sqlExpression = "sp_SelectAllBooks";
            
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();
                SqlCommand command = new SqlCommand(sqlExpression, connection);
                // указываем, что команда представляет хранимую процедуру
                command.CommandType = System.Data.CommandType.StoredProcedure;
                SqlDataReader reader = command.ExecuteReader();

                if (reader.HasRows)
                {
                    while (reader.Read())
                    {                        
                        int id = reader.GetInt32(0);
                        string author = reader.GetString(1);
                        string name = reader.GetString(2);
                        string content = reader.GetString(3);
                        int year = reader.GetInt32(4);
                        int numberOfVolumes = reader.GetInt32(5);

                        Book book = new Book(id, author, name, content, year, numberOfVolumes);
                        listBook.Add(book);
                    }
                }
                reader.Close();
            }

            return listBook;
        }

        /// <summary>
        /// Получить запись о книге
        /// </summary>
        public static Book LoadBook()
        {
            Book book = new Book(1,"","", "", 1,1);
            return book;
        }

        /// <summary>
        /// Добавить запись о книге
        /// </summary>
        //[HttpPost]
        public static void AddBook(Book newBook)
        {   
            // название хранимой процедуры
            string sqlExpression = "sp_InsertBook";

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();
                SqlCommand command = new SqlCommand(sqlExpression, connection);
                // указываем, что команда представляет хранимую процедуру
                command.CommandType = System.Data.CommandType.StoredProcedure;

                SqlParameter paramAuthor = new SqlParameter
                {
                    ParameterName = "@Author",
                    Value = newBook.Author
                };

                SqlParameter paramName = new SqlParameter
                {
                    ParameterName = "@Name",
                    Value = newBook.Name
                };

                SqlParameter paramContent = new SqlParameter
                {
                    ParameterName = "@Content",
                    Value = newBook.Content
                };

                SqlParameter paramYear = new SqlParameter
                {
                    ParameterName = "@Year",
                    Value = newBook.Year
                };

                SqlParameter paramNumberOfVolumes = new SqlParameter
                {
                    ParameterName = "@NumberOfVolumes",
                    Value = newBook.NumberOfVolumes
                };

                command.Parameters.Add(paramAuthor);
                command.Parameters.Add(paramName);
                command.Parameters.Add(paramContent);
                command.Parameters.Add(paramYear);
                command.Parameters.Add(paramNumberOfVolumes);

                var result = command.ExecuteNonQuery();
            }
        }

        /// <summary>
        /// Удалить запись о книге
        /// </summary>
        //[HttpPost]
        public static void DeleteBook(int id)
        {
            // название хранимой процедуры
            string sqlExpression = "sp_DeleteBook";

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();
                SqlCommand command = new SqlCommand(sqlExpression, connection);
                // указываем, что команда представляет хранимую процедуру
                command.CommandType = System.Data.CommandType.StoredProcedure;

                SqlParameter paramId = new SqlParameter
                {
                    ParameterName = "@Id",
                    Value = id
                };        
                
                command.Parameters.Add(paramId);

                var result = command.ExecuteNonQuery();
            }
        }

        /// <summary>
        /// Обновить запись о книге
        /// </summary>
        //[HttpPost]
        public static void UpdateBook(Book book)
        {
            // название хранимой процедуры
            string sqlExpression = "sp_UpdateBook";

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();
                SqlCommand command = new SqlCommand(sqlExpression, connection);
                // указываем, что команда представляет хранимую процедуру
                command.CommandType = System.Data.CommandType.StoredProcedure;

                SqlParameter paramAuthor = new SqlParameter
                {
                    ParameterName = "@Author",
                    Value = book.Author
                };

                SqlParameter paramName = new SqlParameter
                {
                    ParameterName = "@Name",
                    Value = book.Name
                };

                SqlParameter paramContent = new SqlParameter
                {
                    ParameterName = "@Content",
                    Value = book.Content
                };

                SqlParameter paramYear = new SqlParameter
                {
                    ParameterName = "@Year",
                    Value = book.Year
                };

                SqlParameter paramNumberOfVolumes = new SqlParameter
                {
                    ParameterName = "@NumberOfVolumes",
                    Value = book.NumberOfVolumes
                };

                command.Parameters.Add(paramAuthor);
                command.Parameters.Add(paramName);
                command.Parameters.Add(paramContent);
                command.Parameters.Add(paramYear);
                command.Parameters.Add(paramNumberOfVolumes);

                var result = command.ExecuteNonQuery();
            }
            return;
        }
    }
}