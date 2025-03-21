using Microsoft.AspNetCore.SignalR;

namespace RENAPI.Hubs
{
    public class ConnectionHub : Hub
    {
        // Store connections by restaurant ID
        private static readonly Dictionary<int, string> _adminConnections = new();
        private static readonly Dictionary<string, string> _customerConnections = new();

        // Called when the admin logs in
        public async Task ConnectAdmin(int restaurantId)
        {
            // Store the connection ID for the admin based on the restaurant ID
            _adminConnections[restaurantId] = Context.ConnectionId;

            // Notify the admin that they've connected
            await Clients.Caller.SendAsync("Connected", "Admin connected successfully!");
        }

        public async Task ConnectCustomer(string customerId)
        {
            _customerConnections[customerId] = Context.ConnectionId;
            await Clients.Caller.SendAsync("Connected", "Customer connected successfully!");
        }

        public string getAdminConnectionId(int restaurantId)
        {
            return _adminConnections[restaurantId];
        }

        public string getcustomerConnectionId(string customerId)
        {
            return _customerConnections[customerId];
        }
    }
}
