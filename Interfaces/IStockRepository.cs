using API.Dtos.Stock;
using API.Models;

namespace API.Interfaces
{
    public interface IstockRepository
    {
        Task<List<Stock>> GetAllASync();
        Task<Stock?> GetSingleStockAsync(int id);
        Task<Stock> CreateStockAsync(Stock stockModel);

        Task<Stock> UpdateStockAsync(int id, UpdateStockDto stockRequestDto);
        Task<int> DeleteStockAsync(int id);

    }
}
