using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Membbership
{
    internal class AuthService : IAuthService
    {
        public bool Forgot(string username)
        {
            throw new NotImplementedException();
        }

        public bool Login(string username, string password)
        {
            throw new NotImplementedException();
        }

        public bool Register(string username, string password)
        {
            throw new NotImplementedException();
        }

        public bool Reset(string username, string oldpassword, string newpassword)
        {
            throw new NotImplementedException();
        }
    }
}
