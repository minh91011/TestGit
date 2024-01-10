namespace MyWebAPIApp.Data
{
    public class OrderDetail
    {
        public Guid ProductId { get; set; }
        public Guid OrderId { get; set; }
        public int NumberOfProduct { get; set; }
        public double Price { get; set; }
        public byte Discount { get; set; }

        //realtionship
        public Order Orders { get; set; }
        public Product Products { get; set; }
    }
}
