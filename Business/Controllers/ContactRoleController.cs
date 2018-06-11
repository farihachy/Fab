using BusinessEntities.Services;
using BusinessEntities.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace Business.Controllers
{
    [RoutePrefix("api/contactRole")]
    public class ContactRoleController : ApiController
    {
        private IContacRoleService _contactRoleService;

        public IContacRoleService ContacRoleService
        {
            get { return _contactRoleService ?? (_contactRoleService = new ContacRoleService(new DataModel.UnitOfWork())); }
        }

        [Route("GetAllContactRole")]
        public List<ContactRoleViewModel> GetAllContactRole()
        {
            var listContactRole=ContacRoleService.GetAllContactRole();
            return (listContactRole);
        }
    }
}
