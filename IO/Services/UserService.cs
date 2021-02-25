using IO.Model;
using IO.Model.DataBaseSettings;
using MongoDB.Driver;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

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

        public string Register(User user, string confirmPass)
        {
            if(user.Password != confirmPass)
            {
                return "Password missmatch";
            } 
            else if (GetByEmail(user.Email) != null)
            {
                return "Email allready exists";
            } 
            else
            {
                byte[] passwordBytes = Encoding.ASCII.GetBytes(user.Password);
                var sha1 = new SHA1CryptoServiceProvider();
                var sha1data = sha1.ComputeHash(passwordBytes);
                string hashPassword = Encoding.ASCII.GetString(sha1data);

                user.Password = hashPassword;

                Create(user);

                return "User succesfully registered";
            }


        }

    }
}
