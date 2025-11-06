using Microsoft.AspNetCore.Mvc;
using StockMarketApplication.Service;
using StockMarketApplication.Models;

[Route("api/[controller]")]
[ApiController]
public class UserController : ControllerBase
{
    private readonly UserInterface _userRepository;
    public UserController(UserInterface userRepository)
    {
        _userRepository = userRepository;
    }
    [HttpGet]
    public IActionResult GetUsers()
    {
        var students = _userRepository.GetAllUsers();
        return Ok(students);
    }

    [HttpGet("{id}")]
    public IActionResult GetUserById(int id)
    {
        var student = _userRepository.GetUserById(id);
        if (student == null)
            return NotFound();

        return Ok(student);
    }

    [HttpPost]
    public IActionResult CreateUser([FromBody] User user)
    {
        if (user == null)
            return BadRequest();

        _userRepository.CreateUser(user);
        return CreatedAtAction(nameof(GetUserById), new { id = user.UserId }, user);
    }

    [HttpPut("{id}")]
    public IActionResult UpdateUser(int id, [FromBody] User user)
    {
        if (id != user.UserId)
            return BadRequest("Student ID mismatch");

        var existingStudent = _userRepository.GetUserById(id);

        if (existingStudent == null)
            return NotFound("Student not found");


        existingStudent.Username = user.Username;
        existingStudent.Watchlists = user.Watchlists;
        existingStudent.UserHoldings = user.UserHoldings;
        existingStudent.Role = user.Role;
        existingStudent.Email = user.Email;
        


        _userRepository.UpdateUser(existingStudent);

        return NoContent();
    }

}

