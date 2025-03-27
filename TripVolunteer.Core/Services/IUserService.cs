using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TripVolunteer.Core.Data;

namespace TripVolunteer.Core.Services
{
    public interface IUserService
    {
        List<Userr> GetAllUser();
        int CreateUser(Userr userr);
        void UpdateUser(Userr userr);
        void DeleteUser(int id);
        Userr GetUserById(int id);
        public string GetEmailUsingCursor(int userId);
        List<Userr> GetFirstAndLastName();
        int GetAge(int id);
        Task SendEmailWithPdfAttachment(int userId, byte[] pdfBytes, string pdfFileName);

    }
}
