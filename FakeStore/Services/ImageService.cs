using System.Runtime.CompilerServices;

namespace FakeStore.Services
{
    public class ImageService
    {
        private string _ImageFolderPath;
        public ImageService()
        {
            _ImageFolderPath = Path.Combine(Directory.GetCurrentDirectory(), @"wwwroot\img\Products");
        }
        public string UploadImage(IFormFile image)
        {
            var fileName = Guid.NewGuid().ToString() + Path.GetExtension(image.FileName);
            var filePath = Path.Combine(_ImageFolderPath, fileName);
            using (var stream = System.IO.File.Create(filePath))
            {
                image.CopyTo(stream);
            }
            return fileName;
        }
        public Boolean DeleteImage(string fileName)
        {
            var filePath = Path.Combine(_ImageFolderPath, fileName);
            if (File.Exists(filePath)) {
                File.Delete(filePath);
                return true;
            }
            return false;
        }
    }
}
