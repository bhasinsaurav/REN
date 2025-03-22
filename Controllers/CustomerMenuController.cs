using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.SignalR;
using Microsoft.EntityFrameworkCore;
using REN.Models;
using RENAPI.APIContracts.Request;
using RENAPI.APIContracts.Response;

namespace RENAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CustomerMenuController : ControllerBase
    {
        private readonly RenContext _context;

        public CustomerMenuController(RenContext dbContext) 
        { 
            _context = dbContext;
        }
        [HttpGet]
        public async Task<IActionResult> GetMenu([FromQuery]customerMenuRequest getMenu) 
        {
            if (getMenu == null || string.IsNullOrEmpty(getMenu.userIdentifier) || getMenu.RestaurantId == 0)
            {
                return BadRequest("Invalid User Details");
            }
   

            var getMenuItems = await _context.Menuitems.Where(m => m.RestaurantId == getMenu.RestaurantId).ToListAsync();

            var UserGetMenuResponse = new CustomerGetMenuResponse
            {
                getMenuItems = getMenuItems.Select(mi => new CustomerMenuItemResponse
                {
                    menuItemId = mi.ItemId,
                    itemName = mi.ItemName,
                    price = mi.Price,
                    itemDescription = mi.Description
                }).ToList()
            };

            return Ok(UserGetMenuResponse);

        }

    }
}
