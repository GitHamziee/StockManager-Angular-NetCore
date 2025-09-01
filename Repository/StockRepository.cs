using API.Data;
using API.Dtos.Stock;
using API.Interfaces;
using API.Mappers.StockMappers;
using API.Models;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.EntityFrameworkCore;

namespace API.Repository
{
    public class StockRepository : IstockRepository
    {
        private ApplicationDBContext _context;

        public StockRepository(ApplicationDBContext context)
        {
            _context = context;
        }

        public async  Task<Stock> CreateStockAsync(Stock stockModel)
        {
           await _context.stocks.AddAsync(stockModel);
            _context.SaveChanges();

            return stockModel;
        }

        public async Task<int> DeleteStockAsync(int id)
        {
            var toDelete = new Stock { Id = id };
            _context.stocks.Remove(toDelete);

            var rows = await _context.SaveChangesAsync();

            if (rows == 0)
            
                throw new KeyNotFoundException("zero rows were effected");

            return rows;
        }

        public Task<List<Stock>> GetAllASync()
        {
            return _context.stocks.ToListAsync();
        }

        public async Task<Stock?> GetSingleStockAsync(int id)
        {
            var stock = await _context.stocks.FindAsync(id);

            return stock;
        }

       

      

        public async Task<Stock> UpdateStockAsync(int id, UpdateStockDto stockRequestDto)
        {

            var stock = await _context.stocks.FindAsync(id);


            if (stock == null)
                throw new KeyNotFoundException($"Stock with ID {id} not found.");

            stock.UpdateFromDto(stockRequestDto);
            await _context.SaveChangesAsync();
          
            return stock;

        }

        
    }
}
