using TripVolunteer.Core.Data;

namespace TripVolunteer.Core.Services
{
    public interface ITestimonialService
    {
        List<Testimonial> GetAllTestimonials();
        public List<Testimonial> GetAllActiveTestimonials();
        void makeTestimonial(Testimonial testimonial);
        void DeleteTestimonial(int id);
        public void UpdateTestimonial(Testimonial testimonial);
        Testimonial GetTestimonialById(int id);
        public List<Testimonial> GetTestimonialCountByStatus();
        public void ApprovOrRejectTestimonial(int testimonialId, string newStatus);
    }
}
