using Business.DataModel;
using BusinessEntities.ViewModel;
using System.Collections.Generic;

namespace BusinessEntities.Services
{
    public interface IContactService
    {
        void AddContact(ContactViewModel contact);
        void UpdateContact(ContactViewModel contactToUpdate);
        void DeleteContact(int contactId);

        List<ContactViewModel> GetAllContacts();
    }

    public class ContactService : IContactService
    {
        private IUnitOfWork _unitOfWork;

        public ContactService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public void AddContact(ContactViewModel contact)
        {
            var entity = contact.ToEntity();
            
            _unitOfWork.Contact.Insert(entity);
            _unitOfWork.BeginTransaction();
            _unitOfWork.SaveChanges();
            _unitOfWork.CommitTransaction();
            
        }

        public void DeleteContact(int contactId)
        {
            try
            {
                _unitOfWork.Contact.Delete((long)contactId);
                _unitOfWork.BeginTransaction();
                _unitOfWork.SaveChanges();
                _unitOfWork.CommitTransaction();
            }
            catch
            {
                _unitOfWork.RollbackTransaction();
            }
           
        }

        public List<ContactViewModel> GetAllContacts()
        {
            var entity = _unitOfWork.Contact.GetAllContacts();

            var listContact = new List<ContactViewModel>();

            foreach (var contact in entity)
            {
                var contactViewModel = new ContactViewModel();
                contactViewModel.Id = contact.Id;
                contactViewModel.ContactRoleId = contact.ContactRoleId;
                contactViewModel.ContactRoleName = contact.ContactRole.RoleName;
                contactViewModel.FirstName = contact.FirstName;
                contactViewModel.LastName = contact.LastName;
                contactViewModel.Address = contact.Address;
                contactViewModel.MobileNo = contact.MobileNo;

                listContact.Add(contactViewModel);
            }
            return listContact;
        }

        public void UpdateContact(ContactViewModel contactToUpdate)
        {
            var entity = contactToUpdate.ToEntity();
            _unitOfWork.Contact.Update(entity);
            _unitOfWork.SaveChanges();
        }
    }
}
