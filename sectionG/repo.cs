using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;

namespace PlainADORepositoryUoW
{
    // ===== Entities =====
    public class Product
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public decimal Price { get; set; }
    }

    public class Category
    {
        public int Id { get; set; }
        public string Name { get; set; }
    }

    // ===== Generic Repository Interface =====
    public interface IRepository<T> where T : class
    {
        T GetById(int id);
        List<T> GetAll();
        void Add(T entity);
        void Update(T entity);
        void Remove(T entity);
    }

    // ===== Product Repository =====
    public class ProductRepository : IRepository<Product>
    {
        private readonly SqlConnection _connection;
        private readonly SqlTransaction _transaction;

        public ProductRepository(SqlConnection connection, SqlTransaction transaction)
        {
            _connection = connection;
            _transaction = transaction;
        }

        public Product GetById(int id)
        {
            var cmd = new SqlCommand("SELECT Id, Name, Price FROM Products WHERE Id=@Id", _connection, _transaction);
            cmd.Parameters.AddWithValue("@Id", id);

            using var reader = cmd.ExecuteReader();
            if (reader.Read())
            {
                return new Product
                {
                    Id = (int)reader["Id"],
                    Name = (string)reader["Name"],
                    Price = (decimal)reader["Price"]
                };
            }
            return null;
        }

        public List<Product> GetAll()
        {
            var cmd = new SqlCommand("SELECT Id, Name, Price FROM Products", _connection, _transaction);
            var list = new List<Product>();
            using var reader = cmd.ExecuteReader();
            while (reader.Read())
            {
                list.Add(new Product
                {
                    Id = (int)reader["Id"],
                    Name = (string)reader["Name"],
                    Price = (decimal)reader["Price"]
                });
            }
            return list;
        }

        public void Add(Product entity)
        {
            var cmd = new SqlCommand("INSERT INTO Products (Name, Price) VALUES (@Name,@Price)", _connection, _transaction);
            cmd.Parameters.AddWithValue("@Name", entity.Name);
            cmd.Parameters.AddWithValue("@Price", entity.Price);
            cmd.ExecuteNonQuery();
        }

        public void Update(Product entity)
        {
            var cmd = new SqlCommand("UPDATE Products SET Name=@Name, Price=@Price WHERE Id=@Id", _connection, _transaction);
            cmd.Parameters.AddWithValue("@Name", entity.Name);
            cmd.Parameters.AddWithValue("@Price", entity.Price);
            cmd.Parameters.AddWithValue("@Id", entity.Id);
            cmd.ExecuteNonQuery();
        }

        public void Remove(Product entity)
        {
            var cmd = new SqlCommand("DELETE FROM Products WHERE Id=@Id", _connection, _transaction);
            cmd.Parameters.AddWithValue("@Id", entity.Id);
            cmd.ExecuteNonQuery();
        }
    }

    // ===== Category Repository =====
    public class CategoryRepository : IRepository<Category>
    {
        private readonly SqlConnection _connection;
        private readonly SqlTransaction _transaction;

        public CategoryRepository(SqlConnection connection, SqlTransaction transaction)
        {
            _connection = connection;
            _transaction = transaction;
        }

        public Category GetById(int id)
        {
            var cmd = new SqlCommand("SELECT Id, Name FROM Categories WHERE Id=@Id", _connection, _transaction);
            cmd.Parameters.AddWithValue("@Id", id);

            using var reader = cmd.ExecuteReader();
            if (reader.Read())
            {
                return new Category
                {
                    Id = (int)reader["Id"],
                    Name = (string)reader["Name"]
                };
            }
            return null;
        }

        public List<Category> GetAll()
        {
            var cmd = new SqlCommand("SELECT Id, Name FROM Categories", _connection, _transaction);
            var list = new List<Category>();
            using var reader = cmd.ExecuteReader();
            while (reader.Read())
            {
                list.Add(new Category
                {
                    Id = (int)reader["Id"],
                    Name = (string)reader["Name"]
                });
            }
            return list;
        }

        public void Add(Category entity)
        {
            var cmd = new SqlCommand("INSERT INTO Categories (Name) VALUES (@Name)", _connection, _transaction);
            cmd.Parameters.AddWithValue("@Name", entity.Name);
            cmd.ExecuteNonQuery();
        }

        public void Update(Category entity)
        {
            var cmd = new SqlCommand("UPDATE Categories SET Name=@Name WHERE Id=@Id", _connection, _transaction);
            cmd.Parameters.AddWithValue("@Name", entity.Name);
            cmd.Parameters.AddWithValue("@Id", entity.Id);
            cmd.ExecuteNonQuery();
        }

        public void Remove(Category entity)
        {
            var cmd = new SqlCommand("DELETE FROM Categories WHERE Id=@Id", _connection, _transaction);
            cmd.Parameters.AddWithValue("@Id", entity.Id);
            cmd.ExecuteNonQuery();
        }
    }

    // ===== Unit of Work Interface =====
    public interface IUnitOfWork : IDisposable
    {
        IRepository<Product> Products { get; }
        IRepository<Category> Categories { get; }
        void Commit();
        void Rollback();
    }

    // ===== Unit of Work Implementation =====
    public class UnitOfWork : IUnitOfWork
    {
        private readonly SqlConnection _connection;
        private readonly SqlTransaction _transaction;

        public IRepository<Product> Products { get; private set; }
        public IRepository<Category> Categories { get; private set; }

        public UnitOfWork(string connectionString)
        {
            _connection = new SqlConnection(connectionString);
            _connection.Open();
            _transaction = _connection.BeginTransaction();

            Products = new ProductRepository(_connection, _transaction);
            Categories = new CategoryRepository(_connection, _transaction);
        }

        public void Commit()
        {
            try
            {
                _transaction.Commit();
            }
            catch
            {
                _transaction.Rollback();
                throw;
            }
            finally
            {
                _connection.Close();
            }
        }

        public void Rollback()
        {
            _transaction.Rollback();
            _connection.Close();
        }

        public void Dispose()
        {
            _transaction?.Dispose();
            _connection?.Dispose();
        }
    }

    // ===== Example Usage =====
    class Program
    {
        static void Main(string[] args)
        {
            string connectionString = "Server=localhost;Database=MyDb;Trusted_Connection=True;";

            using (var uow = new UnitOfWork(connectionString))
            {
                try
                {
                    // Add a category
                    var category = new Category { Name = "Electronics" };
                    uow.Categories.Add(category);

                    // Add a product
                    var product = new Product { Name = "Laptop", Price = 1200m };
                    uow.Products.Add(product);

                    // Retrieve all products
                    var products = uow.Products.GetAll();
                    foreach (var p in products)
                    {
                        Console.WriteLine($"Product: {p.Name}, Price: {p.Price}");
                    }

                    // Commit the transaction
                    uow.Commit();

                   
                }
                catch (Exception ex)
                {
                    Console.WriteLine($"Error: {ex.Message}");
                    uow.Rollback();
                }
            }
        }
    }
}
