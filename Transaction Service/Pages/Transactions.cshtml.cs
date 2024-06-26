using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using Transaction_Service.Models;
namespace Transaction_Service.Pages
{
    public class TransactionsModel : PageModel
    {
        private readonly ApplicationDbContext _context;

        public TransactionsModel(ApplicationDbContext context)
        {
            _context = context;
        }

        public List<Transactions> Transactions { get; set; }

        public async Task<IActionResult> OnGetAsync(string symbol, DateTime? startDate, DateTime? endDate, string orderSide, string orderStatus)
        {
            var query = _context.Transactions.AsQueryable();

            if (!string.IsNullOrEmpty(symbol))
            {
                query = query.Where(t => t.Symbol == symbol);
            }

            if (startDate.HasValue && endDate.HasValue)
            {
                query = query.Where(t => t.TransactionDate >= startDate.Value);
            }

            if (!string.IsNullOrEmpty(orderSide))
            {
                query = query.Where(t => t.OrderSide == orderSide);
            }

            if (!string.IsNullOrEmpty(orderStatus))
            {
                query = query.Where(t => t.OrderStatus == orderStatus);
            }

            Transactions = await query.ToListAsync();

            return Page();
        }
    }
}
