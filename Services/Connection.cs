namespace RENAPI.Services
{
    public class Connection : IConnection
    {
        private static readonly Dictionary<int, string> _adminConnections = new();
        private static readonly Dictionary<int, string> _customerConnections = new();
        void IConnection.addAdminConnection(int restaurantId, string ConnectionId)
        {
            if (_adminConnections.ContainsKey(restaurantId))
            {
                _adminConnections[restaurantId] = ConnectionId;  // Update the connection ID if already exists
            }
            else
            {
                _adminConnections.Add(restaurantId, ConnectionId);  // Add a new connection
            }
        }

        void IConnection.addCustomerConnection(int customerId, string ConnectionId)
        {
            if (_customerConnections.ContainsKey(customerId))
            {
                _customerConnections[customerId] = ConnectionId;  // Update the connection ID if already exists
            }
            else
            {
                _customerConnections.Add(customerId, ConnectionId);  // Add a new connection
            }
        }

        public string getAdminConnectionId(int restaurantId)
        {
            return _adminConnections[restaurantId];
        }

        public string getCustomerConnectionId(int customerId)
        {
            return _customerConnections[customerId];
        }
    }
}
