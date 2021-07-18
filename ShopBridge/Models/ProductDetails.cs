

namespace ShopBridge.Models
{
    public class ProductDetails
    {
        //public int Id { get; set; }
        public string ProductId { get; set; }
        public string SellerId { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public string Category { get; set; }
        public decimal Price { get; set; }
        public decimal Discount { get; set; }
        public decimal SellingPrice { get; set; }
        public int QuantitySold { get; set; }
        public int QuantityLeft { get; set; }
    }
}
