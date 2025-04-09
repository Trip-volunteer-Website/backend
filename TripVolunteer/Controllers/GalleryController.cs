using Microsoft.AspNetCore.Mvc;
using TripVolunteer.Core.Data;
using TripVolunteer.Core.Services;

namespace TripVolunteer.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class GalleryController : ControllerBase
    {
        private readonly IGalleryService _galleryService;

        public GalleryController(IGalleryService galleryService)
        {
            _galleryService = galleryService;
        }

        [HttpGet]
        public List<Gallery> GetAllImages()
        {
            return _galleryService.GetAllImages();
        }

        [HttpPost]
        [Route("uploadImage")]
        public Gallery UploadImage()
        {
            var file = Request.Form.Files.FirstOrDefault();

            if (file == null || file.Length == 0)

                return null;

            // Generate unique file name

            var fileName = Guid.NewGuid().ToString() + "_" + file.FileName;

            // Define the folder path to store images


            var folderPath = Path.Combine( "C:\\Users\\Digi\\Desktop\\edit front\\frontend\\src\\assets\\images");

         

            // Ensure the folder exists

            if (!Directory.Exists(folderPath))

                Directory.CreateDirectory(folderPath);

            var fullPath = Path.Combine(folderPath, fileName);

            // Save the file

            using (var stream = new FileStream(fullPath, FileMode.Create))

            {

                file.CopyTo(stream);

            }

            // Save image path to database

            Gallery galleryItem = new Gallery { Imagepath = fileName };

            _galleryService.addImage(galleryItem);


            return galleryItem;
        }


        [HttpPut]
        [Route("UpdateImage/{id}")]
        public Gallery UpdateImage(int id)
        {
            var file = Request.Form.Files.FirstOrDefault();

            if (file == null || file.Length == 0)
                throw new Exception("No file provided.");

            var fileName = Guid.NewGuid().ToString() + "_" + file.FileName;
            var fullPath = Path.Combine("C:\\Users\\Digi\\Desktop\\edit front\\frontend\\src\\assets\\images", fileName);

            using (var stream = new FileStream(fullPath, FileMode.Create))
            {
                file.CopyTo(stream);
            }

            var updatedGallery = new Gallery
            {
                Imageid = id,
                Imagepath = fileName
            };

            _galleryService.updateImage(updatedGallery);

            return updatedGallery;
        }

        [HttpDelete]
        [Route("DeleteImage/{id}")]
        public void DeleteImage(int id)
        {
            _galleryService.deleteImage(id);
        }

        [HttpGet]
        [Route("GetImageById/{id}")]
        public Gallery GetImageById(int id)
        {
            return _galleryService.getImageById(id);
        }
    }
}
