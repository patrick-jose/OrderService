using System.Text.Json;
using System.Text.Json.Serialization;

namespace OrderService.Data.Models
{
    public class OrderDTO
    {
        [JsonPropertyName("codigoPedido")]
        public long Id { get; set; }
        [JsonPropertyName("codigoCliente")]
        public long customerID { get; set; }
        public CustomerDTO customer { get; set; }
        [JsonPropertyName("itens")]
        public List<ProductDTO> Items { get; set; }

        public List<CustomerOrderModel> ToModel()
        {
            var model = new List<CustomerOrderModel>();

            foreach (var item in Items)
                model.Add(new CustomerOrderModel { 
                    CustomerId = this.customerID, 
                    OrderId = this.Id, 
                    Quantity = item.Quantity, 
                    UnitaryPrice = item.Price,
                    ProductId = item.id
                });               

            return model;
        }
    }
}
