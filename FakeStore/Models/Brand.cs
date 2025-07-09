using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;
using System.ComponentModel.DataAnnotations;

namespace FakeStore.Models
{
    public class Brand
    {
        public int ID { get; set; }
        [Required]
        [MinLength(2)]
        [MaxLength(20)]
        public string Name { get; set; }
        [ValidateNever]
        public List<Product> Products { get; set; }
    }
}
