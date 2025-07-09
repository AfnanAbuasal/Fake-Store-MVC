using FakeStore.Data;
using FakeStore.Models;
using FakeStore.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Threading.Tasks;

namespace FakeStore.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class ProductsController : Controller
    {
        ApplicationDbContext context = new ApplicationDbContext();
        public IActionResult Index()
        {
            var products = context.Products.ToList();
            return View(products);
        }

        [HttpGet]
        public IActionResult Create()
        {
            ViewBag.Categories = context.Categories.ToList();
            ViewBag.Brands = context.Brands.ToList();
            return View();
        }
        [HttpPost]
        public IActionResult Create(Product request, IFormFile image)
        {
            // Validate image manually - since it's nullable in the database
            if (image != null)
            {
                var allowedExtensions = new[] { ".png", ".jpg", ".jpeg", ".webp" };
                var extension = Path.GetExtension(image.FileName).ToLower();
                if (!allowedExtensions.Contains(extension))
                {
                    ModelState.AddModelError("Image", "Only PNG, JPG, JPEG, and WEBP files are allowed.");
                }
            }
            else
            {
                ModelState.AddModelError("Image", "Image is required.");
            }
            if (!ModelState.IsValid)
            {
                ViewBag.Categories = context.Categories.ToList();
                ViewBag.Brands = context.Brands.ToList();
                return View(request);
            }
            var imageService = new ImageService();
            string fileName = imageService.UploadImage(image);
            request.Image = fileName;
            context.Products.Add(request);
            context.SaveChanges();
            return RedirectToAction("Index");
        }
        public IActionResult Delete(int Id)
        {
            var product = context.Products.Find(Id);
            if (product is not null)
            {
                var imageService = new ImageService();
                imageService.DeleteImage(product.Image);
                context.Products.Remove(product);
                context.SaveChanges();
            }
            return RedirectToAction("Index");
        }

        [HttpGet]
        public IActionResult Update(int Id)
        {
            ViewBag.Categories = context.Categories.ToList();
            ViewBag.Brands = context.Brands.ToList();
            var product = context.Products.FirstOrDefault(c => c.ID == Id);
            return View(product);
        }
        [HttpPost]
        public IActionResult Update(Product request, IFormFile? image)
        {
            var product = context.Products.AsNoTracking().FirstOrDefault(p => p.ID == request.ID);
            if (image is not null)
            {
                var imageService = new ImageService();
                string fileName = imageService.UploadImage(image);
                request.Image = fileName;
                imageService.DeleteImage(product.Image);
            } else
            {
                request.Image = product.Image;
            }
            context.Products.Update(request);
            context.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}
