using System.Collections.Generic;
using System.Linq;

namespace Business.DataModel.RepoFile
{
    public interface IContact : IGenericRepository<Contact>
    {
        List<Contact> GetAllContacts();
    }

    public class RepoContact : GenericRepository<Contact>, IContact
    {
        public RepoContact(BusinessDBEntities context) : base(context)
        {

        }

        public List<Contact> GetAllContacts()
        {
            return GetAll().ToList();
        }
    }
}
