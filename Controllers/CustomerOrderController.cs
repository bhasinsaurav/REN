using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.SignalR;
using Microsoft.EntityFrameworkCore;
using REN.Models;
using RENAPI.APIContracts.Request;
using RENAPI.APIContracts.Response;
using RENAPI.Hubs;
using RENAPI.Services;

namespace RENAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CustomerOrderController : ControllerBase
    {
        private readonly RenContext _dbContext;
        private readonly IHubContext<ConnectionHub> _hubContext;
        private readonly IConnection _connectionService;

        public CustomerOrderController(RenContext dbContext, IHubContext<ConnectionHub> hubContext, IConnection connection)
        {
            _dbContext = dbContext;
            _hubContext = hubContext;
            _connectionService = connection;
        }

        [HttpPost]
        public async Task<IActionResult> PostOrderRequest([FromBody]CustomerOrderRequest orderRequest)
        {
            var restaurantConnectionId = _connectionService.getAdminConnectionId(orderRequest.RestaurantId);

            if (orderRequest == null || orderRequest.customerIdentifier == 0 || orderRequest.RestaurantId == 0)
            {
                return BadRequest("Invalid order request");
            }

            var OrderRequest = new Ordertable
            {
                
                RestaurantId = orderRequest.RestaurantId,
                TotalAmount = orderRequest.TotalAmount,
                OrderItems = orderRequest.orderItems.Select(oi => new OrderItem
                {
                    MenuitemId = oi.MenuitemId,
                    Quantity = oi.Quantity
                }).ToList()
            };

            _dbContext.Ordertables.Add(OrderRequest);
            await _dbContext.SaveChangesAsync();

            var OrderTabel =  await _dbContext.Ordertables
                              .Include(s => s.Status)
                              .FirstOrDefaultAsync(o => o.OrderId == OrderRequest.OrderId);

            var orderItems = await _dbContext.OrderItems
                            .Include(mi => mi.Menuitem)
                            .Where(oi => oi.OrderId == OrderRequest.OrderId)
                            .ToListAsync();


            var orderResponse = new CustomerOrderResponse
            {
                OrderStatus = OrderTabel.Status.StatusName,
                OrderId = OrderTabel.OrderId,
                RestaurantId = OrderTabel.RestaurantId,
                CustomerIdentifier = OrderRequest.CustomerId,
                TotalAmount = OrderTabel.TotalAmount,
                OrderItems = orderItems.Select(oi => new CustomerOrderItemResponse
                {
                    OrderItemId = oi.ItemId,
                    Menuitem = oi.Menuitem.ItemName,
                    Quantity = oi.Quantity
                }).ToList()
            };
            if (!string.IsNullOrEmpty(restaurantConnectionId))
            {
                await _hubContext.Clients.Client(restaurantConnectionId).SendAsync("NewOrder", OrderRequest);
            }
            return Ok(orderResponse);
        }
    }
}
