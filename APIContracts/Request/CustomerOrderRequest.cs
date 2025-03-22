namespace RENAPI.APIContracts.Request
{
    public class CustomerOrderRequest
    {
        public int RestaurantId { get; set; }
        public string userIdentifier { get; set; } = null!;
        public virtual ICollection<CustomerOrderItemRequest> orderItems { get; set; } = null!;
    }
}
