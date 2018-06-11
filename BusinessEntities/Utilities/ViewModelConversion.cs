using Business.DataModel;
using System.Collections.Generic;

namespace BusinessEntities.ViewModel
{
    public static class ViewModelConversion
    {
        public static ContactRoleViewModel ToVM(this ContactRole e)
        {
            var entity = new ContactRoleViewModel();

            entity.Id = e.Id;
            entity.RoleName = e.RoleName;

            return entity;
        }

        //public static List<ContactRoleViewModel> ToVM(this List<ContactRole> listContact)
        //{
        //    return listContact.ToVM();

        //}
    }
}
