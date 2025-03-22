namespace RENAPI.APIContracts.Response
{
    public class CustomerOrderResponse
    {
        public string OrderStatus { get; set; } = null!;
        public int OrderId { get; set; }
        public int? RestaurantId { get; set; }
        public int? CustomerIdentifier { get; set; }
        public decimal TotalAmount { get; set; }
        public virtual ICollection<CustomerOrderItemResponse> OrderItems { get; set; } = null!;
    }
}
