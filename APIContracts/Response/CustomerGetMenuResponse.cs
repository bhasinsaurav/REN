namespace RENAPI.APIContracts.Response
{
    public class CustomerGetMenuResponse
    {
        public virtual ICollection<CustomerMenuItemResponse> getMenuItems { get; set; } = null!;
    }
}
