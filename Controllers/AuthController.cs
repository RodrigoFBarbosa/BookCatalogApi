
using BookCatalogApi.Context;
using Microsoft.AspNetCore.Mvc;
using BookCatalogApi.Models;
using System.Linq;
using System.Threading.Tasks;
using BookCatalogApi.Dtos;
using Microsoft.EntityFrameworkCore;
using System.IdentityModel.Tokens.Jwt;
using System.Text;
using Microsoft.IdentityModel.Tokens;
using System.Security.Claims;

namespace BookCatalogApi.Controllers;

[Route("[controller]")]
[ApiController]
public class AuthController : ControllerBase 
{
    private readonly AppDbContext _context;
    private readonly IConfiguration _configuration;

    public AuthController(AppDbContext context, IConfiguration configuration)
    {
        _context = context;
        _configuration = configuration;
    }

    [HttpPost("login")]
    public async Task<IActionResult> Login(UserLoginDto loginDto)
    {
        var user = await _context.Users.SingleOrDefaultAsync(u => u.Email == loginDto.Email);

        if (user is null || user.Password != loginDto.Password)
            return Unauthorized();

        var tokenHandler = new JwtSecurityTokenHandler();
        var key = Encoding.ASCII.GetBytes(_configuration["Jwt:Key"]);
        var tokenDescriptor = new SecurityTokenDescriptor
        {
            Subject = new ClaimsIdentity(new Claim[]
                {
                    new Claim(ClaimTypes.NameIdentifier, user.Id.ToString()),
                    new Claim(ClaimTypes.Role, user.IsAdmin ? "Admin" : "User")
                }),
                Expires = DateTime.UtcNow.AddDays(7),
                SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha256Signature)
        };

        return Ok(new { UserId = user.Id, IsAdmin = user.IsAdmin});
    }


}