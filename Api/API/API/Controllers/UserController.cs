using API.Data;
using API.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly AppDbContext context;
        // this is for JWT functioning
        public IConfiguration _configuration;

        public UserController(IConfiguration config, AppDbContext context)
        {
            this.context = context;
            _configuration = config;
        }

        [HttpPost("AddUser")]
        public async Task<ActionResult> AddUser(User user)
        {
            await context.Users!.AddAsync(user);
            await context.SaveChangesAsync();
            return Ok($"Added user {user.UserName}.");
        }

        [HttpPost("token")]
        public async Task<ActionResult> Post(User user)
        {
            if (user != null && user.UserName != null && user.Password != null)
            {
                var tempUser = await GetTempUser(user.UserName, user.Password);
                if (tempUser != null)
                {
                    //create claims details based on the user information
                    var claims = new[]
                    {
                        new Claim(JwtRegisteredClaimNames.Sub, _configuration["Jwt:Subject"]),
                        new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString()),
                        new Claim(JwtRegisteredClaimNames.Iat, DateTime.UtcNow.ToString()),
                        new Claim("UserId", tempUser.UserId.ToString()),
                        new Claim("UserName", tempUser.UserName)
                    };
                    var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_configuration["Jwt:Key"]));
                    var signIn = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);
                    var token = new JwtSecurityToken(_configuration["Jwt:Issuer"],
                                                    _configuration["Jwt:Audience"],
                                                    claims,
                                                    expires: DateTime.UtcNow.AddMinutes(10),
                                                    signingCredentials: signIn);
                    return Ok(new JwtSecurityTokenHandler().WriteToken(token));
                }
                else
                    return BadRequest("Invalid credentials");
            }
            else 
                return BadRequest("Missing User data");
        }

        private async Task<User> GetTempUser(string userName, string password)
        {
            return await context.Users!.FirstOrDefaultAsync(U => U.UserName == userName && U.Password == password);
        }

        [Authorize]
        [HttpGet("GetAllUsers")]
        public async Task<ActionResult<List<User>>> GetAllUsers()
        {
            List<User> list = await context.Users!.ToListAsync();
            if (list == null)
            {
                return NotFound();
            }
            return Ok(list);
        }
        [Authorize]
        [HttpGet("GetUser/{id}")]
        public async Task<ActionResult<Book>> GetUser(int id)
        {
            var user = await context.Users!.Where(U => U.UserId == id).SingleOrDefaultAsync();
            if (user != null)
            {
                return Ok(user);
            }
            return NotFound();
        }
    }
}
