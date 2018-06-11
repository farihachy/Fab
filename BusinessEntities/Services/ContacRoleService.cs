using Business.DataModel;
using BusinessEntities.ViewModel;
using System.Collections.Generic;

namespace BusinessEntities.Services
{
    public interface IContacRoleService
    {
        List<ContactRoleViewModel> GetAllContactRole();
    }

    public class ContacRoleService: IContacRoleService
    {
        private IUnitOfWork _unitOfWork;

        public ContacRoleService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public List<ContactRoleViewModel> GetAllContactRole()
        {
            var entity = _unitOfWork.ContactRole.GetAllContactRole();

            var listContactRole = new List<ContactRoleViewModel>();

            foreach (var contactRole in entity)
            {
                var contactRoleViewModel = new ContactRoleViewModel();
                contactRoleViewModel.Id = contactRole.Id;
                contactRoleViewModel.RoleName = contactRole.RoleName;

                listContactRole.Add(contactRoleViewModel);
            }
            return listContactRole;
        }
    }
}
