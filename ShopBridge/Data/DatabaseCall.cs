using Microsoft.Extensions.Configuration;
using ShopBridge.Models;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;

namespace ShopBridge.Data
{
    public class DatabaseCall
    {
        private readonly IConfiguration _config;
        private readonly string ConnectionString;

        public DatabaseCall(IConfiguration config)
        {
            _config = config;
            ConnectionString = _config.GetConnectionString("DefaultConnection");
        }
        public List<ProductDetails> GetProducts(string ID)
        {
            var ProcedureName = "GetShopBridgeProdutDetails";
            SqlDataReader ret;
            List<ProductDetails> productDetails = new List<ProductDetails>();
            var sqlConnection = new SqlConnection(ConnectionString);
            try
            {
                    using (var command = sqlConnection.CreateCommand())
                    {
                        command.CommandType = System.Data.CommandType.StoredProcedure;
                        command.CommandText = ProcedureName;
                        if (ID != null)
                        {
                            command.Parameters.Add(new SqlParameter("@ProductId", System.Data.SqlDbType.VarChar, 10) { Value = ID });
                        }
                        sqlConnection.Open();
                        ret = command.ExecuteReader();
                        if (ret != null)
                        {
                            productDetails = GetColumnToList(ret);
                        }
                    }
            }
            catch(Exception ex)
            {
                return productDetails;
            }
            finally
            {
                sqlConnection.Close();
            }

            return productDetails;
        }

        public List<ProductDetails> GetColumnToList(SqlDataReader result)
        {

            List<ProductDetails> productDetails = new List<ProductDetails>();
            var res = result;
            if (res.HasRows)
            {
                while (res.Read())
                {
                    var list = new ProductDetails();
                    list.ProductId = (string)result.GetValue(result.GetOrdinal("ProductId"));
                    list.SellerId = (string)result.GetValue(result.GetOrdinal("SellerId"));
                    list.Name = (string)result.GetValue(result.GetOrdinal("Name"));
                    list.Description = (string)result.GetValue(result.GetOrdinal("Description"));
                    list.Category = (string)result.GetValue(result.GetOrdinal("Category"));
                    list.Price = (decimal)result.GetValue(result.GetOrdinal("Price"));
                    list.Discount = (decimal)result.GetValue(result.GetOrdinal("Discount"));
                    list.SellingPrice = (decimal)result.GetValue(result.GetOrdinal("SellingPrice"));
                    list.QuantityLeft = (int)result.GetValue(result.GetOrdinal("QuantityLeft"));
                    list.QuantitySold = (int)result.GetValue(result.GetOrdinal("QuantitySold"));

                    productDetails.Add(list);
                }
            }
            return productDetails;
        }

        public string AddProduct(string Parameters)
        {
            string result = "FAIL";
            var ProcedureName = "AddProdutDetails";
            var sqlConnection = new SqlConnection(ConnectionString);
            try
            {
                    using (var command = sqlConnection.CreateCommand())
                    {
                        command.CommandType = System.Data.CommandType.StoredProcedure;
                        command.CommandText = ProcedureName;
                        if (Parameters != null)
                        {
                            command.Parameters.Add(new SqlParameter("@ProductDetails", System.Data.SqlDbType.VarChar, 10000) { Value = Parameters });
                        }
                        sqlConnection.Open();
                        var ret = command.ExecuteScalar();
                        if (ret != null)
                        {
                            result = Convert.ToString(ret);
                        }
                    }
            }
            catch(Exception ex) 
            {
                return result;
            }
            finally
            {
                sqlConnection.Close();
            }

            return result;
        }

        public string UpdateProduct(string Parameters)
        {
            string result = "FAIL";
            var ProcedureName = "UpdateProductDetails";
            var sqlConnection = new SqlConnection(ConnectionString);
            try
            {
                    using (var command = sqlConnection.CreateCommand())
                    {
                        command.CommandType = System.Data.CommandType.StoredProcedure;
                        command.CommandText = ProcedureName;
                        if (Parameters != null)
                        {
                            command.Parameters.Add(new SqlParameter("@ProductDetails", System.Data.SqlDbType.VarChar, 10000) { Value = Parameters });
                        }
                        sqlConnection.Open();
                        var ret = command.ExecuteScalar();
                        if (ret != null)
                        {
                            result = Convert.ToString(ret);
                        }
                    }
            }
            catch(Exception ex) 
            {
                return result;
            }
            finally
            {
                sqlConnection.Close();
            }

            return result;
        }

        public string RemoveProduct(string ProductId, string SellerId)
        {
            var ProcedureName = "DeleteProduct";
            string result = "FAIL";
            List<ProductDetails> productDetails = new List<ProductDetails>();
            var sqlConnection = new SqlConnection(ConnectionString);
            try
            {
                    using (var command = sqlConnection.CreateCommand())
                    {
                        command.CommandType = System.Data.CommandType.StoredProcedure;
                        command.CommandText = ProcedureName;
                        if (ProductId != null && SellerId != null)
                        {
                            command.Parameters.Add(new SqlParameter("@SellerId", System.Data.SqlDbType.VarChar, 10) { Value = SellerId });
                            command.Parameters.Add(new SqlParameter("@ProductId", System.Data.SqlDbType.VarChar, 10) { Value = ProductId });
                        }
                        sqlConnection.Open();
                        var ret = command.ExecuteScalar();
                        if (ret != null)
                        {
                            result = Convert.ToString(ret);
                        }
                    }
            }
            catch(Exception ex) 
            {
                return result;
            }
            finally
            {
                sqlConnection.Close();
            }
            return result;
        }
    }
}
