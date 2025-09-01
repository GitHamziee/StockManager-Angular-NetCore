using API.Data;
using API.Dtos.Stock;
using API.Interfaces;
using API.Mappers.StockMappers;
using API.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace API.Controllers
{
    [Route("api/stock")]
    [ApiController]
    public class StockController : ControllerBase
    {
        private readonly IstockRepository _stockRepo;
        private readonly ApplicationDBContext _Context;
        public StockController(ApplicationDBContext context , IstockRepository stockRepo)
        {
            _stockRepo = stockRepo;
            _Context = context;

        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var stocks = (await _stockRepo.GetAllASync()).Select(s => s.toStockDto());

            return Ok(stocks);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetSingleStock([FromRoute] int id)
        {
            var stock = await _stockRepo.GetSingleStockAsync(id);

            if (stock is null)
            {
                throw new KeyNotFoundException($"Stock with ID {id} not found.");
            }
            return Ok(stock?.toStockDto());

        }

        [HttpPost]
        public async Task<IActionResult> Create([FromBody] CreateStockRequestDto createStockDto)
        {
            var stockModel = createStockDto.MapToStock();
            stockModel =  await _stockRepo.CreateStockAsync(stockModel);
          
            return Ok(stockModel.toStockDto());
        }

        [HttpPut("{id}")] 
        public async Task<IActionResult> Update([FromRoute] int id, [FromBody] UpdateStockDto updateDto)
        {
            var stockUpdate = await _stockRepo.UpdateStockAsync( id , updateDto);

            return Ok(stockUpdate.toStockDto());
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete([FromRoute] int id)
        {

           var result = await _stockRepo.DeleteStockAsync(id);

            return Ok(result);
        }

    }

}