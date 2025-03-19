namespace RENAPI.APIContracts.Request
{
    public class AdminMenuItemRequest
    {
        public string token { get; set; } = null!;
        public int RestaurantId { get; set; }

        public string ItemName { get; set; } = null!;

        public decimal Price { get; set; }

        public string ItemDescription { get; set; } = null!;

    }
}
