namespace MyWebAPIApp.Models
{
    public class ProductViewModel
    {
        public string ProductName { get; set; }
        public string Price { get; set; }
    }
    public class ProductModel:ProductViewModel
    {
        public Guid ProductId { get; set; }
    }
    public class ProductInfo
    {
        public Guid ProductId { get; set;}
        public string ProductName { get; set; }
        public double Price { get; set; }
        public string CategoryName { get; set; }
    }
}
