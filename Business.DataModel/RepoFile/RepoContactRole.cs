using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.DataModel.RepoFile
{
    public interface IContactRole: IGenericRepository<ContactRole>
    {
        List<ContactRole> GetAllContactRole();
    }
    public class RepoContactRole: GenericRepository<ContactRole>, IContactRole
    {
        public RepoContactRole(BusinessDBEntities context):base (context)
        {

        }

        public List<ContactRole> GetAllContactRole()
        {
            return GetAll().ToList();
        }
    }
}
