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

        public UserService(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }
        public void CreateUser(Userr userr)
        {
          _userRepository.CreateUser(userr);
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
    }
}
