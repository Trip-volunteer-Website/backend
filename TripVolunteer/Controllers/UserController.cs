using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using TripVolunteer.Core.Data;
using TripVolunteer.Core.Services;
using TripVolunteer.Infra.Services;

namespace TripVolunteer.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly IUserService userService;

        public UserController(IUserService  userService)
        {
            this.userService = userService;
        }
        [HttpGet]
        public List<Userr> GetAllUser()
        {
            return userService.GetAllUser();
        }
        [HttpGet]
        [Route("getbyId/{id}")]
        public Userr GetUserById(int id)
        {

            return userService.GetUserById(id);
        }
        [HttpPost]
        public void CreateUser(Userr userr)
        {
            userService.CreateUser(userr);
        }
        [HttpPut]
        public void UpdateUser(Userr userr)
        {
            userService.UpdateUser(userr);
        }
        [HttpDelete]
        [Route("Deleteuser/{id}")]
        public void Deleteuser(int id)
        {
            userService.DeleteUser(id);
        }
    
        [HttpGet]
        [Route("getEmail/{id}")]
        public IActionResult GetEmailUsingCursor(int id)  // Ensure parameter name matches the route
        {
            var email = userService.GetEmailUsingCursor(id);
            if (email == null)
                return NotFound("Email not found for the given user ID.");

            return Ok(email);
        }
        [HttpGet("names")]
        public IActionResult GetFirstAndLastNames()
        {
            var users = userService.GetFirstAndLastName();

            if (users == null || users.Count == 0)
                return NotFound("No users found.");

            return Ok(users);
        }
        [HttpGet("age/{id}")]
        public IActionResult GetAge(int id)
        {
            var age = userService.GetAge(id);

            if (age == 0)  // Assuming 0 means no user found
                return NotFound($"No age found for user ID: {id}");

            return Ok(new { UserId = id, Age = age });
        }

        [HttpPost("send-email-file")]
        public IActionResult SendEmailWithUploadedPdf([FromForm] int userId, [FromForm] IFormFile file)
        {
            if (file == null || file.Length == 0)
                return BadRequest("No file uploaded.");

            using var memoryStream = new MemoryStream();
            file.CopyTo(memoryStream);
            var pdfBytes = memoryStream.ToArray();
            var fileName = file.FileName;

            userService.SendEmailWithPdfAttachment(userId, pdfBytes, fileName);

            return Ok("Email with uploaded PDF sent.");
        }

    }
}
