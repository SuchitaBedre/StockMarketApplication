namespace StockMarketApplication.Controllers;
using Microsoft.AspNetCore.Mvc;
using StockMarketApplication.Service;
using StockMarketApplication.Models;

[ApiController]
[Route("api/[controller]")]
public class AuthController : ControllerBase
{
    private readonly StockmarketContext _context;
    private readonly JwtTokenService _jwtTokenService;

    public AuthController(StockmarketContext context, JwtTokenService jwtTokenService)
    {
        _context = context;
        _jwtTokenService = jwtTokenService;
    }

    [HttpPost("login")]
    public IActionResult Login([FromBody] LoginRequest request)
    {
        var user = _context.Users.FirstOrDefault(u => u.Username == request.Username && u.PasswordHash == request.Password);
        if (user == null)
        {
            return Unauthorized("Invalid credentials");
        }

        var token = _jwtTokenService.GenerateToken(user.Username, user.Role);
        return Ok(new { Token = token });
    }
}

public class LoginRequest
{
    public string Username { get; set; }
    public string Password { get; set; }
}

