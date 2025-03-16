using Microsoft.AspNetCore.Mvc;
using TripVolunteer.Core.Data;
using TripVolunteer.Core.Services;

namespace TripVolunteer.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ContactController : ControllerBase
    {
        private readonly IContactService _contactService;
        public ContactController(IContactService contactService)
        {
            _contactService = contactService;
        }
        [HttpGet]
        public List<Contact> GetAllContact()
        {
            return _contactService.GetAllcontact();
        }

        [HttpPost]
        public void makeContact(Contact contact)
        {
            _contactService.makecontact(contact);
        }

        [HttpPut]
        public void UpdateContact(Contact contact)
        {
            _contactService.updatecontact(contact);
        }

        [HttpDelete]
        [Route("DeleteContact/{id}")]
        public void DeleteContact(int id)
        {
            _contactService.deletecontact(id);
        }

        [HttpGet]
        [Route("GetContactById/{id}")]
        public Contact GetContactById(int id)
        {
            return _contactService.getcontactbyid(id);
        }
    }
}
