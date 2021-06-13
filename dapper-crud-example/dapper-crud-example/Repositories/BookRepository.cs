using Dapper;
using dapper_crud_example.Models;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;

namespace dapper_crud_example.Repositories
{
    public class BookRepository : IBookRepository
    {

        private string connectionString;

        public BookRepository(IConfiguration configuration)
        {
            connectionString = configuration.GetConnectionString("db");
        }
        

        public IDbConnection Connection
        {
            get
            {
                return new SqlConnection(connectionString);
            }
        }

        public Book Add(Book book)
        {
            using (IDbConnection dbConnection = Connection)
            {
                string sQuery = @"INSERT INTO Books (Title, Plot, Author) VALUES(@Title, @Plot, @Author)";
                dbConnection.Open();
                dbConnection.Execute(sQuery, book);
            }
            return book;
        }

        public void Delete(int id)
        {
            using (IDbConnection dbConnection = Connection)
            {
                string sQuery = @"DELETE FROM Books Where BookId=@Id";
                dbConnection.Open();
                dbConnection.Execute(sQuery, new { Id = id });
            }
        }

        public IEnumerable<Book> GetAll()
        {
            using (IDbConnection dbConnection = Connection)
            {
                string sQuery = @"Select * FROM Books";
                dbConnection.Open();
                return dbConnection.Query<Book>(sQuery);
            }
        }

        public Book GetById(int id)
        {
            using (IDbConnection dbConnection = Connection)
            {
                string sQuery = @"Select * FROM Books Where BookId=@Id";
                dbConnection.Open();
                return dbConnection.Query<Book>(sQuery, new { Id = id }).FirstOrDefault();
            }
        }

        public void Update(Book book)
        {
            using (IDbConnection dbConnection = Connection)
            {
                string sQuery = @"UPDATE Books SET Title=@Title, Plot=@Plot, Author=@Author Where BookId=@BookId";
                dbConnection.Open();
                dbConnection.Query(sQuery, book);
            }
        }
    }
}
