namespace OrderService.Data.Models
{
    public class OrderDTO
    {
        public long Id { get; set; }
        public CustomerDTO customer { get; set; }
        public List<ProductDTO> Items { get; set; }
    }
}
