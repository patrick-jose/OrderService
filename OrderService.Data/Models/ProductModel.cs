using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OrderService.Data.Models
{
    public class ProductModel
    {
        public long Id { get; set; }
        public string Name { get; set; }
        public decimal Price { get; set; }
    }
}
