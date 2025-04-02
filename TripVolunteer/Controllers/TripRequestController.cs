
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using TripVolunteer.Core.Data;
using TripVolunteer.Core.Repository;
using TripVolunteer.Core.Services;
using TripVolunteer.Infra.Repository;

namespace TripVolunteer.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TripRequestController : ControllerBase
    {
        private readonly ITripRequestService _tripRequestService;
        private readonly IEmailService _emailService;
        private readonly IUserRepository _userRepo;
        public TripRequestController(ITripRequestService tripRequestService, IEmailService emailService, IUserRepository userRepository)
        {
            _tripRequestService = tripRequestService;
            _emailService = emailService;
            _userRepo = userRepository;
        }

        [HttpGet("all")]
        public List<Triprequest> GetAllTripRequests()
        {
            return _tripRequestService.GetAllTripRequests();
        }

        [HttpGet]
        [Route("getbyid/{id}")]
        public Triprequest GetTriprequestByID(int id)
        {
            return _tripRequestService.GetTriprequestById(id);
        }


        [HttpDelete]
        [Route("deleteTripReq/{id}")]
        public void DeleteTripRequest(int id)
        {
            _tripRequestService.deleteTripRequest(id);
        }

        [HttpPost]
        public void CreateTripRequest(Triprequest triprequest)
        {
            _tripRequestService.CreateTripRequest(triprequest);
        }

       

        [HttpGet]
        [Route("getReq_status&Type/{id}")]
        public Triprequest GetRequestStatusAndType(int id)
        {
            return _tripRequestService.GetRequestStatusAndType(id);
        }

        [HttpPost]
        [Route("setCV/{id}/{cv_file_path}")]
        public void SetCV(int Id, string cv_file_path)
        {
            _tripRequestService.SetCV(Id, cv_file_path);
        }

        [HttpGet]
        [Route("getCv/{id}")]
        public Triprequest GetCV(int id)
        {
            return _tripRequestService.GetCV(id);
        }
        [HttpPost]
        [Route("uploadAttachment")]
        public Triprequest UploadAttachment()
        {
            var file = Request.Form.Files[0];
            var filename = Guid.NewGuid().ToString() + "_" + file.FileName;
            var fullpath = Path.Combine("C:\\Users\\Digi\\Desktop\\edit front\\frontend\\src\\assets\\CVs", filename);

            using (var stream = new FileStream(fullpath, FileMode.Create))
            {
                file.CopyTo(stream);
            }
            Triprequest tripReq = new Triprequest();
            tripReq.Cvfilepath = filename;

            return tripReq;
        }

        [HttpPut]
        public async Task<IActionResult> UpdateTripRequest(Triprequest triprequest)
        {
            _tripRequestService.UpdateTripRequest(triprequest);
            var user = _userRepo.GetUserById((int)triprequest.Userid);
            if (user == null)
                return NotFound("User not found.");

            string fullName = $"{user.Fname} {user.Lname}";
            string subject = "";
            string message = "";

            // 4. Determine email based on status + request type
            if (triprequest.Status == "rejected")
            {
                subject = "Trip Request Update";
                message = $"Dear {fullName},\n\n" +
                          "Unfortunately, your request to join the trip has not been approved.\n\n" +
                          "We appreciate your interest and encourage you to apply for upcoming trips.\n\n" +
                          "Best regards,\nThe Trip Volunteer Team";
            }
            else if (triprequest.Status == "approved")
            {
                if (triprequest.Requesttype == "User")
                {
                    subject = "You're Approved! Complete Your Payment";
                    message = $"Dear {fullName},\n\n" +
                              "Great news! Your trip request has been approved.\n\n" +
                              "Please log into your profile and complete the payment process to secure your spot on the trip.\n\n" +
                              "We're excited to have you with us!\n\n" +
                              "Warm regards,\nThe Trip Volunteer Team";
                }
                else if (triprequest.Requesttype == "Volunteer")
                {
                    subject = "Welcome to the Trip!";
                    message = $"Dear {fullName},\n\n" +
                              "Your volunteer request has been approved — welcome to the team!\n\n" +
                              "We're thrilled to have you on this meaningful journey. Stay tuned for trip preparation tips and details.\n\n" +
                              "With gratitude,\nThe Trip Volunteer Team";
                }
            }

            // 5. Send the email
            await _emailService.SendEmailAsync(user.Email, subject, message);

            return Ok("Trip request updated and email sent.");
        }



    }
}
