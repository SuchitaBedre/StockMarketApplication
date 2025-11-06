namespace StockMarketApplication.Controllers;
using Microsoft.AspNetCore.Mvc;
using StockMarketApplication.Service;
using StockMarketApplication.Models;
using Microsoft.EntityFrameworkCore;

[Route("api/[controller]")]
[ApiController]
public class AuthController : ControllerBase
{
    private readonly JwtTokenService _jwtTokenService;

    private readonly StockmarketContext _context;

    public AuthController(JwtTokenService jwtTokenService, StockmarketContext context)
    {
        _jwtTokenService = jwtTokenService;
        _context = context;
    }

    [HttpPost("login")]
    public async Task<IActionResult> Login([FromBody] LoginRequest request)
    {

        // This is where you validate the user credentials from your DB.
        // For demonstration, let's assume any user with a non-empty username is valid.
        if (string.IsNullOrEmpty(request.Username) || string.IsNullOrEmpty(request.Password))
        {
            return Unauthorized(new { message = "Invalid credentials" });
        }
        var user = await _context.Users.FirstOrDefaultAsync(u => u.Username == request.Username && u.PasswordHash == request.Password);

        if (user == null)
        {
            return Unauthorized(new { message = "User Not Found" });  // User not found
        }

        // Generate JWT token
        var token = _jwtTokenService.GenerateToken(request.Username);

        // save user token in database
        var result = await _context.UserTokens.AddAsync(new UserToken
        {
            UserId = user.UserId,
            Token = token,
            Expiry = DateTime.UtcNow.AddHours(1), // assuming 1 hour expiry
            IsRevoked = false
        });

        await _context.SaveChangesAsync();
        return Ok(new { Token = token });
    }
}

public class LoginRequest
{
    public string Username { get; set; }
    public string Password { get; set; }
}

