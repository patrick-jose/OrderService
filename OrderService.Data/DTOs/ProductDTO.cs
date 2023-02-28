using System.Text.Json.Serialization;

namespace OrderService.Data.Models
{
    public class ProductDTO
    {
        public long id { get; set; }
        [JsonPropertyName("produto")]
        public string Name { get; set; }
        [JsonPropertyName("preco")]
        public decimal Price { get; set; }
        [JsonPropertyName("quantidade")]
        public long Quantity { get; set; }       
    }
}
