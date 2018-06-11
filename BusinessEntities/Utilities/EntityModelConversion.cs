using Business.DataModel;

namespace BusinessEntities.ViewModel
{
    public static class EntityModelConversion
    {
        public static Contact ToEntity(this ContactViewModel e)
        {
            var contactEntity = new Contact();

            contactEntity.Id= e.Id;
            contactEntity.FirstName = e.FirstName;
            contactEntity.LastName = e.LastName;
            contactEntity.ContactRoleId = e.ContactRoleId;
            contactEntity.Address = e.Address;
            contactEntity.MobileNo = e.MobileNo;

            return contactEntity;
        }

        public static Product ToEntity(this ProductViewModel e)
        {
            var productEntity = new Product();

            productEntity.Id = e.Id;
            productEntity.CategoryId = e.CategoryId;
            productEntity.Name = e.Name;
            productEntity.Code = e.Code;

            return productEntity;
        }
    }
}
