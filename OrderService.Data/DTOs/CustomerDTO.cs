using System.Text.Json.Serialization;

namespace OrderService.Data.Models
{
    public class CustomerDTO
    {
        [JsonPropertyName("codigoCliente")]
        public int Id { get; set; }
        public string? Name { get; set; }
    }
}
