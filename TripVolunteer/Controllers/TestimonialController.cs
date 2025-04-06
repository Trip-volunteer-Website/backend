using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using TripVolunteer.Core.Data;
using TripVolunteer.Core.Services;
using TripVolunteer.Infra.Services;

namespace TripVolunteer.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TestimonialController : ControllerBase
    {
        private readonly ITestimonialService testimonialService;
        public TestimonialController(ITestimonialService testimonialService)
        {
            this.testimonialService = testimonialService;
        }


        [HttpGet]
        public List<Testimonial> GetAllTestimonials()
        {
            return testimonialService.GetAllTestimonials();
        }

        [HttpGet]
        [Route("active")]
        public List<Testimonial> GetAllActiveTestimonials()
        {
            return testimonialService.GetAllActiveTestimonials();
        }
        [HttpPost]
        public void makeTestimonial(Testimonial testimonial)
            
        {
            testimonialService.makeTestimonial(testimonial);
        }


        [HttpPut]
        public void UpdateTestimonial(Testimonial testimonial)
        {
           testimonialService.UpdateTestimonial(testimonial);
        }

        [HttpDelete]
        [Route("Deletetestimonial/{id}")]
        public void DeleteTestimonial(int id)
        {
            testimonialService.DeleteTestimonial(id);
        }

        [HttpGet]
        [Route("TestimonialById/{id}")]
        public Testimonial GetTestimonialById(int id)
        {
            return testimonialService.GetTestimonialById(id);
        }




        [HttpGet]
        [Route("TestimonialCountByStatus")]
        public List<Testimonial> GetTestimonialCountByStatus()
        {
            return testimonialService.GetTestimonialCountByStatus();
        }




        [HttpPut]
        [Route("ApprovOrRejectTestimonial/{testimonialId}/{newStatus}")]
        public void ApprovOrRejectTestimonial(int testimonialId, string newStatus)
        {
                   testimonialService.ApprovOrRejectTestimonial(testimonialId , newStatus);
        }











    }
}
