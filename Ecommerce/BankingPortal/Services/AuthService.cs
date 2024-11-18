using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using BankingPortal.Models;
using BankingPortal.Repositories;
namespace BankingPortal.Services
{
    public class AuthService : IAuthService

    {

        public static string logfile = "C:/Users/gauri.takalikar/source/grepos/GreenField/Ecommerce/BankingPortal/bin/BankUsers.json";

        public static string credfile = "C:/Users/gauri.takalikar/source/grepos/GreenField/Ecommerce/BankingPortal/bin/BankCredetial.json";

        public bool Seeding()

        {

            bool status = false;

            List<User> Users = new List<User>();

            List<Credentials> credentials = new List<Credentials>();

            Users.Add(new User { FirstName = "Gauri", LastName = "Takalikar", Email = "gauri@gmail.com", ContactNo = 5768587696, Location = "Pune" });

            Users.Add(new User { FirstName = "Sonal", LastName = " Dangale", Email = "sonal@gmail.com", ContactNo = 5667788990, Location = "Pune" });

            Users.Add(new User { FirstName = "Rutuja", LastName = "Patil", Email = "YadavPatilRutujata@gmail.com", ContactNo = 5667788990, Location = "Pune" });

            Users.Add(new User { FirstName = "Aditya", LastName = " Patil", Email = "aditya@gmail.com", ContactNo = 5667788990, Location = "Pune" });

            credentials.Add(new Credentials { Email = "YadavPatilRutujata@gmail.com", Password = "abc" });

            credentials.Add(new Credentials { Email = "sonal@gmail.com", Password = "abc" });

            credentials.Add(new Credentials { Email = "YadavPatilRutujata@gmail.com", Password = "123" });

            credentials.Add(new Credentials { Email = "aditya@gmail.com", Password = "abc" });

            IDataRepository<User> repository = new JsonRepository<User>();

            IDataRepository<Credentials> dataRepository = new JsonRepository<Credentials>();

            status = repository.Serialize(logfile, Users);

            status = false;

            status = dataRepository.Serialize(credfile, credentials);

            return status;

        }

        private static Random random = new Random();

        public static string RandomString(int length)

        {

            const string chars = "ABCDEFGHIJKLMNOPQRSTUVWXYZ0123456789";

            return new string(Enumerable.Repeat(chars, length)

                .Select(s => s[random.Next(s.Length)]).ToArray());

        }

        public bool Register(string firstname, string lastname, string email, long contactno, string location)

        {

            bool status = false;

            List<User> users = new List<User>();

            users = GetAllUsers();

            User u = new User();

            u.FirstName = firstname;

            u.LastName = lastname;

            u.Email = email;

            u.ContactNo = contactno; u.Location = location;

            users.Add(u);

            List<Credentials> credentials = new List<Credentials>();

            credentials = GetAllCredentials();

            Credentials credential = new Credentials { Email = email, Password = RandomString(6) };

            credentials.Add(credential);

            IDataRepository<User> repository = new JsonRepository<User>();

            status = repository.Serialize(logfile, users);

            IDataRepository<Credentials> dataRepository = new JsonRepository<Credentials>();

            status = dataRepository.Serialize(credfile, credentials);

            return status;

        }

        public string ForgotPassword(string username)

        {

            List<Credentials> credentials = new List<Credentials>();

            credentials = GetAllCredentials();

            foreach (Credentials cred in credentials)

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

        public User GetById(int Id)

        {

            User user = null;

            List<User> users = GetAllUsers();

            foreach (User u in users)

            {

                if (u.Id == Id)

                {

                    user = u;

                }

            }

            return user;

        }

        public List<Credentials> GetAllCredentials()

        {

            List<Credentials> credentials = new List<Credentials>();

            IDataRepository<Credentials> repository = new JsonRepository<Credentials>();

            credentials = repository.Deserialize(credfile);

            return credentials;

        }


        public bool Login(string username, string password)

        {

            IDataRepository<Credentials> repository = new JsonRepository<Credentials>();

            List<Credentials> credentials = repository.Deserialize(credfile);

            foreach (Credentials cred in credentials)

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

            List<Credentials> credentials = new List<Credentials>();

            credentials = GetAllCredentials();

            foreach (Credentials cred in credentials)

            {

                if (cred.Email == username & cred.Password == oldpassword)

                {

                    cred.Password = newpassword;

                    IDataRepository<Credentials> dataRepository = new JsonRepository<Credentials>();

                    return dataRepository.Serialize(credfile, credentials);

                }

            }

            return false;

        }

        public bool Delete(int id)

        {

            User user = GetById(id);

            if (user != null)

            {

                List<User> users = GetAllUsers();

                users.RemoveAll(u => u.Id == id);

                IDataRepository<User> repository = new JsonRepository<User>();

                repository.Serialize("C:/Users/gauri.takalikar/source/grepos/GreenField/Ecommerce/BankingPortal/bin/BankUsers.json", users);

                return true;

            }

            return false;

        }

    }
}