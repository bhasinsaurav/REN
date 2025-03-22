namespace RENAPI.APIContracts.Request
{
    public class RestaurantDetailRequest
    {
        public string restaurantName { get; set; } = null!;

        public string ContactNumber { get; set; } = null!;

        public virtual ICollection<RestaurantAddressRequest> RestaurantAddresses { get; set; } = new List<RestaurantAddressRequest>();
    }
}
