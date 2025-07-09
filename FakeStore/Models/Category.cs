using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;

namespace FakeStore.Models
{
    public class Category
    {
        public int ID { get; set; }
        public string Name { get; set; }
        [ValidateNever]
        public List<Product> Products { get; set; }

    }
}
