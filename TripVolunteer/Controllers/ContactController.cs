using Microsoft.AspNetCore.Mvc;
using TripVolunteer.Core.Data;
using TripVolunteer.Core.Services;

namespace TripVolunteer.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ContactController : ControllerBase
    {
        private readonly IContactService contactService;
        public ContactController(IContactService
        contactService)
        {
            this.contactService = contactService;
        }
        [HttpGet]
        public List<Contact> GetAllContact()
        {
            return contactService.GetAllcontact();
        }

        [HttpPost]
        public void makeContact(Contact contact)
        {
            contactService.makecontact(contact);
        }

        [HttpPut]
        public void UpdateContact(Contact contact)
        {
            contactService.updatecontact(contact);
        }

        [HttpDelete]
        [Route("DeleteInvoice/{id}")]
        public void DeleteContact(int id)
        {
            contactService.deletecontact(id);
        }

        [HttpGet]
        [Route("GetContactById/{id}")]
        public Contact GetContactById(int id)
        {
            return contactService.getcontactbyid(id);
        }
    }
}
