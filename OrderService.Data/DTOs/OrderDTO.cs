namespace OrderService.Data.Models
{
    public class OrderDTO
    {
        public long Id { get; set; }
        public CustomerDTO customer { get; set; }
        public List<ProductDTO> Items { get; set; }

        public List<CustomerOrderModel> ToModel()
        {
            var model = new List<CustomerOrderModel>();

            foreach (var item in Items)
                model.Add(new CustomerOrderModel { 
                    CustomerId = this.customer.Id, 
                    OrderId = this.Id, 
                    Quantity = item.Quantity, 
                    UnitaryPrice = item.Price,
                    ProductId = item.id,
                    CustomerName = this.customer.Name
                });               

            return model;
        }
    }
}
