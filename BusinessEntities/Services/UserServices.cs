using Business.DataModel;
using BusinessEntities.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;  
using System.Text;
using System.Threading.Tasks;

namespace BusinessEntities.Services
{
    public interface IUserServices
    {
        UserViewModel GetProductById(int userId);
        IEnumerable<UserViewModel> GetAllUsers();
        int CreateUser(UserViewModel productEntity);
        bool UpdateUser(int productId, UserViewModel productEntity);
        bool DeleteUser(int productId);
    }

    public class UserServices:IUserServices
    {
        private readonly UnitOfWork _unitOfWork;

        public UserServices()
        {
            _unitOfWork = new UnitOfWork();
        }

        public int CreateUser(UserViewModel productEntity)
        {
            throw new NotImplementedException();
        }

        public bool DeleteUser(int productId)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<UserViewModel> GetAllUsers()
        {
            //return _unitOfWork.UserRepository.GetAll();
            throw new NotImplementedException();
        }

        public UserViewModel GetProductById(int userId)
        {
            throw new NotImplementedException();
        }

        public bool UpdateUser(int productId, UserViewModel productEntity)
        {
            throw new NotImplementedException();
        }
    }
}
