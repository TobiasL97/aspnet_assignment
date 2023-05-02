using aspnet_assignment.Contexts;
using aspnet_assignment.Models.Entities;
using Microsoft.IdentityModel.Tokens;

namespace aspnet_assignment.Helpers.Services
{
    public class StockService
    {
        private readonly DataContext _context;

        public StockService(DataContext context)
        {
            _context = context;
        }

        public async Task PopulateStockAsync()
        {
            if(_context.Stocks.IsNullOrEmpty())
            {
                var stockList = new List<StockEntity>
                {
                    new StockEntity { Stock = "Incoming Delivery"},
                    new StockEntity { Stock = "In stock"},
                    new StockEntity { Stock = "Out of stock"}
                };

                await _context.Stocks.AddRangeAsync(stockList);
            }

            await _context.SaveChangesAsync();
        }
    }
}
