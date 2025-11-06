namespace StockMarketApplication.Controllers;
using Microsoft.AspNetCore.Mvc;
using StockMarketApplication.Service;
using StockMarketApplication.Models;
using System;

[Route("api/[controller]")]
[ApiController]
public class StockController : ControllerBase
{
    private readonly StockInterface _stockRepository;
    public StockController(StockInterface stockRepository)
    {
        _stockRepository = stockRepository;
    }
    [HttpGet]
    public IActionResult GetStocks()
    {
        var stocks = _stockRepository.GetAllStocks();
        return Ok(stocks);
    }

    [HttpGet("{id}")]
    public IActionResult GetStockById(int id)
    {
        var student = _stockRepository.GetStockById(id);
        if (student == null)
            return NotFound();

        return Ok(student);
    }

    [HttpPost]
    public IActionResult CreateStock([FromBody] Stock stock)
    {
        if (stock == null)
            return BadRequest();

        _stockRepository.CreateStock(stock);
        return CreatedAtAction(nameof(GetStockById), new { id = stock.StockId }, stock);
    }


    [HttpPut("{id}")]
    public IActionResult UpdateStock(int id, [FromBody] Stock stock)
    {
        if (id != stock.StockId)
            return BadRequest("Stock ID mismatch");

        var existingStock = _stockRepository.GetStockById(id);

        if (existingStock == null)
            return NotFound("Student not found");


        existingStock.Exchange = stock.Exchange;
        existingStock.Watchlists = stock.Watchlists;
        existingStock.StockPrices = stock.StockPrices;
        existingStock.CompanyName = stock.CompanyName;
        existingStock.TickerSymbol = stock.TickerSymbol;
        existingStock.UserHoldings=stock.UserHoldings;


        _stockRepository.UpdateStock(existingStock);

        return NoContent();
    }

}

