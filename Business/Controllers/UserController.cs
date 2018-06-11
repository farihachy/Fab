using System.Web.Http;

namespace Business.Controllers
{
    public class UserController : ApiController
    {
        public string Get(int id)
        {
            return "value";
        }

        // POST api/product
        public void Post([FromBody]string value)
        {
        }

        // PUT api/product/5
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE api/product/5
        public void Delete(int id)
        {
        }
    }
}
