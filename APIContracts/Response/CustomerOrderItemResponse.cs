namespace RENAPI.APIContracts.Response
{
    public class CustomerOrderItemResponse
    {
        public int OrderItemId { get; set; }
        public string Menuitem { get; set; } = null!;
        public int Quantity { get; set; }
    }
}
