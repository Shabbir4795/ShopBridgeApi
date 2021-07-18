using System;
using Xunit;
using ShopBridge.Controllers;
using System.Collections.Generic;
using ShopBridge.Models;
using ShopBridge.Interfaces;
using ShopBridge.Services;
using Moq;

namespace ShopBridgeTests
{
    public class UnitTest1
    {
        [Fact]
        public void GetAllProductDetails()
        {
            List<ProductDetails> list = new List<ProductDetails>();
            var mockRepo = new Mock<IShopBridgeApi>();
            mockRepo.Setup(x => x.GetProductDetails("")).Returns(list);
        }
        [Theory]
        [InlineData("234")]
        public void GetProductDetailsByProductId(string id)
        {
            List<ProductDetails> list = new List<ProductDetails>();
            var mockRepo = new Mock<IShopBridgeApi>();
            mockRepo.Setup(x => x.GetProductDetails(id)).Returns(list);
        }
        [Fact]
        public void AddProduct()
        {
            var product = new ProductDetails();
            product.ProductId = "000";
            product.SellerId = "111";
            product.Name = "mouse";
            product.Category = "electronice";
            product.Description = "computers";
            product.Price = 350;
            product.Discount = 35;
            product.SellingPrice = 315;
            product.QuantityLeft = 10;
            product.QuantitySold = 25;

            string result = "SUCCESS";
            var mockRepo = new Mock<IShopBridgeApi>();
            mockRepo.Setup(x => x.AddProduct(product)).Returns(result);
        }

        [Theory]
        [InlineData("000", "111")]
        public void RemoveProduct(string ProductId, string SellerId)
        {
            var DeleteRecord = new DeleteRequest();
            DeleteRecord.ProductId = ProductId;
            DeleteRecord.SellerId = SellerId;
            string result = "SUCCESS";
            var mockRepo = new Mock<IShopBridgeApi>();
            mockRepo.Setup(x => x.RemoveProduct(DeleteRecord)).Returns(result);
        }

        [Fact]
        public void UpdateProduct()
        {
            var product = new ProductDetails();
            product.ProductId = "000";
            product.SellerId = "111";
            product.Name = "keyboard";
            product.Category = "electronice";
            product.Description = "computers";
            product.Price = 550;
            product.Discount = 55;
            product.SellingPrice = 495;
            product.QuantityLeft = 15;
            product.QuantitySold = 15;

            string result = "SUCCESS";
            var mockRepo = new Mock<IShopBridgeApi>();
            mockRepo.Setup(x => x.UpdateProduct(product)).Returns(result);
        }
    }
}
