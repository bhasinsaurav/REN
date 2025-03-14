namespace RENAPI.APIContracts.Request
{
    public class RestaurantAddressRequest
    {
        public string Country { get; set; } = null!;
        public string City { get; set; } = null!;
        public string? StreetName { get; set; }
        public string StreetAddress { get; set; } = null!;
        public string? PinCode { get; set; }
        public string? Province { get; set; }
    }
}
