namespace RENAPI.Services
{
    public interface IConnection
    {
        void addAdminConnection(int restaurantId, string ConnectionId);
        void addCustomerConnection(int customerId, string ConnectionId);

        string getAdminConnectionId(int restaurantId);

        string getCustomerConnectionId(int customerId);

    }
}
