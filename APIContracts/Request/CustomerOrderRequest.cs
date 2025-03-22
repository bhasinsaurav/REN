namespace RENAPI.APIContracts.Request
{
    public class CustomerOrderRequest
    {
        public int RestaurantId { get; set; }
        public int customerIdentifier { get; set; } 

        public decimal TotalAmount { get; set; }

        public virtual ICollection<CustomerOrderItemRequest> orderItems { get; set; } = null!;
    }
}
