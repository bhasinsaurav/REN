namespace RENAPI.APIContracts.Request
{
    public class AdminRegisterRequest
    {
        public string FirstName { get; set; } = null!;

        public string LastName { get; set; } = null!;

        public string Email { get; set; } = null!;

        public string Password { get; set; } = null!;

        public virtual ICollection<RestaurantDetailRequest> RestaurantDetails { get; set; } = new List<RestaurantDetailRequest>();
    }
}
