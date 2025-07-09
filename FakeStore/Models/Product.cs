using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;
using System.ComponentModel.DataAnnotations;

namespace FakeStore.Models
{
    public class Product
    {
        public int ID { get; set; }
        [Required]
        [MinLength(3)]
        [MaxLength(100)]
        public string Name { get; set; }
        [Range(1,10000)]
        public decimal Price { get; set; }
        [Range(0,5)]
        public double Rate { get; set; }
        public int Quantity { get; set; }
        [Range(0,100)]
        public int Discount { get; set; }
        //[RegularExpression("^.*\\.(png|jpe?g|webp)$\r\n")]
        public string? Image { get; set; }
        public int CategoryID { get; set; }
        [ValidateNever]
        public Category Category { get; set; }
        public int BrandID { get; set; }
        [ValidateNever]
        public Brand Brand { get; set; }
    }
}
