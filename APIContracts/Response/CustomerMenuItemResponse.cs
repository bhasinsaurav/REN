namespace RENAPI.APIContracts.Response
{
    public class CustomerMenuItemResponse
    {
        public int menuItemId { get; set; }
        public string itemName { get; set; } = null!;
        public decimal price { get; set; }
        public string itemDescription { get; set; } = null!;
    }
}
