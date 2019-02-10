using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.SqlClient;

namespace ProdPay.Models
{

    public class ProductModel {

        public int ProductID { get; set; }
        public string ProductName { get; set; }
        public string ProductDescription { get; set; }
        public double ProductPrice { get; set; }
    }

    public class ProductOperations
    {
        public string connectionString = "Initial Catalog=TSTDB;Data Source=danlaptop;Password=M!ss1ssauga;Persist Security Info=True;User ID=usrone;";
        public void Create(ProductModel model)
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                if (connection.State != System.Data.ConnectionState.Open) { connection.Open(); }
                using (SqlCommand command = connection.CreateCommand())
                {
                    command.CommandText = "insert into Products values(@ProductName,@ProductDescription,@ProductPrice)";
                    command.Parameters.AddWithValue("@ProductName", model.ProductName);
                    command.Parameters.AddWithValue("@ProductDescription", model.ProductDescription);
                    command.Parameters.AddWithValue("@ProductPrice", model.ProductPrice);
                    command.ExecuteNonQuery();
                }

            }
        }

        public ProductModel Find(int id)
        {
            var model = new ProductModel();
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                if (connection.State != System.Data.ConnectionState.Open) { connection.Open(); }
                using (SqlCommand command = connection.CreateCommand())
                {
                    command.CommandText = "select * from Products where ProductId=@Id";
                    command.Parameters.AddWithValue("@Id", id);
                    SqlDataReader reader = command.ExecuteReader();
                    while (reader.Read())
                    {
                        model.ProductID = id;
                        model.ProductName = reader["ProductName"].ToString();
                        model.ProductDescription = reader["ProductDescription"].ToString();
                        double amt = 0;
                        double.TryParse(reader["ProductPrice"].ToString(), out amt);
                        model.ProductPrice = amt;
                    }
                }
            }
            return model;
        }

        public void Delete(ProductModel model)
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                if (connection.State != System.Data.ConnectionState.Open) { connection.Open(); }
                using (SqlCommand command = connection.CreateCommand())
                {
                    command.CommandText = "delete from Products where ProductId=@Id";
                    command.Parameters.AddWithValue("@Id", model.ProductID);
                    command.ExecuteNonQuery();
                }
            }
        }

        public void Delete(int id)
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                if (connection.State != System.Data.ConnectionState.Open) { connection.Open(); }
                using (SqlCommand command = connection.CreateCommand())
                {
                    command.CommandText = "delete from Products where ProductId=@Id";
                    command.Parameters.AddWithValue("@Id", id);
                    command.ExecuteNonQuery();
                }
            }
        }

        public void Edit(ProductModel model)
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                if (connection.State != System.Data.ConnectionState.Open) { connection.Open(); }
                using (SqlCommand command = connection.CreateCommand())
                {
                    command.CommandText = "Update Products set ProductName=@ProductName, ProductDescription=@ProductDescription,ProductPrice=@ProductPrice where ProductId=@Id";
                    command.Parameters.AddWithValue("@ProductName", model.ProductName);
                    command.Parameters.AddWithValue("@ProductDescription", model.ProductDescription);
                    command.Parameters.AddWithValue("@ProductPrice", model.ProductPrice);
                    command.Parameters.AddWithValue("@Id", model.ProductID);
                    command.ExecuteNonQuery();
                }
            }
        }

        public List<ProductModel> LoadProducts()
        {
            var models = new List<ProductModel>();
            using (SqlConnection connection = new SqlConnection(connectionString)) {
                if (connection.State != System.Data.ConnectionState.Open) { connection.Open(); }
                using (SqlCommand command = connection.CreateCommand())
                {
                    command.CommandText = "select * from Products";
                    SqlDataReader reader = command.ExecuteReader();
                    while (reader.Read())
                    {
                        ProductModel model = new ProductModel();
                        int prodID = 0;
                        int.TryParse(reader["ProductId"].ToString(), out prodID);
                        model.ProductID = prodID;
                        model.ProductName = reader["ProductName"].ToString();
                        model.ProductDescription = reader["ProductDescription"].ToString();
                        double amt = 0;
                        double.TryParse(reader["ProductPrice"].ToString(), out amt);
                        model.ProductPrice = amt;
                        models.Add(model);
                    }
                }

            }
            return models;
        }


    }
}