using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

[ApiController]
[Route("api/[controller]")]
public class TransactionController : ControllerBase
{
    private readonly ApplicationDbContext _context;

    public TransactionController(ApplicationDbContext context)
    {
        _context = context;
    }

    [HttpGet("symbol/{symbol}")]
    public async Task<IActionResult> GetBySymbol(string symbol)
    {
        var transactions = await _context.Transactions.Where(t => t.Symbol == symbol).ToListAsync();
        return Ok(transactions);
    }

    [HttpGet("date-range")]
    public async Task<IActionResult> GetByDateRange(DateTime startDate, DateTime endDate)
    {
        var transactions = await _context.Transactions.Where(t => t.TransactionDate >= startDate && t.TransactionDate <= endDate).ToListAsync();
        return Ok(transactions);
    }

    [HttpGet("order-side/{orderSide}")]
    public async Task<IActionResult> GetByOrderSide(string orderSide)
    {
        var transactions = await _context.Transactions.Where(t => t.OrderSide == orderSide).ToListAsync();
        return Ok(transactions);
    }

    [HttpGet("order-status/{orderStatus}")]
    public async Task<IActionResult> GetByOrderStatus(string orderStatus)
    {
        var transactions = await _context.Transactions.Where(t => t.OrderStatus == orderStatus).ToListAsync();
        return Ok(transactions);
    }
}
