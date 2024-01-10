namespace MyWebAPIApp.Data
{
    public enum OrderStatus
    {
        New = 0, Payment = 1, Complete = 2, Cancel = -1
    }
    public class Order
    {
        public Guid OrderId { get; set; }
        public DateTime CreateTime { get; set; }
        public DateTime ShipTime { get; set; }
        public OrderStatus Status { get; set; }
        public string CustomerName { get; set; }
        public string CustomerAddress { get; set; }
        public string CustomerPhone { get; set; }

        public ICollection<OrderDetail> OrderDetails { get; set; }
        public Order()
        {
            OrderDetails = new List<OrderDetail>();
        }
    }
}
