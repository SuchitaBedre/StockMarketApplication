namespace StockMarketApplication.Controllers;
using StockMarketApplication.Service;
using StockMarketApplication.Models;
using Microsoft.AspNetCore.Mvc;

[Route("api/[controller]")]
[ApiController]
public class StockPriceController : ControllerBase
{
    private readonly StockPriceInterface _stockPriceRepository;
    public StockPriceController(StockPriceInterface stockPriceRepository)
    {
        _stockPriceRepository = stockPriceRepository;
    }
    [HttpGet]
    public IActionResult GetUsers()
    {
        var stockPrice = _stockPriceRepository.GetAllStockPrice();
        return Ok(stockPrice);
    }

    [HttpGet("{id}")]
    public IActionResult GetStockPriceById(int id)
    {
        var stock = _stockPriceRepository.GetStockPriceById(id);
        if (stock == null)
            return NotFound();

        return Ok(stock);
    }

    [HttpPost]
    public IActionResult CreateStockPrice([FromBody] StockPrice stockPrice)
    {
        if (stockPrice == null)
            return BadRequest();

        _stockPriceRepository.CreateStockPrice(stockPrice);
        return CreatedAtAction(nameof(GetStockPriceById), new { id = stockPrice.PriceId }, stockPrice);
    }

    [HttpPut("{id}")]
    public IActionResult UpdateStockPrice(int id, [FromBody] StockPrice stockPrice)
    {
        if (id != stockPrice.PriceId)
            return BadRequest("Student ID mismatch");

        var existingStockPrice = _stockPriceRepository.GetStockPriceById(id);

        if (existingStockPrice == null)
            return NotFound("Student not found");


        existingStockPrice.Price = stockPrice.Price;




        _stockPriceRepository.UpdateStockPrice(existingStockPrice);

        return NoContent();
    }

} 

