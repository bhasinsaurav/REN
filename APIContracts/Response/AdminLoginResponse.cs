namespace RENAPI.APIContracts.Response
{
    public class AdminLoginResponse
    {
        public string? Token { get; set; }

        public int RestaurantId { get; set; }

        public string RestaurantName { get; set; } = null!;
    }
}
