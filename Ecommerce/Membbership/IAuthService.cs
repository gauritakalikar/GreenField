using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Membbership
{
    public interface IAuthService
    {
        bool Login(string username, string password);
        bool Register(string username, string password);
        bool Forgot(string username);
        bool Reset(string username, string oldpassword,string newpassword);
    }
}
