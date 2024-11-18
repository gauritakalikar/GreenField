using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using HDFCBankApp.Models;
using HDFCBankApp.Services;
using HDFCBankApp.Repositories;
using System.Text.Json;

namespace HDFCBankApp.Services
{
    public class AuthService : IAuthService
    {
        public string usersJson = @"D:/users.json";
        public string credentialsJson = @"D:/credentials.json";

        private List<User> _users;
        private List<Credential> _credentials;

        private static Random random = new Random();
        public static string RandomString(int length)
        {
            const string chars = "ABCDEFGHIJKLMNOPQRSTUVWXYZ0123456789";
            return new string(Enumerable.Repeat(chars, length)
                        .Select(s => s[random.Next(s.Length)]).ToArray());
        }

        public AuthService()
        {
            _users = new List<User>();
            _credentials = new List<Credential>();
        }

        public List<User> GetAllUsers(string basePath)
        {
            List<User> allUsers = new List<User>();
            IDataRepository<User> repo = new JSONDataRepository<User>();
            repo.Deserialize(usersJson);

            return allUsers;
        }


        public bool DeleteUser(int id)
        {
            IDataRepository<User> repo = new JSONDataRepository<User>();
            _users = repo.Deserialize(usersJson);
            int status = _users.RemoveAll(x => x.Id == id);
            repo.Serialize(usersJson, _users);

            return status == 0 ? false : true;
        }

        public bool UpdateUser(User user)
        {
            bool status = false;

            IDataRepository<User> repo = new JSONDataRepository<User>();
            _users = repo.Deserialize(usersJson);

            foreach (User u in _users)
            {
                if (u.Id == user.Id)
                {
                    u.FirstName = user.FirstName;
                    u.LastName = user.LastName;
                    u.Email = user.Email;
                    u.ContactNumber = user.ContactNumber;
                    status = repo.Serialize(usersJson, _users);
                }
            }

            return status;
        }

        public List<Credential> GetAllCredentials()
        {
            IDataRepository<Credential> repo = new JSONDataRepository<Credential>();
            _credentials = repo.Deserialize(credentialsJson);

            return _credentials;
        }
        public List<User> GetAllUsers()
        {
            IDataRepository<User> repo = new JSONDataRepository<User>();

            _users = repo.Deserialize(usersJson);
            return _users;
        }
        public User GetUserById(int id)
        {
            User found = null;
            IDataRepository<User> repo = new JSONDataRepository<User>();
            List<User> allUsers = repo.Deserialize(usersJson);

            foreach (User u in allUsers)
            {
                if (u.Id == id)
                {
                    found = u; break;
                }
            }
            return found;
        }

        public bool Login(string email, string password)
        {
            // take credentials

            // validate against the Credentials available
            IDataRepository<Credential> repo = new JSONDataRepository<Credential>();
            List<Credential> allCredentials = repo.Deserialize(credentialsJson);

            foreach (Credential c in allCredentials)
            {
                if (c.Email == email)
                {
                    if (c.Password == password)
                    {
                        return true;
                    }
                }
            }

            // return

            return false;
        }

        public bool Register(User user)
        {
            // take userdata

            // fetch current user's list
            IDataRepository<Credential> credRepo = new JSONDataRepository<Credential>();
            List<Credential> allCredentials = credRepo.Deserialize(credentialsJson);

            IDataRepository<User> userRepo = new JSONDataRepository<User>();
            List<User> allUsers = userRepo.Deserialize(usersJson);

            int nextId = 1;
            if (allUsers.Count > 0)
            {
                nextId = allUsers.Max(u => u.Id) + 1; // Find the highest ID and increment it by 1
            }

            user.Id = nextId;

            // separate credentails and user data
            allUsers.Add(user);
            allCredentials.Add(new Credential { Email = user.Email, Password = RandomString(6) });

            bool status = true;
            // serialize credentials and user data
            status = userRepo.Serialize(usersJson, allUsers);
            status = (credRepo.Serialize(credentialsJson, allCredentials)) && status;


            // return 
            return status;
        }

        public bool SeedIniitalUserCredentials()
        {
            bool status = false;
            _users.Clear();
            _users.Add(new User { Id = 1, FirstName = "Rajas", LastName = "Doshi", Email = "rajas@gmail.com", ContactNumber = "9573847385" });
            _users.Add(new User { Id = 2, FirstName = "Yash", LastName = "Valvi", Email = "yash@gmail.com", ContactNumber = "7473738450" });

            IDataRepository<User> repo = new JSONDataRepository<User>();
            status = repo.Serialize(usersJson, _users);

            _credentials.Clear();
            _credentials.Add(new Credential { Email = "rajas@gmail.com", Password = "123" });
            _credentials.Add(new Credential { Email = "yash@gmail.com", Password = "123" });

            IDataRepository<Credential> repo2 = new JSONDataRepository<Credential>();
            status = (repo2.Serialize(credentialsJson, _credentials)) && status;

            return status;
        }

        public bool ResetPassword(string email, string oldPassword, string newPassword)
        {
            bool status = false;
            IDataRepository<Credential> repo = new JSONDataRepository<Credential>();
            List<Credential> allCredentials = repo.Deserialize(credentialsJson);

            foreach (Credential c in allCredentials)
            {
                if (c.Email == email && c.Password == oldPassword)
                {
                    c.Password = newPassword;
                }
            }

            status = repo.Serialize(credentialsJson, allCredentials);

            return status;
        }

        public string ForgotPassword(string email)
        {
            IDataRepository<Credential> repo = new JSONDataRepository<Credential>();
            List<Credential> allCredentials = repo.Deserialize(credentialsJson);

            foreach (Credential c in allCredentials)
            {
                if (c.Email == email)
                {
                    return c.Password;
                }
            }
            return null;
        }

    }
}