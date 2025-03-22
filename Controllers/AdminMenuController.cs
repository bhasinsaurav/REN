using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using REN.Models;
using RENAPI.APIContracts.Request;
using RENAPI.APIContracts.Response;

namespace RENAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AdminMenuController : ControllerBase
    {
        private readonly RenContext _context;
        public AdminMenuController(RenContext dbContext) { 
            _context = dbContext;
        }

        [HttpPost("MenuItem")]
        public async Task<IActionResult> addMenuItem(AdminMenuItemRequest addMenuItem) {

            if (addMenuItem == null || string.IsNullOrEmpty(addMenuItem.ItemName) || addMenuItem.Price == 0)
            {
                return BadRequest("Invalid Menu Item Details");
            }

            var menuItem = new Menuitem
            {
                RestaurantId = addMenuItem.RestaurantId,
                ItemName = addMenuItem.ItemName,
                Price = addMenuItem.Price,
                Description = addMenuItem.ItemDescription
            };

            var menuItemResponse = new AdminMenuItemResponse
            {
                itemStatus = "Item Added",
                itemName = menuItem.ItemName,
                price = menuItem.Price,
                itemDescription = menuItem.Description
            };

            _context.Menuitems.Add(menuItem);
            await _context.SaveChangesAsync();

            
            return Ok(menuItemResponse);
        }
    }
}
