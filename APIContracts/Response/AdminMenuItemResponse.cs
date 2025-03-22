namespace RENAPI.APIContracts.Response
{
    public class AdminMenuItemResponse
    {
        public string itemStatus { get; set; } = null!;

        public string itemName { get; set; } = null!;

        public string itemDescription { get; set; } = null!;

        public decimal price { get; set; }
    }
}
