using TripVolunteer.Core.Data;

namespace TripVolunteer.Core.Services
{
    public interface IGalleryService
    {
        List<Gallery> GetAllImages();
        void addImage(Gallery gallery);
        void deleteImage(int id);
        public void updateImage(Gallery gallery);
        Gallery getImageById(int id);
    }
}
