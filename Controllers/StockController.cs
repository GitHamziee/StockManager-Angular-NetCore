using API.Data;
using API.Dtos.Stock;
using API.Mappers.StockMappers;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers
{
    [Route("api/stock")]
    [ApiController]
    public class StockController : ControllerBase
    {

        private readonly ApplicationDBContext _Context;
        public StockController(ApplicationDBContext context)
        {
            _Context = context;

        }

        [HttpGet]
        public IActionResult GetAll()
        {

            var stocks = _Context.stocks.ToList().Select(s => s.toStockDto());

            return Ok(stocks);
        }

        [HttpGet("{id}")]
        public IActionResult GetSingleStock([FromRoute] int id)
        {
            var stock = _Context.stocks.Find(id);

            if ( stock is null)
            {
                NotFound();
            }

            return Ok(stock?.toStockDto());
         
        }

        [HttpPost]
        public IActionResult Create([FromBody] CreateStockRequestDto createStockDto)
        {
           var stockModel = createStockDto.ToStockFromCreateDto();
            _Context.stocks.Add(stockModel);
            _Context.SaveChanges();
            return Ok(stockModel);
        }
    }

}
