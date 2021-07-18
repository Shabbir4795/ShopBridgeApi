using System;
using System.Collections.Generic;
using System.Xml.Serialization;
using Microsoft.Extensions.Configuration;
using ShopBridge.Interfaces;
using ShopBridge.Models;
using ShopBridge.Data;


namespace ShopBridge.Services
{
    public class ShopBridgeApiService : IShopBridgeApi
    {
        private readonly DatabaseCall _databaseCall;

        public ShopBridgeApiService(IConfiguration config, DatabaseCall db)
        {
            _databaseCall = db;
        }
        public List<ProductDetails> GetProductDetails(string ID)
        {             
            List<ProductDetails> productDetails = new List<ProductDetails>();
            try
            {
                productDetails = _databaseCall.GetProducts(ID);
            }
            catch (Exception ex)
            {
                return productDetails;
            }
            return productDetails;
        }

        public string AddProduct(ProductDetails product)
        {
            string result = "FAIL";
            string parameter;
            try 
            {
            var serializer = new XmlSerializer(product.GetType());
            using (var stringwriter = new System.IO.StringWriter())
            {
                
                serializer.Serialize(stringwriter, product);
                parameter = stringwriter.ToString();
                parameter = parameter.Replace("<?xml version=\"1.0\" encoding=\"utf-16\"?>", "");
                parameter = parameter.Replace("<?xml version?>", "");
            }
            result = _databaseCall.AddProduct(parameter);
            }
            catch (Exception ex)
            {
                return result;
            }
            return result;
        }

        public string RemoveProduct(DeleteRequest request)
        {
            string result = "FAIL";
            try
            {
                result = _databaseCall.RemoveProduct(request.ProductId, request.SellerId);
            }
            catch (Exception ex)
            {
                return result;
            }
            return result;
        }

        public string UpdateProduct(ProductDetails product)
        {
            string result = "FAIL";
            string parameter;
            var serializer = new XmlSerializer(product.GetType());

            try
            {
                using (var stringwriter = new System.IO.StringWriter())
                {

                    serializer.Serialize(stringwriter, product);
                    parameter = stringwriter.ToString();
                    parameter = parameter.Replace("<?xml version=\"1.0\" encoding=\"utf-16\"?>", "");
                    parameter = parameter.Replace("<?xml version?>", "");
                }
                result = _databaseCall.UpdateProduct(parameter);
            }
            catch(Exception ex)
            {
                return result;
            }

            return result;
        }
    }
}
