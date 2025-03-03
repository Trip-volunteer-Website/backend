using TripVolunteer.Core.Data;

namespace TripVolunteer.Core.Repository
{
    public interface IContactRepository
    {
        List<Contact> GetAllcontact();
        void makecontact(Contact contact);
        void deletecontact(int id);
        public void updatecontact(Contact contact);
        Contact getcontactbyid(int id);
    }
}
