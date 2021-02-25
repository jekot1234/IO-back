using IO.Model;
using IO.Model.DataBaseSettings;
using MongoDB.Driver;
using System;
using System.Text.RegularExpressions;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using IO.Model.Users;

namespace IO.Services
{
    public class UserService : IUserService
    {

        private readonly IMongoCollection<User> _users;

        public UserService(IDatabaseSettings settings)
        {
            var client = new MongoClient(settings.ConnectionString);
            var database = client.GetDatabase(settings.DatabaseName);

            _users = database.GetCollection<User>(settings.UsersCollectionName);
        }

        public List<User> Get() =>
            _users.Find(user => true).ToList();

        public User Get(string id) =>
            _users.Find<User>(user => user.Id == id).FirstOrDefault();

        public User GetByEmail(string email) =>
            _users.Find<User>(user => user.Email == email).FirstOrDefault();

        public User Create(User user)
        {
            _users.InsertOne(user);
            return user;
        }

        public void Update(string id, User userIn) =>
            _users.ReplaceOne(user => user.Id == id, userIn);

        public void Remove(User userIn) =>
            _users.DeleteOne(user => user.Id == userIn.Id);

        public void Remove(string id) =>
            _users.DeleteOne(user => user.Id == id);

        public string Register(RegisterationData data)
        {
            if (data.Password != data.ConfirmPassword)
            {
                return "Password missmatch";
            }
            else if (GetByEmail(data.Email) != null)
            {
                return "Email allready exists";
            }
            else if (!Regex.IsMatch(data.Email, @"\A(?:[a-z0-9!#$%&'*+/=?^_`{|}~-]+(?:\.[a-z0-9!#$%&'*+/=?^_`{|}~-]+)*@(?:[a-z0-9](?:[a-z0-9-]*[a-z0-9])?\.)+[a-z0-9](?:[a-z0-9-]*[a-z0-9])?)\Z", RegexOptions.IgnoreCase))
            {
                return "Invalid email";
            }
            else if (!Regex.IsMatch(data.Password, @"^(.{0,7}|[^0-9]*|[^A-Z])$"))
            {
                return "Password must be at least 8 characters long, containt at least one upper case letter and cointain at least one digit";
            }
            else
            {
                byte[] passwordBytes = Encoding.ASCII.GetBytes(data.Password);
                var sha1 = new SHA1CryptoServiceProvider();
                var sha1data = sha1.ComputeHash(passwordBytes);
                string hashPassword = Encoding.ASCII.GetString(sha1data);

                data.Password = hashPassword;

                User user = new User();
                user.Name = data.Name;
                user.Email = data.Email;
                user.Password = data.Password;
                user.UserRole = 0;

                Create(user);

                return "User succesfully registered";
            }


        }

    }
}
