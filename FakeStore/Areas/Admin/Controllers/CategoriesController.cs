using FakeStore.Data;
using FakeStore.Models;
using Microsoft.AspNetCore.Mvc;

namespace FakeStore.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class CategoriesController : Controller
    {
        ApplicationDbContext context = new ApplicationDbContext();
        public IActionResult Index()
        {
            var categories = context.Categories.ToList();
            return View(categories);
        }

        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Create(Category request)
        {
            if (ModelState.IsValid)
            {
                context.Categories.Add(request);
                context.SaveChanges();
                return RedirectToAction("Index");
            }
            return View();
        }
        public IActionResult Delete(int Id)
        {
            var category = context.Categories.FirstOrDefault(c => c.ID == Id);
            if (category is not null)
            {
                context.Categories.Remove(category);
                context.SaveChanges();
            }
            return RedirectToAction("Index");
        }
        [HttpGet]
        public IActionResult Update(int Id)
        {
            var category = context.Categories.FirstOrDefault(c => c.ID == Id);
            return View(category);
        }
        [HttpPost]
        public IActionResult Update(Category request)
        {
            context.Categories.Update(request);
            context.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}
