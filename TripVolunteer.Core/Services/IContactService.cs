using TripVolunteer.Core.Data;

namespace TripVolunteer.Core.Services
{
    public interface IContactService
    {
        List<Contact> GetAllcontact();
        void makecontact(Contact contact);
        void deletecontact(int id);
        public void updatecontact(Contact contact);
        Contact getcontactbyid(int id);
    }
}
