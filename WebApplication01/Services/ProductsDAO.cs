using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;
using WebApplication01.Models;

namespace WebApplication01.Services
{
    public class ProductsDAO : IProductDataService
    {
        string connectionString = @"Data Source=(localdb)\MSSQLLocalDB;Initial Catalog=Test;Integrated Security=True;
                                   Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;
                                   MultiSubnetFailover=False";
        public int Delete(ProductModel product)
        {
            int newIdNumber = -1;

            string sqlStatement = "DELETE FROM dbo.Products WHERE Id = @Id";

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                SqlCommand command = new SqlCommand(sqlStatement, connection);

                command.Parameters.AddWithValue("@Id", product.Id);




                try
                {
                    connection.Open();
                    newIdNumber = Convert.ToInt32(command.ExecuteScalar());
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);

                }

                return newIdNumber;

            }
        }



        public List<ProductModel> GetAllProducts()
        {
            List<ProductModel> foundProducts = new List<ProductModel>();

            string sqlStatement = "SELECT * FROM dbo.Products";

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                SqlCommand command = new SqlCommand(sqlStatement, connection);

                try
                {
                    connection.Open();

                    SqlDataReader reader = command.ExecuteReader();
                    while (reader.Read())
                    {
                        foundProducts.Add(new ProductModel
                        {
                            Id = (int)reader[0],
                            Name = (string)reader[1],
                            Price = (decimal)reader[2],
                            Description = (string)reader[3]
                        });
                    }

                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);

                }

                return foundProducts;
            }
        }

        public ProductModel GetProductById(int id)
        {
            ProductModel foundProducts = null;

            string sqlStatement = "SELECT * FROM dbo.Products WHERE Id = @Id";

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                SqlCommand command = new SqlCommand(sqlStatement, connection);
                command.Parameters.AddWithValue("@Id", id);

                try
                {
                    connection.Open();

                    SqlDataReader reader = command.ExecuteReader();
                    while (reader.Read())
                    {
                        foundProducts = new ProductModel
                        {
                            Id = (int)reader[0],
                            Name = (string)reader[1],
                            Price = (decimal)reader[2],
                            Description = (string)reader[3]
                        };
                    }

                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);

                }

                return foundProducts;

            }
        }

        public int Insert(ProductModel product)
        {
            int NewId = -1;
            string sqlStatement = "INSERT INTO dbo.Products (Name, Price, Description) VALUES (@name, @Price, @description)";
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                SqlCommand command = new SqlCommand(sqlStatement, connection);
                command.Parameters.AddWithValue("@name", product.Name);
                command.Parameters.AddWithValue("@price", product.Price);
                command.Parameters.AddWithValue("@description", product.Description);
                try
                {
                    connection.Open();
                    NewId = Convert.ToInt32(command.ExecuteScalar()); 
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                    throw;
                }
            }

            return NewId;
        }
    



        public List<ProductModel> SearchProducts(string searchTerm)
        {
            List<ProductModel> foundProducts = new List<ProductModel>();

            string sqlStatement = "SELECT * FROM dbo.Products WHERE Name LIKE @Name";

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                SqlCommand command = new SqlCommand(sqlStatement, connection);
                command.Parameters.AddWithValue("@Name", '%' + searchTerm + '%');

                try
                {
                    connection.Open();

                    SqlDataReader reader = command.ExecuteReader();
                    while (reader.Read())
                    {
                        foundProducts.Add(new ProductModel
                        {
                            Id = (int)reader[0],
                            Name = (string)reader[1],
                            Price = (decimal)reader[2],
                            Description = (string)reader[3]
                        });
                    }

                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);

                }

                return foundProducts;

            }
        }

        public int Update(ProductModel product)
        {

            int newIdNumber = -1;

            string sqlStatement = "UPDATE dbo.Products Set Name = @Name, Price = @Price, Description = @Description WHERE Id = @Id";

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                SqlCommand command = new SqlCommand(sqlStatement, connection);
                command.Parameters.AddWithValue("@Name", product.Name);
                command.Parameters.AddWithValue("@Price", product.Price);
                command.Parameters.AddWithValue("@Description", product.Description);
                command.Parameters.AddWithValue("@Id", product.Id);




                try
                {
                    connection.Open();
                    newIdNumber = Convert.ToInt32(command.ExecuteScalar());
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);

                }

                return newIdNumber;

            }
        }
    }
}
