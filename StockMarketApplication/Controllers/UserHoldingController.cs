namespace StockMarketApplication.Controllers;
using StockMarketApplication.Service;
using StockMarketApplication.Models;
using Microsoft.AspNetCore.Mvc;

[Route("api/[controller]")]
[ApiController]
public class UserHoldingController : ControllerBase
{
    private readonly UserHoldingInterface _userHoldingRepository;
    public UserHoldingController(UserHoldingInterface userHoldingRepository)
    {
        _userHoldingRepository = userHoldingRepository;
    }
    [HttpGet]
    public IActionResult GetUserHolding()
    {
        var userHolding = _userHoldingRepository.GetAllUserHolding();
        return Ok(userHolding);
    }

    [HttpGet("{id}")]
    public IActionResult GetUserHoldingById(int id)
    {
        var userHolding = _userHoldingRepository.GetUserHoldingById(id);
        if (userHolding == null)
            return NotFound();

        return Ok(userHolding);
    }

    [HttpPost]
    public IActionResult CreateUserHolding([FromBody] UserHolding userHolding)
    {
        if (userHolding == null)
            return BadRequest();

        _userHoldingRepository.CreateUserHolding(userHolding);
        return CreatedAtAction(nameof(GetUserHoldingById), new { id = userHolding.HoldingId }, userHolding);
    }

    [HttpPut("{id}")]
    public IActionResult UpdateUserHoldingById(int id, [FromBody] UserHolding userHolding)
    {
        if (id != userHolding.HoldingId)
            return BadRequest("Student ID mismatch");

        var existingUserHolding = _userHoldingRepository.GetUserHoldingById(id);

        if (existingUserHolding == null)
            return NotFound("Student not found");


        existingUserHolding.PurchaseDate = userHolding.PurchaseDate;




        _userHoldingRepository.UpdateUserHolding(existingUserHolding);

        return NoContent();
    }

}


