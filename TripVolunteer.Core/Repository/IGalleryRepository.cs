using TripVolunteer.Core.Data;

namespace TripVolunteer.Core.Repository
{
    public interface IGalleryRepository
    {
        List<Gallery> GetAllImages();
        void addImage(Gallery gallery);
        void deleteImage(int id);
        public void updateImage(Gallery gallery);
        Gallery getImageById(int id);
    }
}
