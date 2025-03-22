using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using REN.Models;
using RENAPI.APIContracts.Request;

namespace RENAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AdminRegisterController : ControllerBase
    {
        private UserManager<User> _userManager;
        private readonly SignInManager<User> _signinManager;
        private readonly string? _jwtKey;

        public AdminRegisterController(UserManager<User> userManager, SignInManager<User> signinManager, IConfiguration configuration)
        {
            _userManager = userManager;
            _signinManager = signinManager;
            _jwtKey = configuration["Jwt:Key"];
        }

        [HttpPost("Register")]

        public async Task<IActionResult> RegisterAdmin([FromBody] AdminRegisterRequest adminregistrationrequest)
        {
            if (adminregistrationrequest == null || string.IsNullOrEmpty(adminregistrationrequest.FirstName) || string.IsNullOrEmpty(adminregistrationrequest.Email))
                { 
                    return BadRequest("Invalid Registration Details"); 
            }

            var existingUser = await _userManager.FindByEmailAsync(adminregistrationrequest.Email);

            if (existingUser != null)
            {
                return Conflict("Email already exists");
            }

            var user = new User
            {
                FirstName = adminregistrationrequest.FirstName,
                LastName = adminregistrationrequest.LastName,
                Email = adminregistrationrequest.Email,
                UserName = adminregistrationrequest.Email,
                Restaurants = adminregistrationrequest.RestaurantDetails.Select(rd => new Restaurant
                {
                    RestaurantName = rd.restaurantName,
                    ContactNumber = rd.ContactNumber,
                    RestaurantAddresses = rd.RestaurantAddresses.Select(rar => new RestaurantAddress
                    {
                        Country = rar.Country,
                        City = rar.City,
                        StreetName = rar.StreetName,    
                        StreetAddress = rar.StreetAddress,
                        PinCode = rar.PinCode,
                        Province = rar.Province,
                    }).ToList()
                }).ToList()

            };

            var result = await _userManager.CreateAsync(user, adminregistrationrequest.Password);

            if (!result.Succeeded) {
                return BadRequest(result.Errors);
            }

            return Ok("User Registered Successfully");
        }
    }
}
