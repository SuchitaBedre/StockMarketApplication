namespace StockMarketApplication.Controllers;
using Microsoft.AspNetCore.Mvc;
using StockMarketApplication.Service;
using StockMarketApplication.Models;

[Route("api/[controller]")]
[ApiController]
public class WatchListController : ControllerBase
{
    private readonly WatchListInterface _watchlistRepository;
    public WatchListController(WatchListInterface watchlistRepository)
    {
        _watchlistRepository = watchlistRepository;
    }
    [HttpGet]
    public IActionResult GetUsers()
    {
        var students = _watchlistRepository.GetAllWatchlist();
        return Ok(students);
    }

    [HttpGet("{id}")]
    public IActionResult GetUserById(int id)
    {
        var student = _watchlistRepository.GetWatchlistById(id);
        if (student == null)
            return NotFound();

        return Ok(student);
    }

    [HttpPost]
    public IActionResult CreateUser([FromBody] Watchlist watchlist)
    {
        if (watchlist == null)
            return BadRequest();

        _watchlistRepository.CreateWatchlist(watchlist);
        return CreatedAtAction(nameof(GetUserById), new { id = watchlist.UserId }, watchlist);
    }

    [HttpPut("{id}")]
    public IActionResult UpdateWatchList(int id, [FromBody] Watchlist watchlist)
    {
        if (id != watchlist.WatchlistId)
            return BadRequest("Student ID mismatch");

        var existingWatchlist = _watchlistRepository.GetWatchlistById(id);

        if (existingWatchlist == null)
            return NotFound("Student not found");


        existingWatchlist.WatchlistId = watchlist.WatchlistId;
     


        _watchlistRepository.UpdateWatchlist(existingWatchlist);

        return NoContent();
    }

}

