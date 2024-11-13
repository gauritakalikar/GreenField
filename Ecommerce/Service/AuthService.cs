using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.NetworkInformation;
using System.Text;
using System.Threading.Tasks;
using JSONDataRepositoryLib;
using EcommerceEntities;
using Specification;

namespace EcommerceServices
{

    public class AuthService : IAuthService
    {
        public static string logfile = @"C:/Users/gauri.takalikar/source/grepos/GreenField/Ecommerce/MembershipTestApp/bin/Debug/logfile.json";

        public static string credfile = @"C:/Users/gauri.takalikar/source/grepos/GreenField/Ecommerce/MembershipTestApp/bin/Debug/credentials.json";

        public bool Seeding()
        {

            bool status = false;
            List<User> Users = new List<User>();
            List<Credential> credentials = new List<Credential>();
            Users.Add(new User { FirstName = "Gauri", LastName = "Takalikar", Email = "gauri@gmail.com", ContactNo = "9975544" });
            Users.Add(new User { FirstName = "Shruti", LastName = "Kadam", Email = "shruti@gmail.com", ContactNo = "5645768" });

            credentials.Add(new Credential { Email = "gauri@gmail.com", Password = "1234" });
            credentials.Add(new Credential { Email = "shruti@gmail.com", Password = "5678" });

            //IDataRepository<User> repository = new BinaryRepository<User>();
            IDataRepository<User> repository = new JsonRepository<User>();
            //IDataRepository<Credential> dataRepository = new BinaryRepository<Credential>();
            IDataRepository<Credential> dataRepository = new JsonRepository<Credential>();
            status = repository.Serialize(logfile, Users);
            status = false;
            status = dataRepository.Serialize(credfile, credentials);
            return status;
        }
        public bool Register(User u, string pass)
        {
            bool status = false;
            List<User> users = new List<User>();
            users = GetAllUsers();
            users.Add(u);

            List<Credential> credentials = new List<Credential>();
            credentials = GetAllCredentials();
            Credential credential = new Credential { Email = u.Email, Password = pass };
            credentials.Add(credential);

            IDataRepository<User> repository = new JsonRepository<User>();
            status = repository.Serialize(logfile, users);
            status = false;

            IDataRepository<Credential> dataRepository = new JsonRepository<Credential>();
            status = dataRepository.Serialize(credfile, credentials);
            return status;
        }

        public string ForgotPassword(string username)
        {
            List<Credential> credentials = new List<Credential>();
            credentials = GetAllCredentials();
            foreach (Credential cred in credentials)
            {
                if (cred.Email == username)
                {
                    return cred.Password;
                }
            }
            return null;

        }
        public List<User> GetAllUsers()
        {
            List<User> users = new List<User>();
            IDataRepository<User> repository = new JsonRepository<User>();
            users = repository.Deserialize(logfile);
            return users;
        }
        public List<Credential> GetAllCredentials()
        {
            List<Credential> credentials = new List<Credential>();
            IDataRepository<Credential> repository = new JsonRepository<Credential>();
            credentials = repository.Deserialize(credfile);
            return credentials;
        }


        public bool Login(string username, string password)
        {
            IDataRepository<Credential> repository = new JsonRepository<Credential>();
            List<Credential> credentials = repository.Deserialize(credfile);
            foreach (Credential cred in credentials)
            {
                if (cred.Email == username && cred.Password == password)
                {
                    return true;
                }
            }
            return false;
        }

        public bool ResetPassword(string username, string oldpassword, string newpassword)
        {
            List<Credential> credentials = new List<Credential>();
            credentials = GetAllCredentials();
            foreach (Credential cred in credentials)
            {
                if (cred.Email == username & cred.Password == oldpassword)
                {
                    cred.Password = newpassword;
                    IDataRepository<Credential> dataRepository = new JsonRepository<Credential>();
                    return dataRepository.Serialize(credfile, credentials);
                }
            }
            return false;
        }

        public User GetUser(int id)
        {
            User foundUser = null;
            List<User> users = GetAllUsers();
            foreach (User u in users)
            {
                if (u.Id == id)
                {
                    foundUser = u;
                }
            }
            return foundUser;
        }

        public bool Delete(int id)
        {
            User user = GetUser(id);
            if (user != null)
            {
                List<User> users = GetAllUsers();
                users.RemoveAll(u => u.Id == id);
                IDataRepository<User> repository = new JsonRepository<User>();
                repository.Serialize(logfile, users);
                return true;
            }
            return false;
        }
    }
}