using System.Collections.Generic;
using ShopBridge.Models;

namespace ShopBridge.Interfaces
{
    public interface IShopBridgeApi
    {
        //private List<ProductDetails> GetAllProductDetails(int Id);

        List<ProductDetails> GetProductDetails(string ID);

        string AddProduct(ProductDetails product);

        string RemoveProduct(DeleteRequest request);

        string UpdateProduct(ProductDetails product);
    }
}
