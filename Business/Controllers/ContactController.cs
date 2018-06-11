using BusinessEntities.Services;
using BusinessEntities.ViewModel;
using System.Collections.Generic;
using System.Web.Http;

namespace Business.Controllers
{
    [RoutePrefix("api/contact")]
    public class ContactController : ApiController
    {
        private IContactService _contactService;

        public IContactService ContactService
        {
            get { return _contactService ?? (_contactService = new ContactService(new DataModel.UnitOfWork())); }
        }

        [HttpGet]
        [Route("GetAllContacts")]
        public List<ContactViewModel> GetAllContacts()
        {
            var listContact = ContactService.GetAllContacts();
            return (listContact);
        }

        [HttpPost]
        [Route("AddNewContact")]
        public void AddNewContact(ContactViewModel contact)
        {
            ContactService.AddContact(contact);
            Ok("Success");
        }

        [Route("UpdateContact")]
        [HttpPut]
        public void UpdateContact(ContactViewModel contactToUpdate)
        {
            ContactService.UpdateContact(contactToUpdate);
            Ok("Success");
        }

        [HttpDelete]
        [Route("DeleteContact/{contactId:int}")]
        public void DeleteContact(int contactId)
        {
            ContactService.DeleteContact(contactId);
            Ok("Success");
        }

    }
}
