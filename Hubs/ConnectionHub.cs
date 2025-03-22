using Microsoft.AspNetCore.SignalR;
using RENAPI.Services;


namespace RENAPI.Hubs
{
    public class ConnectionHub : Hub
    {
        private readonly IConnection _connectionService;

        public ConnectionHub(IConnection connection)
        { 
            _connectionService = connection;
        }

        public async Task ConnectAdmin(int restaurantId)
        {
            // Store the connection ID for the admin based on the restaurant ID
            _connectionService.addAdminConnection(restaurantId, Context.ConnectionId);

            // Notify the admin that they've connected
            await Clients.Caller.SendAsync("Connected", "Admin connected successfully!");
        }

        public async Task ConnectCustomer(int customerId)
        {
            _connectionService.addAdminConnection(customerId, Context.ConnectionId);
            await Clients.Caller.SendAsync("Connected", "Customer connected successfully!");
        }

        
    }
}
