using Microsoft.EntityFrameworkCore.Query.Internal;

namespace FakeStore.Models
{
    public class Product
    {
        public int ID { get; set; }
        public string Name { get; set; }
        public decimal Price { get; set; }
        public double Rate { get; set; }
        public int Quantity { get; set; }
        public int Discount { get; set; }
        public string Image { get; set; }
        public int CategoryID { get; set; }
        public Category Category { get; set; }
    }
}
