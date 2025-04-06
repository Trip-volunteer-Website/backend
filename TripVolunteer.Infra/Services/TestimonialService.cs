using TripVolunteer.Core.Data;
using TripVolunteer.Core.Repository;
using TripVolunteer.Core.Services;

namespace TripVolunteer.Infra.Services
{
    public class TestimonialService : ITestimonialService
    {
        private readonly ITestimonialRepository _testimonialRepository;
        public TestimonialService(ITestimonialRepository
        invoiceRepository)
        {
            _testimonialRepository = invoiceRepository;
        }

        public void ApprovOrRejectTestimonial(int testimonialId, string newStatus)
        {
            _testimonialRepository.ApprovOrRejectTestimonial(testimonialId, newStatus);
        }
       public List<Testimonial> GetAllActiveTestimonials()
        {
            return _testimonialRepository.GetAllActiveTestimonials();
        }
        public void DeleteTestimonial(int id)
        {
            _testimonialRepository.DeleteTestimonial(id);
        }

        public List<Testimonial> GetAllTestimonials()
        {
            return _testimonialRepository.GetAllTestimonials();
        }

        public Testimonial GetTestimonialById(int id)
        {
            return _testimonialRepository.GetTestimonialById(id);
        }

        public List<Testimonial> GetTestimonialCountByStatus()
        {
            return _testimonialRepository.GetTestimonialCountByStatus();
        }

        public void makeTestimonial(Testimonial testimonial)
        {
            _testimonialRepository.makeTestimonial(testimonial);
        }

        public void UpdateTestimonial(Testimonial testimonial)
        {
            _testimonialRepository.UpdateTestimonial(testimonial);
        }
    }
}
