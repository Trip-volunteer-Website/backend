using TripVolunteer.Core.Data;
using TripVolunteer.Core.Repository;
using TripVolunteer.Core.Services;

namespace TripVolunteer.Infra.Services
{
    public class GalleryService : IGalleryService
    {
        private readonly IGalleryRepository _galleryRepository;
        public GalleryService(IGalleryRepository
        galleryRepository)
        {
            _galleryRepository = galleryRepository;
        }

        public void addImage(Gallery gallery)
        {
            _galleryRepository.addImage(gallery);
        }

        public void deleteImage(int id)
        {
            _galleryRepository.deleteImage(id);
        }

        public List<Gallery> GetAllImages()
        {
            return _galleryRepository.GetAllImages();
        }

        public Gallery getImageById(int id)
        {
            return _galleryRepository.getImageById(id);
        }

        public void updateImage(Gallery gallery)
        {
            _galleryRepository.updateImage(gallery);
        }
    }
}
