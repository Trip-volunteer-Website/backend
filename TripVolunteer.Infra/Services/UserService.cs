using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TripVolunteer.Core.Data;
using TripVolunteer.Core.Repository;
using TripVolunteer.Core.Services;

namespace TripVolunteer.Infra.Services
{
    public class UserService : IUserService
    {
        private readonly IUserRepository _userRepository;
        private readonly EmailService _emailService;

        public UserService(IUserRepository userRepository, EmailService emailService)
        {
            _userRepository = userRepository;
            _emailService = emailService;
        }

        public int CreateUser(Userr userr)
        {
            return _userRepository.CreateUser(userr);
        }
        public void DeleteUser(int id)
        {
          _userRepository.DeleteUser(id);
        }

        public int GetAge(int id)
        {
           return _userRepository.GetAge(id);
        }

        public List<Userr> GetAllUser()
        {
          return  _userRepository.GetAllUser();
        }

        public string GetEmailUsingCursor(int userId)
        {
            return _userRepository.GetEmailUsingCursor(userId);
        }

        public List<Userr> GetFirstAndLastName()
        {
           return _userRepository.GetFirstAndLastName();
        }

        public Userr GetUserById(int id)
        {
          return _userRepository.GetUserById(id);
        }

        public void UpdateUser(Userr userr)
        {
            _userRepository.UpdateUser(userr);
        }

        public async Task SendEmailWithPdfAttachment(int userId, byte[] pdfBytes, string pdfFileName)
        {
            var email = _userRepository.GetEmailUsingCursor(userId);

            if (string.IsNullOrEmpty(email))
                throw new Exception("User email not found.");

            string subject = "Welcome with PDF";
            string body = "<p>Dear user,</p><p>Please find the attached PDF.</p>";

             await _emailService.SendEmailWithPDFAsync(email, subject, body, pdfBytes);
        }

    }
}
