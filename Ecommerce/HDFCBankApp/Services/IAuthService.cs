using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HDFCBankApp.Models;
namespace HDFCBankApp.Services
{
    public interface IAuthService
    {
        bool Login(string username, string password);

        bool Register(User user);

        string ForgotPassword(string username);

        bool ResetPassword(string username, string oldPassword, string newPassword);
    }
}
