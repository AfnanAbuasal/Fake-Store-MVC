using FakeStore.Data;
using Microsoft.AspNetCore.Mvc;

namespace FakeStore.Areas.Customer.Controllers
{
    [Area("Customer")]
    public class HomeController : Controller
    {
        ApplicationDbContext context = new ApplicationDbContext();
        public IActionResult Index()
        {
            var categories = context.Categories.ToList();
            ViewBag.products = context.Products.ToList();
            return View(categories);
        }
    }
}
