using System.ComponentModel.DataAnnotations.Schema;

namespace API.Dtos.Stock
{
    public class CreateStockRequestDto
    {

        public string Symbol { get; set; } = string.Empty;

        public string CompanyName { get; set; } = string.Empty;

        public string Industry { get; set; } = string.Empty;

       
        public decimal Purchase { get; set; }

     
        public int LastDiv { get; set; }

        public long MarketCap { get; set; }
    }
}
