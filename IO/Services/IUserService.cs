namespace IO.Services
{
    using IO.Model;
    using IO.Model.Users;
    using System.Collections.Generic;
    public interface IUserService
    {
        User Authenticate(string username, string password);
        User Create(RegistrationUser user);
        List<User> Get();
        User GetById(string id);
        void Remove(string id);
        void Remove(User userIn);
        void Update(string id, User userIn);
    }
}