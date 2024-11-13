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
    public class AuthController : ApiController
    {
        public IHttpActionResult Post([FromBody] Credential crednetial)
        {
            IAuthService svc = new AuthService();
            if (svc.Login(crednetial.Email, crednetial.Password))
            {
                return Ok("login successful");
            }
            else
            {
                return Unauthorized();

            }

        }
    }
}