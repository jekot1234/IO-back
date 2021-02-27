namespace IO.Services
{
    using IO.Model;
    using IO.Model.DataBaseSettings;
    using MongoDB.Driver;
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using IO.Model.Users;
    using IO.Utils;
    public class UserService : IUserService
    {
        private readonly IMongoCollection<User> _users;
        public UserService(IDatabaseSettings settings)
        {
            var client = new MongoClient(settings.ConnectionString);
            var database = client.GetDatabase(settings.DatabaseName);

            _users = database.GetCollection<User>(settings.UsersCollectionName);
        }
        public User Authenticate(string email, string password)
        {
            if (string.IsNullOrEmpty(email) || string.IsNullOrEmpty(password))
                return null;

            User user = _users.Find(u => u.Email == email).FirstOrDefault();

            // check if username exists
            if (user == null)
                return null;

            // check if password is correct
            if (!CryptographyMethods.VerifyPasswordHash(password, Convert.FromBase64String(user.PasswordHash), Convert.FromBase64String(user.PasswordSalt)))
                return null;
            // authentication successful
            return user;
        }

        public List<User> Get() =>
            _users.Find(user => true).ToList();

        public User GetById(string id) =>
            _users.Find<User>(user => user.Id == id).FirstOrDefault();

        public User GetByEmail(string email) =>
            _users.Find<User>(user => user.Email == email).FirstOrDefault();

        public User Create(RegistrationUser user)
        {
            if (string.IsNullOrWhiteSpace(user.Password))
                throw new Exception("Password is required");

            if (_users.Find(x => x.Email == user.Email).Count() != 0)
                throw new Exception("Username \"" + user.Email + "\" is already taken");

            if (EmailValidation.Validate(user.Email))
                throw new Exception("Wrong email format.");

            byte[] passwordHash, passwordSalt;
            CryptographyMethods.CreatePasswordHash(user.Password, out passwordHash, out passwordSalt);

            User newUser = new User() {
                Email = user.Email,
                Id = "",
                Name = user.Name,
                UserRole = 0,
                PasswordHash = Convert.ToBase64String(passwordHash), 
                PasswordSalt = Convert.ToBase64String(passwordSalt)
            };

            _users.InsertOne(newUser);

            return newUser;
        }
        public void Update(string id, User userIn) =>
            _users.ReplaceOne(user => user.Id == id, userIn);
        public void Remove(User userIn) =>
            _users.DeleteOne(user => user.Id == userIn.Id);
        public void Remove(string id) =>
            _users.DeleteOne(user => user.Id == id);
    }
}
