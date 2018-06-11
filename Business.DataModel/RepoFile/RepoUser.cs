using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.DataModel
{
    public interface IUser : IGenericRepository<User>
    {
        List<User> getAllUser();
    }

    public class RepoUser : GenericRepository<User>, IUser
    {
        public RepoUser(BusinessDBEntities context) : base(context)
        {
        }

        public List<User> getAllUser()
        {
            return Get().ToList();
        }
    }
}
