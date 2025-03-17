using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.Data;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using REN.Models;
using RENAPI.APIContracts.Request;
using RENAPI.APIContracts.Response;

namespace RENAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AdminLoginController : ControllerBase
    {
        private UserManager<User> _userManager;
        private readonly SignInManager<User> _signinManager;
        private readonly string? _jwtKey;
        private readonly RenContext _context;

        public AdminLoginController(UserManager<User> userManager, SignInManager<User> signinManager, IConfiguration configuration, RenContext dbContext)
        {
            _userManager = userManager;
            _signinManager = signinManager;
            _jwtKey = configuration["Jwt:Key"];
            _context = dbContext;
        }

        [HttpPost("Login")]
        public async Task<IActionResult> Login([FromBody] AdminLoginRequest loginRequest)
        {
            var user = await _userManager.FindByEmailAsync(loginRequest.Username);

            if (user == null)
            {
                return Unauthorized(new { success = false, message = "Invalid username or password" });
            }

            var result = await _signinManager.CheckPasswordSignInAsync(user, loginRequest.Password, false);

            if (!result.Succeeded)
            {
                return Unauthorized(new { success = false, message = "Invalid username or password" });
            }

            int userId = user.Id;
            var token = GenerateJWTToken(user);
            var restaurant = await _context.Restaurants.Where(r => r.UserId == userId).FirstOrDefaultAsync();

            int restaurantId = restaurant.RestaurantId;
            string restaurantName = restaurant.RestaurantName;

            var loginResponse = new AdminLoginResponse
            {
                Token = token,
                RestaurantId = restaurantId,
                RestaurantName = restaurantName
            };

            return Ok(loginResponse);

        }

        private string GenerateJWTToken(User user)
        {

            return "bnsdjkbjs";
        }


    }
}
