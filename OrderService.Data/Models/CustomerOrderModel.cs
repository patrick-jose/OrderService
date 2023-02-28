using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OrderService.Data.Models
{
    public class CustomerOrderModel
    {
        public long OrderId { get; set; }
        public long CustomerId { get; set; }
        public long ProductId { get; set; }
        public long Quantity { get; set; }
        public decimal UnitaryPrice { get; set; }
        public string? CustomerName { get; set; }
    }
}
