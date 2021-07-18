using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using ShopBridge.Models;
using ShopBridge.Interfaces;
using log4net;
using log4net.Core;
using System;

namespace ShopBridge.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ShopBridgeApiController : ControllerBase
    {
        private readonly IShopBridgeApi _shopBridgeApiService;
        public ShopBridgeApiController(IShopBridgeApi shopBridgeApi)
        {
            _shopBridgeApiService = shopBridgeApi;
        }
        [HttpGet]
        public List<ProductDetails> GetDetailsOfProduct(string id = "")
        {
            
                ProductDetails pd = new ProductDetails();
                List<ProductDetails> list = new List<ProductDetails>();
                list = _shopBridgeApiService.GetProductDetails(id);
                return list;
            
        }

        [HttpPost]
        public string AddProductDetails([FromBody] ProductDetails product)
        {
            string result = "";
            result = _shopBridgeApiService.AddProduct(product);
            return result;
        }

        [HttpDelete]
        public string RemoveProduct([FromBody] DeleteRequest request)
        {
            string result = "";
            result = _shopBridgeApiService.RemoveProduct(request);
            return result;
        }

        [HttpPut]
        public string UpdateProduct([FromBody] ProductDetails product)
        {
            string result = "";
            result = _shopBridgeApiService.UpdateProduct(product);
            return result;
        }
    }
}
