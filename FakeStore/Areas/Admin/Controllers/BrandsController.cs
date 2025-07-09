using FakeStore.Data;
using FakeStore.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace FakeStore.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class BrandsController : Controller
    {
        ApplicationDbContext context = new ApplicationDbContext();
        public IActionResult Index()
        {
            var brands = context.Brands.ToList();
            return View(brands);
        }

        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Create(Brand request)
        {
            if (ModelState.IsValid)
            {
                context.Brands.Add(request);
                context.SaveChanges();
                return RedirectToAction("Index");
            }
            return View();
        }
        public IActionResult Delete(int Id)
        {
            var brand = context.Brands.FirstOrDefault(b => b.ID == Id);
            if (brand is not null)
            {
                context.Brands.Remove(brand);
                context.SaveChanges();
            }
            return RedirectToAction("Index");
        }
        [HttpGet]
        public IActionResult Update(int Id)
        {
            var brand = context.Brands.FirstOrDefault(b => b.ID == Id);
            return View(brand);
        }
        [HttpPost]
        public IActionResult Update(Brand request)
        {
            context.Brands.Update(request);
            context.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}
