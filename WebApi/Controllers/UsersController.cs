using System.Web.Http;
using WebApi.Models;

namespace WebApi.Controllers
{
    public class UsersController : ApiController
    {
        [HttpGet]
        [Route("api/v1/GetUser/{name}")]

        public IHttpActionResult GetUsersbyName(string name)
        {
            return Ok(new User
            {
                Name = name,
                Email = name
            });
        }

        [HttpPost]
        [Route("api/v1/AddUser/")]

        public IHttpActionResult AddUser(User user)
        {
            return Ok(user.Name);
        }
    }
}
