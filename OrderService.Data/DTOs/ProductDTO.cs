namespace OrderService.Data.Models
{
    public class ProductDTO
    {
        public long id { get; set; }
        public string Name { get; set; }
        public decimal Price { get; set; }
        public long Quantity { get; set; }       
    }
}
