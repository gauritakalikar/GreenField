using EcommerceEntities;
using EcommerceServices;
using Specification;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http;
using System.Web.Mvc;

namespace AuthWebAPI.Controllers
{
    public class UserController : ApiController
    {
        public IEnumerable<User> Get()
        {
            AuthService svc = new AuthService();
            List<User> users = svc.GetAllUsers();
            return users;
        }

        // GET api/user/5
        public User Get(int id)
        {
            AuthService svc = new AuthService();
            User user = svc.GetUser(id);
            return user;
        }

        // POST api/user
        public void Post([FromBody] User user, string pass)
        {
            IAuthService svc = new AuthService();
            svc.Register(user, pass);
        }

        // DELETE api/user/5
        public void Delete(int id)
        {
            IAuthService svc = new AuthService();
            svc.Delete(id);
        }
    }
}