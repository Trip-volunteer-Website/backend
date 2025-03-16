using TripVolunteer.Core.Data;
using TripVolunteer.Core.Repository;
using TripVolunteer.Core.Services;

namespace TripVolunteer.Infra.Services
{
    public class ContactService : IContactService
    {
        private readonly IContactRepository _contactRepository;
        public ContactService(IContactRepository
        contactRepository)
        {
            _contactRepository = contactRepository;
        }

        public void deletecontact(int id)
        {
            _contactRepository.deletecontact(id);
        }

        public List<Contact> GetAllcontact()
        {
            return _contactRepository.GetAllcontact();
        }

        public Contact getcontactbyid(int id)
        {
            return _contactRepository.getcontactbyid(id);
        }

        public void makecontact(Contact contact)
        {
            _contactRepository.makecontact(contact);
        }

        public void updatecontact(Contact contact)
        {
            _contactRepository.updatecontact(contact);
        }
    }
}
